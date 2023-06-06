using System.Collections.Concurrent;

namespace ShopSimulator
{
    public class Shop
    {
        // Что синхронизировать?
        //  - 

        private const int IdleTime = 100;

        private Thread[] _cahierThreads;
        private Queue<Person> _peopleQueue; // Эмуляция очереди клиентов
        private ConcurrentQueue<Person> _peopleQueueCuncurrent;

        private bool _isOpened = false;

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
            _isOpened = true;
            Array.ForEach(_cahierThreads, thread => thread.Start());

            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cahierThreads.Length} касс(ы)");
        }

        public void Enter(Person person)
        {
            // TODO: Реализовать логику постановки клиента в очередь

            if (!_isOpened)
            {
                return;
            }

            // Синхронизируем

            // lock (Monitor)
            // mutex
            // semaphore
            // eventHandle


            //1: enqueue
            //2:        enqueue
            //3:               enqueue

            lock (_peopleQueue)
            {
                _peopleQueue.Enqueue(person); // [1,2,3,,,,,,] -> [1,2,3,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,]
            }

            //1:1
            //2:1
            //3:1
            //if (_peopleQueue.Count > 0)
            {
                // 1
                // 0
                // 0
                //if (_peopleQueue.TryDequeue(out var person))
                {

                };
            }

            Console.WriteLine($"{person.Name} вошел в магазин");
        }

        public void Close()
        {
            // TODO: Реализовать [гарантированное] обслуживание всех клиентов после закрытия

            // 1
            // 1
            // 0

            while (_peopleQueue.Count() > 0)
            {
                Console.WriteLine("Ждем завершения");
                Thread.Sleep(1000);
            }

            _isOpened = false;
        }

        private void ServeCustomers()
        {
            // TODO: Реализовать логику обслуживания клиента из очереди
            // Использовать свойство клиента для эмуляции времени обслуживания с помощью Thread.Sleep()

            void doWork()
            {
                if (hasCustomer())
                {
                    var person = getCustomer();
                    serveCustomer(person);
                }
                else
                {
                    Console.WriteLine("Waiting...");
                    wait();
                }
            }

            void serveCustomer(Person person)
            {
                if (person != null)
                {
                    Thread.Sleep(person.ProcessingTime);
                    Console.WriteLine($"Обслужили клиента {person.Name}");
                }
            }

            void wait()
            {
                Thread.Sleep(IdleTime);
            }

            bool hasCustomer()
            {
                // синхронизация == БЛОКИРОВКА

                // 3
                // 2
                // 0

                return _peopleQueue.Count() > 0;
            }

            Person getCustomer()
            {
                // Синхронизация

                //1:Dequeue
                //2:              Dequeue
                //3:                     Dequeue

                //4:       Enqueue
                //5:                             Enqueue
                //6:                                    Enqueue

                lock (_peopleQueue)
                {
                    _peopleQueue.TryDequeue(out var person);

                    return person;

                    // Monitor.Enter(_peopleQueue); == Wait();

                    // Dequeue/Enqueue

                    // Monitor.Exit(_peopleQueue)
                }

                // Потокобезопасность

                // Enqueue
                // Dequeue
            }

            bool isOpened()
            {
                return _isOpened;
            }

            while (isOpened() || hasCustomer())
            {
                doWork();
            }
        }
    }
}
