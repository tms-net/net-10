using System;
using System.Collections.Concurrent;

namespace ShopSimulator
{
    public class Shop
    {
        private bool _isOpened = false;
        private int _cashierCount;
        private SemaphoreSlim _semaphore;
        private ConcurrentBag<Task> _tasks;

        private int _customerCount = 0;

        public Shop(int cahierCount)
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
            // TODO: Реализовать логику постановки клиента в очередь

            if (!_isOpened)
            {
                return;
            }

            // ждем освобождения потока

            Interlocked.Increment(ref _customerCount);

            _tasks.Add(Task.Run(() => ServeCustomer(person)));

            //_tasks.Add(ServeCustomer(person));

            Console.WriteLine($"{person.Name} вошел в магазин");
            _peopleQueue.Enqueue(person);

        }

        public void Close()
        {
            // TODO:

            _isOpened = false;

            //var original = Interlocked.CompareExchange(ref _customerCount, -1, 0);

            //while (_customerCount == -1)
            //{
            //    Thread.Sleep(100);
            //}

            Task.WaitAll(_tasks.ToArray());
        }

        // task1 -> task2 -> task3

        private async Task ServeCustomer(Person person)
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
                //Thread.Sleep(person.ProcessingTime); // ждать 1 секунду

                // асинхронность НЕ БЛОКИРУЕТ
                // выполнить следующий код через 1 секунду

                await Task.Delay(person.ProcessingTime);

                Console.WriteLine($"Обслужили клиента {person.Name}");
            }

            //lock (_locker)
            {
                //Interlocked.Decrement(ref _customerCount);

                //_customerCount--; // получение значения -> вычитание -> сохранение значения
            }

            _semaphore.Release();

            //return Task.CompletedTask;
        }
    }
}
