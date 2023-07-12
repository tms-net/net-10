namespace Patterns.Behavioral
{
    // Подписка

    // Вызов

    internal class Observer
    {
        public event Action OnCompleted;

        public void Complete()
        {
            OnCompleted?.Invoke();
        }
    }

    internal class CustomObserver
    {
        Dictionary<string, List<Action>> _listeners = new Dictionary<string, List<Action>>();

        // Subscribe
        public void AddEventListener(object owner, string evt, Action listener)
        {
            _listeners[evt].Add(listener);
        }

        // Publish
        // Notify
        public void FireEvent(object owner, string evt)
        {
            foreach(var listener in _listeners[evt])
            {
                listener.Invoke();
            }
        }
    }

    class ObserverProgram
    {
        void Main()
        {
            var observer = new Observer();
            observer.OnCompleted += Observer_OnCompleted;
            observer.Complete();


            var customObserver = new CustomObserver();
            var data1 = "Data 1";
            var data2 = "Data 2";
            customObserver.AddEventListener(null, "OnCompleted", () => Console.WriteLine(data1));
            customObserver.AddEventListener(null, "OnCompleted", () => Console.WriteLine(data2));

            customObserver.FireEvent(null, "OnCompleted");
        }

        private void Observer_OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
