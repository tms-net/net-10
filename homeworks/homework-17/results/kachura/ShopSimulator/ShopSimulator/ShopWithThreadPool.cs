using System;

namespace ShopSimulator
{
    public class ShopWithThreadPool
    {
        private static Semaphore _semaphore;
        private Queue<Person> _peopleQueue; // Эмуляция очереди клиентов
        private bool _isShopOpen;
        private int _cashierCount;
        private readonly int WAITINGTIME = 100;

        public ShopWithThreadPool(int cashierCount)
        {
            _semaphore = new Semaphore(cashierCount, cashierCount);
            _peopleQueue = new Queue<Person>();
            _cashierCount = cashierCount;
        }

        public void Open()
        {
            _isShopOpen = true;            
            Console.WriteLine($"Добро пожаловать");
        }

        public void Enter(Person person)
        {
            if(_isShopOpen)
            {
                Console.WriteLine($"{person.Name} вошел в магазин");
                _peopleQueue.Enqueue(person);
                ThreadPool.QueueUserWorkItem(RunServing);
            }
        }

        public void Close()
        {
            _isShopOpen = false;
        }

        private void RunServing(object state)
        {
            Thread.CurrentThread.IsBackground = false;
            ServeCustomer();
        }

        private void ServeCustomer()
        {
            _semaphore.WaitOne();

            Person curPerson = null;
            curPerson = _peopleQueue.Dequeue();

            if (curPerson != null)
            {
                Console.WriteLine($"{curPerson.Name} обслуживается сейчас");
                Thread.Sleep(curPerson.ProcessingTime);
                Console.WriteLine($"{curPerson.Name} обслужен");
            }
            else
            {
                Console.WriteLine("Queue is empty. Waiting...");
                Thread.Sleep(WAITINGTIME);
            }

            _semaphore.Release();
        }
    }
}
