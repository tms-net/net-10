using System;

namespace ShopSimulator
{
    public class Shop
    {
        private Thread[] _cahierThreads;
        private Queue<Person> _peopleQueue; // Эмуляция очереди клиентов
        private bool _isShopOpen;
        private object locker = new();
        private readonly int WAITINGTIME = 100;

        public Shop(int cahierCount)
        {
            _peopleQueue = new Queue<Person>();
            _cahierThreads = new Thread[cahierCount];

            for (int i = 0; i < cahierCount; i++)
            {
                _cahierThreads[i] = new Thread(ServeCustomer);
            }
        }

        public void Open()
        {
            _isShopOpen = true;
            Array.ForEach(_cahierThreads, thread => thread.Start());

            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cahierThreads.Length} касс(ы)");
        }

        public void Enter(Person person)
        {
            if(_isShopOpen) {
            Console.WriteLine($"{person.Name} вошел в магазин");
            _peopleQueue.Enqueue(person);
            }

        }

        public void Close()
        {
            _isShopOpen = false;
        }

        private void ServeCustomer()
        {
            while(_isShopOpen || _peopleQueue.Count() > 0)
            {
                Person curPerson = null;

                lock (locker)
                {
                    if (_peopleQueue.Count() > 0)
                    {
                        curPerson = _peopleQueue.Dequeue();
                    }
                }

                if(curPerson != null)
                {
                    Console.WriteLine($"{curPerson.Name} обслуживается сейчас");
                    Thread.Sleep(curPerson.ProcessingTime);
                    Console.WriteLine($"{curPerson.Name} обслужен");
                }
                else
                {
                    Console.WriteLine("Queue is empty. Waiting..."); //
                    Thread.Sleep(WAITINGTIME);
                }                
            }
        }
    }
}
