namespace KlindyukHW5.Vehicle.Entities
{
    internal class Car : Vehicle
    {
        private bool _handbrake;
        private string Type { get; }

        public Car(int Year, string Make, string Model, string Type) : base(Year, Make, Model)
        {
            this.Type = Type;
        }

        public override void Start()
        {
            CurrentSpeed = 90;
        }

        public override void Stop()
        {
            base.Stop();
            _handbrake = true;
        }

        public override string ToString()
        {
            return base.ToString() + "Type: " + Type;
        }
    }
}
