namespace patapau.Task1
{
    internal class Motorcycle : Vehicle
    {
        private bool _tripodEjected;
        public Motorcycle(string year, string model, string make, double tank, double currentfuellevel) : base(year, model, make, tank, currentfuellevel)
        {

        }

        public override string GetLastRefuelInfo()
        {
            string _information;
            if (_lastRefuelFuel == 0)
            {
                _information = "Мотоцикл не был заправлен";
            }
            else
            {
                _information = $"Мотоцикл был заправлен на {_lastRefuelFuel} литров. Текущий уровень топлива {_currentFuelLevel}";
            }
            return _information;
        }

        public override void Start()
        {
            _currentSpeed = 80;
        }

        public override void Stop()
        {
            base.Stop();
            _tripodEjected = true;
        }

    }
}
