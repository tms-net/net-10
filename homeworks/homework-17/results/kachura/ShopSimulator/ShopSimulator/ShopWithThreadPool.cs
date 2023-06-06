using System;

namespace ShopSimulator
{
    public class ShopWithThreadPool
    {
        private Queue<Person> _peopleQueue; // Эмуляция очереди клиентов
        private bool _isShopOpen;
        private object locker = new();        
        private int _cashierCount;
        private readonly int WAITINGTIME = 100;

        public ShopWithThreadPool(int cashierCount)
        {
            _peopleQueue = new Queue<Person>();
            _cashierCount = cashierCount;
        }

        public void Open()
        {
            _isShopOpen = true;
            for (int i = 0; i < _cashierCount; i++)
            {
                ThreadPool.QueueUserWorkItem(RunServing);
            }

            Console.WriteLine($"Добро пожаловать");
        }

        public void Enter(Person person)
        {
            Console.WriteLine($"{person.Name} вошел в магазин");
            _peopleQueue.Enqueue(person);
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
            while (_isShopOpen || _peopleQueue.Count() > 0)
            {
                Person curPerson = null;

                lock (locker)
                {
                    if (_peopleQueue.Count() > 0)
                    {
                        curPerson = _peopleQueue.Dequeue();
                    }
                }

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
            }           
        }
    }
}
