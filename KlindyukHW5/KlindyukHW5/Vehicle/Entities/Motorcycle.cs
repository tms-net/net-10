namespace KlindyukHW5.Vehicle.Entities
{
    internal class Motorcycle : Vehicle
    {
        private bool _tripodEjected;

        public Motorcycle(int Year, string Make, string Model) : base(Year, Make, Model)
        {
        }

        public override void Start()
        {
            CurrentSpeed = 150;
        }

        public override void Stop()
        {
            base.Stop();
            _tripodEjected = true;
        }
    }
}
