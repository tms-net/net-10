namespace ShopSimulator
{
    public class Shop
    {
        private Thread[] _cahierThreads;
        private Queue<Person> _peopleQueue; // Эмуляция очереди клиентов
        private bool _isOpened = true;
        object locker = new();

        public Shop(int cahierCount)
        {
            _peopleQueue = new Queue<Person>();
            _cahierThreads = new Thread[cahierCount];
            for (int i = 0; i < cahierCount; i++)
            {
                _cahierThreads[i] = new Thread(ServeCustomers);
            }
        }

        public void Open()
        {
            Array.ForEach(_cahierThreads, thread => thread.Start());

            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cahierThreads.Length} касс(ы)");
            _isOpened = true;
        }

        public void Enter(Person person)
        {
            // TODO: Реализовать логику постановки клиента в очередь
            if (!_isOpened)
            {
                return;
            }
            Console.WriteLine($"{person.Name} вошел в магазин");

            lock (_peopleQueue)
            {
                _peopleQueue.Enqueue(person);
            }


        }
        public void Close()
        {
            // TODO: Реализовать гарантированное обслуживание всех клиентов после закрытия

            while (_peopleQueue.Count() > 0)
            {
                Thread.Sleep(100);
            }
            _isOpened = false;
        }

        private void ServeCustomers()
        {
            Person _client = null;
            while (_isOpened || _peopleQueue.Count() > 0)
            {
                if (_peopleQueue.Count() > 0)
                {
                    lock (locker)
                    {
                        _peopleQueue.TryDequeue(out _client);
                    }
                        Console.WriteLine($"Клиент {_client.Name} обслуживается");
                        Thread.Sleep(_client.ProcessingTime);
                        Console.WriteLine($"Клиент {_client.Name} вышел из магазина");
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }
    }
}
