using System.Collections.Concurrent;

namespace ShopSimulator
{
    internal class ShopWithThreadPool
    {
        private bool _isOpened = false;
        private int _cashierCount;
        private SemaphoreSlim _semaphore;

        private int _customerCount = 0;

        public ShopWithThreadPool(int cahierCount)
        {
            _cashierCount = cahierCount;
            _semaphore = new SemaphoreSlim(cahierCount, cahierCount);

            //_cashiers = new Cashier[cahierCount];
        }

        public void Open()
        {
            _isOpened = true;

            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cashierCount} касс(ы)");
        }

        public void Enter(Person person)
        {
            if (!_isOpened)
            {
                return;
            }

            Interlocked.Increment(ref _customerCount);

            ThreadPool.QueueUserWorkItem(state => ServeCustomer(person));

            Console.WriteLine($"{person.Name} вошел в магазин");
        }

        public void Close()
        {
            _isOpened = false;

            //var original = Interlocked.CompareExchange(ref _customerCount, -1, 0);

            while (_customerCount > 0)
            {
                Thread.Sleep(100);
            }
        }

        private void ServeCustomer(Person person)
        {
            _semaphore.Wait(); // одна очередь

            //                       1,1m,1m,1h
            // []                    2,1m,1m,1h
            //                       3,1m,1m,1h

            // n objects

            // выбрать равномерно/случайно

            // lock(cashier)

            // n очередей

            if (person != null)
            {
                Thread.Sleep(person.ProcessingTime);

                Console.WriteLine($"Обслужили клиента {person.Name}");
            }

            //lock (_locker)
            {
                Interlocked.Decrement(ref _customerCount);

                //_customerCount--; // получение значения -> вычитание -> сохранение значения
            }

            _semaphore.Release();
        }
    }
}
