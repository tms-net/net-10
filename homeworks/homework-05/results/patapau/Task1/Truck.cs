namespace patapau.Task1
{
    internal class Truck : Vehicle
    {
        public Truck(string year, string model, string make, double tank, double currentfuellevel) : base(year, model, make, tank, currentfuellevel)
        {

        }

        public override string GetLastRefuelInfo()
        {
            string _information;
            if (_lastRefuelFuel == 0)
            {
                _information = "Грузовик не был заправлен";
            }
            else
            {
                _information = $"Грузовик был заправлен на {_lastRefuelFuel} литров. Текущий уровень топлива {_currentFuelLevel}";
            }
            return _information;
        }

        public override void Start()
        {
            _currentSpeed = 50;
        }

    }
}
