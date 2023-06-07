// See https://aka.ms/new-console-template for more information

namespace Async
{
    public class Service
    {
        public Task DoWork()
        {
            Thread.Sleep(5000);

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: Hello, Sync! ");

            return Task.CompletedTask;
        }

        public async Task DoWorkAsync()
        {
            await Task.Delay(5000);

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: Hello, Async! ");
        }

        public Task<IEnumerable<int>> DoMoreWork()
        {
            return Task.FromResult(GetEnumerable());
        }

        public async Task<IEnumerable<int>> DoMoreWorkAsync()
        {
            var array = new int[10000];
            Console.Write($"{Thread.CurrentThread.ManagedThreadId}: Start, Async! ");
            for (int i = 0; i < 10000; i++)
            {
                await Task.Yield();
                array[i] = i;
                Console.Write($"{Thread.CurrentThread.ManagedThreadId}: {i} ");
            }
            Console.Write($"{Thread.CurrentThread.ManagedThreadId}: Done, Async! ");

            return array.AsEnumerable();
        }

        public async Task<IEnumerable<int>> DoMoreAsyncWork()
        {
            var list = new List<int>();
            await foreach (var i in GetAsyncEnumerable())
            {
                list.Add(i);
            }
            return list;
        }

        private IEnumerable<int> GetEnumerable()
        {
            Console.Write($"{Thread.CurrentThread.ManagedThreadId}: Start, Sync! ");
            for (int i = 0; i < 10000; i++)
            {
                yield return i;
                Console.Write($"{Thread.CurrentThread.ManagedThreadId}: {i} ");
            }
            Console.Write($"{Thread.CurrentThread.ManagedThreadId}: Done, Sync! ");
        }

        private async IAsyncEnumerable<int> GetAsyncEnumerable()
        {
            Console.Write($"{Thread.CurrentThread.ManagedThreadId}: Start, Async! ");
            for (int i = 0; i < 10000; i++)
            {
                await Task.Yield();
                yield return i;
                Console.Write($"{Thread.CurrentThread.ManagedThreadId}: {i} ");
            }
            Console.Write($"{Thread.CurrentThread.ManagedThreadId}: Done, Async! ");
        }
    }
}