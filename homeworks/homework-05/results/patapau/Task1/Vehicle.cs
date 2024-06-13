namespace patapau.Task1
{

    internal abstract class Vehicle : IMovable, IFuelable
    {
        protected int _currentSpeed;

        protected double _currentFuelLevel;

        protected double _lastRefuelFuel; //Информация о кол-ве заправленного топлива
        protected Vehicle(string year1, string model1, string make1, double tank1, double currentFuelLevel1)
        {
            Year = year1;
            Model = model1;
            Make = make1;
            Tank = tank1;
            _currentFuelLevel = currentFuelLevel1;
    }
        internal string Make { get; } // Производитель
        internal string Model { get; } // Модель
        internal string Year { get; } //Год выпуска
        internal double Tank { get; }// объем бака
        public abstract void Start();
        public abstract string GetLastRefuelInfo();
       
        public virtual void Stop()
        {
            _currentSpeed = 0;
        }
        public double GetCurrentSpeed()
        {
            return _currentSpeed;
        }

        public virtual void RefuelHalfTank()
        {
            if (_currentSpeed > 0)
            {
                _lastRefuelFuel = 0;
                throw new InvalidOperationException("Нельзя заправляться в движении!");
            }

            if (_currentFuelLevel > Tank / 2)
            {
                _lastRefuelFuel = 0;
                throw new InvalidOperationException("Нельзя заправить больше, чем объем бака!");
            }
            _currentFuelLevel += Tank / 2;
            _lastRefuelFuel = Tank / 2;
        }

        public virtual void RefuelFullTank()//заправляем до полного бака
        {
            if (_currentSpeed > 0)
            {
                _lastRefuelFuel = 0;
                throw new InvalidOperationException("Нельзя заправляться в движении!");
            }
            if (_currentFuelLevel == Tank)
            {
                _lastRefuelFuel = 0;
                throw new InvalidOperationException("Бак полон!");
            }
            _lastRefuelFuel = Tank - _currentFuelLevel;
            _currentFuelLevel = Tank;
        }

        public double GetCurrentFuelLevel()
        {
            return _currentFuelLevel;
        }


    }
}
