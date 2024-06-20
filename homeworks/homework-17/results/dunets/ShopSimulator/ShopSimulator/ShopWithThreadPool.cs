using System.Collections.Concurrent;

namespace ShopSimulator
{
    internal class ShopWithThreadPool
    {
        private Queue<Person> _peopleQueue; // Эмуляция очереди клиентов
        private bool _isOpen;

        public ShopWithThreadPool(int cahierCount)
        {
            _peopleQueue = new Queue<Person>();
            
            ThreadPool.SetMaxThreads(cahierCount, 1);
            //ThreadPool.QueueUserWorkItem(ServeCustomer);
        }

        public void Open()
        {
            _isOpen = true;
            
            ThreadPool.GetAvailableThreads(out var workerThreads, out _);
            Console.WriteLine($"Добро пожаловать, вас обслуживает {workerThreads} касс(ы)");
        }

        public void Enter(Person person)
        {
            if (_isOpen)
            {
                _peopleQueue.Enqueue(person);
                Console.WriteLine($"{person.Name} вошел в магазин");
                ThreadPool.QueueUserWorkItem(ServeCustomer, _peopleQueue.Dequeue());
            }
        }

        public void Close()
        {
            _isOpen = false;
            Console.WriteLine("Store is closing. There's no escape! Surrender!");
        }

        public void ServeCustomer(object persona)
        {
            var person = (Person) persona;
            Thread.Sleep(person.ProcessingTime);
            Console.WriteLine($"{person.Name} served with a few grams of lead");
        }
    }
}
