using System.Reflection;

internal class Program
{
    public interface IMovable
    {
        void Start();
        void Stop();
    }
    private static void Main(string[] args)
    {
        Car BMW = new Car(10, 230, 60000, "X6", "BMW");
        Car AlfaRomeo = new Car(5, 230, 80000, "Stelvio", "Alfa Romeo");
        Car Audi = new Car(2, 250, 74000, "А7", "Audi");

        Motorcycle BMWF = new Motorcycle(3, 300, 40000, "F 800 ST", "BMW");
        Motorcycle Yamaha = new Motorcycle(3, 310, 46000, "YZF-R1 2020", "Yamaha");

        Truck Volvo = new Truck(7, 130, 100000, "FH16", "Volvo");

        Console.WriteLine("Выберите свое средство передвижения:");
        Console.WriteLine("1 - BMW X6, 2 - Alfa Romeo Stelvio, 3 - Audi F7, 4 - BMW F 800 ST, 5 - Yamaha YZF-R1 2020, 6 - Volvo FH16");
        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                BMW.GetInfo();
                break;
            case "2":
                AlfaRomeo.GetInfo();
                break;
            case "3":
                Audi.GetInfo();
                break;
            case "4":
                BMWF.GetInfo();
                break;
            case "5":
                Yamaha.GetInfo();
                break;
            case "6":
                Volvo.GetInfo();
                break;
            default:
                Console.WriteLine("Ввели неправильное значение.");
                break;
        };
    }
    internal abstract class Vehicle : IMovable
    {
        protected int _currentSpeed;
        protected Vehicle(int year, int maxSpeed,int price, string model, string make)
        {
            Year = year;
            MaxSpeed = maxSpeed;
            Price = price;
            Model = model;
            Make = make;
        }
        string Make { get; } // Производитель
        string Model { get; } // Модель
        int Year { get; } // Год выпуска
        int MaxSpeed { get; } //Максимальная скорость
        int Price { get; } // Цена
        public abstract void Start();
        public virtual void Stop()
        {
            _currentSpeed = 0;
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"Средство передвижения:{Model}, производитель:{Make}, Цена: {Price}, Максимальная скорость: {MaxSpeed}, Год выпуска: {Year}");
        }
        public virtual void GetInfoLittle()
        {
            Console.WriteLine($"Средство передвижения:{Model}, производитель:{Make}, Максимальная скорость: {MaxSpeed}");
        }
        public virtual void State()
        {
            GetInfoLittle();
            Console.WriteLine($"Скорость: {_currentSpeed}");
        }

    }
    internal class Car : Vehicle
    {
        public Car(int year, int maxSpeed, int price, string model, string make) : base(year, maxSpeed, price, model, make)
        {
        }
        public override void Start()
        {
            _currentSpeed = 20; // устанавливаем скорость движения
        }
    }

    internal class Truck : Vehicle
    {
        public Truck(int year, int maxSpeed, int price, string model, string make) : base(year, maxSpeed, price, model, make)
        {
        }
        public override void Start()
        {
            _currentSpeed = 15; // устанавливаем скорость движения
        }
    }

    internal class Motorcycle : Vehicle
    {
        public Motorcycle(int year, int maxSpeed, int price, string model, string make) : base(year, maxSpeed, price, model, make)
        {
        }
        private bool _tripodEjected;
        public override void Start()
        {
            _currentSpeed = 25; // устанавливаем скорость движения
            _tripodEjected = false;
        }
        public override void Stop()
        {
            base.Stop(); // сбрасываем скорость движения
            _tripodEjected = true;
        }
        public override void State()
        {
            Console.WriteLine($"Скорость: {_currentSpeed}, Подножка выставлена: {_tripodEjected}");
        }
    }
}