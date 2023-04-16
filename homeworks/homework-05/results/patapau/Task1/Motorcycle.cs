namespace patapau.Task1
{
    internal class Motorcycle : Vehicle
    {
        private bool _tripodEjected;
        public Motorcycle(string year, string model, string make, double tank) : base(year, model, make, tank)
        {

        }
        public override void Start()
        {
            CurrentSpeed = 80;
        }

        public override void Stop()
        {
            base.Stop();
            _tripodEjected = true;
        }
        public override void HalfTank()
        {
            base.HalfTank();
            Console.WriteLine("Мотоцикл заправлен!");
        }
        public override void FullTank()
        {
            base.FullTank();
            Console.WriteLine("Мотоцикл заправлен!");
        }
    }
}
