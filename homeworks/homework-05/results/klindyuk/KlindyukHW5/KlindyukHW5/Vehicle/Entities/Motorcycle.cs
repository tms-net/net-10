namespace KlindyukHW5.Vehicle.Entities
{
    internal class Motorcycle : Vehicle
    {
        private bool _tripodEjected = true;

        public Motorcycle(int year, string make, string model) : base(year, make, model)
        {
        }

        public override void Start()
        {
            _tripodEjected = false;
            CurrentSpeed = 150;
        }

        public override void Stop()
        {
            base.Stop();
            _tripodEjected = true;
        }
    }
}
