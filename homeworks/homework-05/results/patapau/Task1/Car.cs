namespace patapau.Task1
{
    internal class Car : Vehicle
    {

        public Car(string year, string model, string make, double tank) : base(year, model, make, tank)
        {

        }
        public override void Start()
        {
            CurrentSpeed = 60;
        }

        public override void HalfTank()
        {
            base.HalfTank();
            Console.WriteLine("Машина заправлена!");
        }

        public override void FullTank()
        {
            base .FullTank();
            Console.WriteLine("Машина заправлена!");
        }
    }
}
