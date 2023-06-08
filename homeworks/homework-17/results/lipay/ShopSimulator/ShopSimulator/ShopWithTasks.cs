using System.Collections.Concurrent;

namespace ShopSimulator
{
    internal class ShopWithTasks
    {
        private bool _isOpened = false;
        private int _cashierCount;
        private SemaphoreSlim _semaphore;
        private ConcurrentBag<Task> _tasks;

        public ShopWithTasks(int cahierCount)
        {
            _cashierCount = cahierCount;
            _semaphore = new SemaphoreSlim(cahierCount, cahierCount);

            _tasks = new ConcurrentBag<Task>();

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

            _tasks.Add(Task.Run(() => ServeCustomer(person)));

            //_tasks.Add(ServeCustomer(person));

            Console.WriteLine($"{person.Name} вошел в магазин");
        }

        public void Close()
        {
            _isOpened = false;

            Task.WaitAll(_tasks.ToArray());
        }

        // task1 -> task2 -> task3

        private async Task ServeCustomer(Person person)
        {
            _semaphore.Wait(); // одна очередь

            if (person != null)
            {
                //Thread.Sleep(person.ProcessingTime); // ждать 1 секунду

                // асинхронность НЕ БЛОКИРУЕТ
                // выполнить следующий код через 1 секунду

                await Task.Delay(person.ProcessingTime);

                Console.WriteLine($"Обслужили клиента {person.Name}");
            }

            _semaphore.Release();

            //return Task.CompletedTask;
        }
    }
}
