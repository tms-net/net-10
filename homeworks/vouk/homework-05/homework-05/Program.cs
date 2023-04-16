using System.Xml.Linq;

namespace homework_05
{
    internal class Program
    {
        static void Main()
        {
            // Create different vehicle models
            var ducatiStreetfighter = new Motorcycle("Ducati", "Streetfighter V4", "2023", 208);
            var porscheTurbo = new Car("porsche", "911 Turbo", "2022", 640, 2);
            var freightliner = new Truck("Freightliner", "FLA 9664", "1984", 500, 2);

            // Write description of all vehicles
            Console.WriteLine(ducatiStreetfighter);
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine(porscheTurbo);
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine(freightliner);
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            // Turn On engine of bike
            ducatiStreetfighter.Start();
            Console.WriteLine(ducatiStreetfighter.GetCurrentStateOfVehicle());
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            // Turn Off engine of bike
            ducatiStreetfighter.Stop();
            Console.WriteLine(ducatiStreetfighter.GetCurrentStateOfVehicle());
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }
    }

    public interface IMovable
    {
        void Start();
        void Stop();
    }

    public interface IHaveEngine
    {
        void TurnOnEngine();
        void TurnOffEngine();
    }

    internal abstract class Vehicle : IMovable, IHaveEngine
    {
        protected int CurrentSpeed;
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int Horsepower { get; set; }
        private bool IsEngineTurnedOn { get; set; }

        protected Vehicle(string mark, string model, string year, int horsepower)
        {
            CurrentSpeed = 0;
            Mark = mark;
            Model = model;
            Year = year;
            IsEngineTurnedOn = false;
            Horsepower = horsepower;
        }

        public virtual void Start()
        {
            TurnOnEngine();
        }

        public virtual void Stop()
        {
            TurnOffEngine();
            CurrentSpeed = 0;
        }

        public void TurnOnEngine()
        {
            IsEngineTurnedOn = true;
        }

        public void TurnOffEngine()
        {
            IsEngineTurnedOn = false;
        }

        public override string ToString()
        {
            var stringValue =
                @$" Vehicle type: {this.GetType().Name}
                    Vehicle mark: {Mark}
                    Vehicle model: {Model}
                    Vehicle creation year: {Year}
                    Vehicle engine power: {Horsepower}
                    ";

            return stringValue;
        }

        public string GetCurrentStateOfVehicle()
        {
            var stringValue =
                @$" Is {Mark} {Model} engine turned on: {IsEngineTurnedOn}
                    Current vehicle speed: {CurrentSpeed}";

            return stringValue;
        }
    }

    class Motorcycle : Vehicle
    {
        private bool _tripodEjected;

        public Motorcycle(string mark, string model, string year, int horsepower) : base(mark, model, year, horsepower)
        {
        }

        public void Start()
        {
            base.Start();
            CurrentSpeed = 50;
            _tripodEjected = false;
        }

        public void Stop()
        {
            base.Stop();
            _tripodEjected = true;
        }
    }

    class Car : Vehicle
    {
        private int _sittingPlacesCount;

        public Car(string mark, string model, string year, int horsepower, int sittingPlacesCount) : base(mark, model, year, horsepower)
        {
            _sittingPlacesCount = sittingPlacesCount;
        }

        public override void Start()
        {
            base.Start();
            CurrentSpeed = 10;
        }

    }

    class Truck : Vehicle
    {
        private int _maxWeight;

        public Truck(string mark, string model, string year, int horsepower, int maxWeight) : base(mark, model, year, horsepower)
        {
            _maxWeight = maxWeight;
        }

        public override void Start()
        {
            base.Start();
            CurrentSpeed = 5;
        }
    }
}