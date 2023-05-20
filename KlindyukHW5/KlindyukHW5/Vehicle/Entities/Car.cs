namespace KlindyukHW5.Vehicle.Entities
{
    internal class Car : Vehicle
    {
        private bool _handbrake = true;
        public string Type { get; }

        public Car(int year, string make, string model, string type) : base(year, make, model)
        {
            this.Type = type;
        }

        public override void Start()
        {
            _handbrake = false;
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
