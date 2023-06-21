using System;
using System.Collections.Concurrent;

namespace ShopSimulator
{
    public class Shop
    {
        private Thread[] _cahierThreads;
        private ConcurrentQueue<Person> _peopleQueue; // Эмуляция очереди клиентов
        private bool _isOpen;
        public Shop(int cahierCount)
        {
            _peopleQueue = new ConcurrentQueue<Person>();
            _cahierThreads = new Thread[cahierCount];

            for (int i = 0; i < cahierCount; i++)
            {
                _cahierThreads[i] = new Thread(ServeCustomer);
            }
        }

        public void Open()
        {
            _isOpen = true;
            Array.ForEach(_cahierThreads, thread => thread.Start());

            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cahierThreads.Length} касс(ы)");
        }

        public void Enter(Person person)
        {
            // TODO: Реализовать логику постановки клиента в очередь
            if (_isOpen)
            {
                lock (_peopleQueue)
                {
                    _peopleQueue.Enqueue(person);                    
                }
                Console.WriteLine($"{person.Name} вошел в магазин");
            }            
        }

        public void Close()
        {
            _isOpen = false;
            Console.WriteLine("Store is closing. There's no escape! Surrender!");
            while (_peopleQueue.Count > 0 ) 
            {
                Thread.Sleep(100);
            }
            // TODO: Реализовать гарантированное обслуживание всех клиентов после закрытия
        }

        private void ServeCustomer()
        {
            while (_isOpen || _peopleQueue.Count > 0)
            {
                if (_peopleQueue.Count == 0)
                {
                    Thread.Sleep(new Random().Next(100));
                }
                else
                {
                    lock (_peopleQueue)
                    {
                        if (_peopleQueue.TryDequeue(out var person))
                        {
                            Thread.Sleep(person.ProcessingTime);
                            Console.WriteLine($"{person.Name} served with a few grams of lead");
                        }
                    }
                }                    
                
            }
            // TODO: Реализовать логику обслуживания клиента из очереди
            // Использовать свойство клиента для эмуляции времени обслуживания с помощью Thread.Sleep()
        }
    }
}
