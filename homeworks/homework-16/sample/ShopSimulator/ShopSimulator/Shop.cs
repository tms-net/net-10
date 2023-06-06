namespace ShopSimulator
{
    public class Shop
    {
        // Что синхронизировать?
        //  - 

        private const int IdleTime = 100;

        private Thread[] _cahierThreads;
        private Queue<Person> _peopleQueue; // Эмуляция очереди клиентов

        public Shop(int cahierCount)
        {
            _peopleQueue = new Queue<Person>();
            _peopleQueueCuncurrent = new ConcurrentQueue<Person>();
            _cahierThreads = new Thread[cahierCount];

            for (int i = 0; i < cahierCount; i++)
            {
                _cahierThreads[i] = new Thread(ServeCustomers);
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
            Console.WriteLine($"{person.Name} вошел в магазин");
            _peopleQueue.Enqueue(person);

        }

        public void Close()
        {
            // TODO: Реализовать гарантированное обслуживание всех клиентов после закрытия
        }

        private void ServeCustomers()
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
