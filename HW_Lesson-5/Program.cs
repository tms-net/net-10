internal class Program
{
    public interface IMovable
    {
        void Start();
        void Stop();
    }
    private static void Main(string[] args)
    {

    }
    internal abstract class Vehicle : IMovable
    {
        protected int _currentSpeed;
        protected Vehicle(int year)
        {
            Year = year;
        }
        string Make { get; set; } // Производитель
        string Model { get; set; } // Модель
        int Year { get; } // Год выпуска
        public abstract void Start();
        public virtual void Stop()
        {
            _currentSpeed = 0;
        }

    }
    internal class Car : Vehicle
    {
        public Car(int year) : base(year)
        {
        }
        public override void Start()
        {
            _currentSpeed = 20; // устанавливаем скорость движения
        }
    }

    internal class Truck : Vehicle
    {
        public Truck(int year) : base(year)
        {
        }
        public override void Start()
        {
            _currentSpeed = 15; // устанавливаем скорость движения
        }
    }

    internal class Motorcycle : Vehicle
    {
        public Motorcycle(int year) : base(year)
        {
        }
        private bool _tripodEjected;
        public override void Start()
        {
            _currentSpeed = 25; // устанавливаем скорость движения
        }
        public override void Stop()
        {
            base.Stop(); // сбрасываем скорость движения
            _tripodEjected = true;
        }
    }
}