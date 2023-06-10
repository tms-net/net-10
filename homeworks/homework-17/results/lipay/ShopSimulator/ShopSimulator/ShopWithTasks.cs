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

            Console.WriteLine($"{person.Name} вошел в магазин");
        }

        public void Close()
        {
            _isOpened = false;

            Task.WaitAll(_tasks.ToArray());
        }

        private async Task ServeCustomer(Person person)
        {
            _semaphore.Wait();

            await Task.Delay(person.ProcessingTime);

                Console.WriteLine($"Обслужили клиента {person.Name}");
            
            _semaphore.Release();
            
        }
    }
}
