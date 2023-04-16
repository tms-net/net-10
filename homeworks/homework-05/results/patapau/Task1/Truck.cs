namespace patapau.Task1
{
    internal class Truck : Vehicle
    {
        public Truck(string year, string model, string make, double tank) : base(year, model, make, tank)
        {

        }
        public override void Start()
        {
            CurrentSpeed = 50;
        }
        public override void HalfTank()
        {
            base.HalfTank();
            Console.WriteLine("Грузовик заправлен!");
        }
        public override void FullTank()
        {
            base.FullTank();
            Console.WriteLine("Грузовик заправлен!");
        }
    }
}
