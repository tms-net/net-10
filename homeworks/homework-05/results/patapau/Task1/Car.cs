namespace patapau.Task1
{
    internal class Car : Vehicle
    {

        public Car(string year, string model, string make, double tank, double currentfuellevel) : base(year, model, make, tank, currentfuellevel)
        {

        }

        public override string GetLastRefuelInfo()
        {
            string _information;
            if (_lastRefuelFuel == 0)
            {
                _information = "Машина не была заправлена";
            }
            else
            {
                _information = $"Машина была заправлена на {_lastRefuelFuel} литров. Текущий уровень топлива {_currentFuelLevel}";
            }
            return _information;
        }

        public override void Start()
        {
            _currentSpeed = 60;
        }
        
    }
}
