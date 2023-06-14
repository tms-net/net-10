using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ShopSimulator
{
    internal class ShopWithTasks
    {
        private bool _isOpened = false;
        private int _cashierCount;
        private SemaphoreSlim _semaphore;
        private ConcurrentBag<Task> _tasks;
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

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
            CancellationToken token = cancelTokenSource.Token;

            //_tasks.Add(Task.Run(() => ServeCustomer(person)));
            _tasks.Add(Task.Run(() => ServeCustomer(person, token),token));
            
       
            Console.WriteLine($"{person.Name} вошел в магазин");
        }

        public void Close()
        {
            _isOpened = false;
            
            cancelTokenSource.Cancel();
            Thread.Sleep(5000);
            Task.WaitAll(_tasks.ToArray());
            cancelTokenSource.Dispose();
        }

        private async Task ServeCustomer(Person person, CancellationToken token)
        {
            _semaphore.Wait();
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Операция прервана");
                return;
            }
            await Task.Delay(person.ProcessingTime);

                Console.WriteLine($"Обслужили клиента {person.Name}");
            
            _semaphore.Release();
            
        }
    }
}
