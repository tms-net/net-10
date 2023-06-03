namespace ShopSimulator
{
    public class Shop
    {
        private Thread[] _cahierThreads;
        private Queue<Person> _peopleQueue; // Эмуляция очереди клиентов
        static SemaphoreSlim _sem = new SemaphoreSlim(3);

        public delegate void MethodContainer();
        public event MethodContainer _action;

        public Shop(int cahierCount)
        {
            _peopleQueue = new Queue<Person>();
            _cahierThreads = new Thread[cahierCount];
            _action += ServeCustomer;
            for (int i = 0; i < cahierCount; i++)
            {
                _cahierThreads[i] = new Thread(ServeCustomer);
            }
        }

        public void Open()
        {
            Array.ForEach(_cahierThreads, thread => thread.Start());

            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cahierThreads.Length} касс(ы)");
        }

        public void Enter(Person person)
        {
            // TODO: Реализовать логику постановки клиента в очередь

            Console.WriteLine($"{person.Name} вошел в магазин");

            _peopleQueue.Enqueue(person);
            _action();
        }
        public void Close()
        {
            // TODO: Реализовать гарантированное обслуживание всех клиентов после закрытия
            if (_peopleQueue.Count == 0)
            {
                Console.WriteLine("Клиентов нет. Магазин закрыт");
            }
            else { Console.WriteLine($"В магазине осталось {_peopleQueue.Count} клиентов") ; }
        }

        private void ServeCustomer()
        {
            // TODO: Реализовать логику обслуживания клиента из очереди
            // Использовать свойство клиента для эмуляции времени обслуживания с помощью Thread.Sleep()
            
            var rnd = new Random();
            var ProductBag = rnd.Next(1, 4);
             _sem.Wait();
                if (_peopleQueue.Count > 0)
                {
                    var klient = _peopleQueue.Peek();
                    switch (ProductBag)
                    {
                        case 1:
                            Console.WriteLine($"Клиент {klient.Name} купил маленькую корзину продуктов");
                            Thread.Sleep(klient.ProcessingTime);
                            break;
                        case 2:
                            Console.WriteLine($"Клиент {klient.Name} купил среднюю корзину продуктов");
                            Thread.Sleep(klient.ProcessingTime);
                            break;
                        case 3:
                            Console.WriteLine($"Клиент {klient.Name} купил большую корзину продуктов");
                            Thread.Sleep(klient.ProcessingTime);
                            break;
                    }
                    _peopleQueue.Dequeue();
                }

                _sem.Release();
        }
    }
}
