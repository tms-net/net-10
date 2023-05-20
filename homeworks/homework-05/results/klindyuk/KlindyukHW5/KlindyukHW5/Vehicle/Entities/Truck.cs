namespace KlindyukHW5.Vehicle.Entities
{
    internal class Truck : Car
    {
        public int Capacity { get; }

        public Truck(int year, string make, string model, string type, int capacity) : base(year, make, model, type)
        {
            this.Capacity = capacity;
        }

        public override void Start()
        {
            CurrentSpeed = 60;
        }

        public override void Stop()
        {
            base.Stop();
        }

        public override string ToString()
        {
            return base.ToString() + "Capatiy: " + Capacity + "\n";
        }

    }
}
