

namespace Homework5
{

    public interface IMovable
    {
        void Start();
        void Stop();
    }

    internal class Vehicle : IMovable, IHaveEngine
    {
        protected int CurrentSpeed;

        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public abstract void Start();

        public virtual void Stop()
        {
            CurrentSpeed = 0;
        }
    }

    class Motorcycle : Vehicle
    {
        private bool _tripodEjected;

        override void Start()
        {
            СurrentSpeed = 50;
        }

        override void Stop()
        {
            base.Stop();
            _tripodEjected = true;
        }
    }

    class Car : Vehicle
    {
        override void Start()
        {


            СurrentSpeed = 10;
        }
    }

    class Truck : Vehicle
    {
        override void Start()
        {
            СurrentSpeed = 5;
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}