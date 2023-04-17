namespace patapau.Task1
{

    internal abstract class Vehicle : IMovable, IFuelable
    {
        protected int CurrentSpeed;

        protected double CurrentFuelLevel;
        protected Vehicle(string year, string model, string make, double tank)
        {
            Year = year;
            Model = model;
            Make = make;
            Tank = tank;
        }
        internal string Make { get; set; } // Производитель
        internal string Model { get; set; } // Модель
        internal string Year { get; } //Год выпуска
        internal double Tank { get; }// объем бака
        public abstract void Start();
        public virtual void Stop()
        {
            CurrentSpeed = 0;
        }
        public void GetCurrentSpeed() => Console.WriteLine("Текущая скорость " + CurrentSpeed);

        public virtual void HalfTank()
        {
            Console.WriteLine("Заправлен бак на половину " + Tank/2 + " литров");
            CurrentFuelLevel = Tank/2;
        }

        public virtual void FullTank()
        {
            Console.WriteLine("Заправлен полный бак " + Tank + " литров");
            CurrentFuelLevel = Tank;
        }

        public void GetFuelLevel()
        {
            Console.WriteLine("Текущий уровень топлива " + CurrentFuelLevel);
        }
    }
}
