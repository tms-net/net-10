using System.Collections.Concurrent;

namespace ShopSimulator
{
    internal class ShopWithQueue
    {
        private Queue<Person> _peopleQueue; // Эмуляция очереди клиентов
        private Semaphore _semaphore;
        private int _cahierCount;
        private List<Task> _tasks;
        private bool _isOpen;

        public ShopWithQueue(int cahierCount)
        {
            _peopleQueue = new Queue<Person>();
            _cahierCount = cahierCount;
            _semaphore = new Semaphore(cahierCount, cahierCount);
            _tasks = new List<Task>();
        }

        public void Open()
        {
            _isOpen = true;
 
            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cahierCount} касс(ы)");
        }

        public void Enter(Person person)
        {
            if (_isOpen)
            {
                _peopleQueue.Enqueue(person);
                Console.WriteLine($"{person.Name} вошел в магазин");

                _tasks.Add(Task.Run(() => ServeCustomer(_peopleQueue.Dequeue()))); ;                                
            }
        }

        public void Close()
        {
            _isOpen = false;
            Console.WriteLine("Store is closing. There's no escape! Surrender!");
            Task.WaitAll(_tasks.ToArray());            
        }

        public void ServeCustomer(Person persona)
        {
            _semaphore.WaitOne();

            Thread.Sleep(persona.ProcessingTime);
            Console.WriteLine($"{persona.Name} served with a few grams of lead");

            _semaphore.Release();
        }
    }
}
