namespace ShopSimulator
{
    public class Shop
    {
        private bool _shopOpen;
        private object _locker = new object();
        private Thread[] _cahierThreads;
        private Queue<Person> _peopleQueue; // Эмуляция очереди клиентов

        public Shop(int cahierCount)
        {
            _peopleQueue = new Queue<Person>();
            _cahierThreads = new Thread[cahierCount];

            for (int i = 0; i < cahierCount; i++)
            {
                int numberCashier = i + 1;
                _cahierThreads[i] = new Thread(() => ServeCustomer(numberCashier));
            }
        }

        public void Open()
        {
            _shopOpen = true;
            Array.ForEach(_cahierThreads, thread => thread.Start());
            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cahierThreads.Length} касс(ы)");

        }

        public void Enter(Person person)
        {
            if (_shopOpen)
            {
                _peopleQueue.Enqueue(person);
                Console.WriteLine($"{person.Name} вошел в магазин");
            }
        }

        public void Close()
        {
            _shopOpen = false;
            Console.WriteLine("Магазин закрыт. Ожидание обслуживания находящихся в магазине клиентов");
            Array.ForEach( _cahierThreads, thread => thread.Join());
            Console.WriteLine("Обслуживание клиентов завершено.");
        }

        private void ServeCustomer(object numCasher)
        {
            Person person = null;
            while (_peopleQueue.Count > 0 || _shopOpen)
            {
                lock (_locker)
                {
                    if (_peopleQueue.Count > 0)
                    {
                        person = _peopleQueue.Dequeue();
                    }
                }
                if (person != null)
                {
                    Console.WriteLine($"Касса {numCasher} обслуживает клиента {person.Name}");
                    Thread.Sleep(person.ProcessingTime);
                    Console.WriteLine($"Клиент {person.Name} вышел из магазина.");
                    person = null;
                }

            }
        }
    }
}
