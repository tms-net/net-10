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

            while (_customerCount > 0)
            {
                Thread.Sleep(100);
            }
        }

        private void ServeCustomer(Person person)
        {
            _semaphore.Wait(); 

                Thread.Sleep(person.ProcessingTime);

                Console.WriteLine($"Обслужили клиента {person.Name}");

                Interlocked.Decrement(ref _customerCount);

            _semaphore.Release();
        }
    }
}
