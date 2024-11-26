using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdanov_hw_16
{
    internal class Shop
    {
        private int cashCount;
        private ConcurrentQueue<Person> queue;
        private bool isOpen;

        public Shop(int cashCount)
        {
            this.cashCount = cashCount;
            queue = new ConcurrentQueue<Person>();
            isOpen = true;
        }

        public void Enter(Person person)
        {
            if (isOpen)
            {
                queue.Enqueue(person);
            }
        }

        public void ServeCustomer()
        {
            while (queue.Count > 0 || isOpen)
            {
                if (queue.TryDequeue(out var person))
                {
                    Thread.Sleep(person.ProcessingTime);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        public void Close()
        {
            isOpen = false;
        }
    }
}
