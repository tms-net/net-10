namespace Homework_5_Lutynski
{
    public interface IGarbageTruck
    {
        void GrabGarbageBin();
    }
    public interface IMovable
    {
        void Start();
        void Stop();
    }
    internal abstract class Vehicle : IMovable, IGarbageTruck
    {
        public int _currentSpeed;
        protected Vehicle(string year, string maker, string model)
        {
            Year = year;
            Model = model;
            Maker = maker;
        }
        string Maker { get; }
        string Model { get; }
        string Year { get; }

        public void GrabGarbageBin()
        {
            throw new NotImplementedException();
        }

        public abstract void Start();
        public virtual void Stop()
        {
            _currentSpeed = 0;
        }

    }
    class Car : Vehicle
    {
        public Car(string year, string maker, string model) : base(year, maker, model)
        {

        }
        public override void Start()
        {
            _currentSpeed = 10;
        }


    }
    class Truck : Vehicle
    {
        public Truck(string year, string maker, string model) : base(year, maker, model)
        {

        }


        public override void Start()
        {
            _currentSpeed = 7;
        }
    }
    class Motorcycle : Vehicle
    {
        private bool _TripodEjected;
        public Motorcycle(string year, string maker, string model) : base(year, maker, model)
        {

        }
        public override void Start()
        {
            _currentSpeed = 15;
        }
        public override void Stop()
        {
            base.Stop();
            _TripodEjected = true;
        }

    }
    
}