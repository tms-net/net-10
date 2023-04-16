namespace KlindyukHW5.Vehicle.Entities
{
    internal class Truck : Vehicle
    {
        private int Capacity { get; }
        private bool _handbrake;

        public Truck(int Year, string Make, string Model, int Capacity) : base(Year, Make, Model)
        {
            this.Capacity = Capacity;
        }

        public override void Start()
        {
            CurrentSpeed = 60;
        }

        public override void Stop()
        {
            base.Stop();
            _handbrake = true;
        }

        public override string ToString()
        {
            return base.ToString() + "Capatiy: " + Capacity + "\n";
        }

    }
}
