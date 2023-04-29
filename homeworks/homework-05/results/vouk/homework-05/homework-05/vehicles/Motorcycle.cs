using homework_05.interfaces;

namespace homework_05.vehicles
{
    class Motorcycle : VehicleWithEngineBase
    {
        public bool TripodEjected { get; private set; }

        public Motorcycle(string mark, string model, string year, int horsepower, int maxSpeed) : base(mark, model, year, horsepower, maxSpeed)
        {
        }

        public void StartEngine()
        {
            base.StartEngine();
            TripodEjected = false;
        }

        public void StopEngine()
        {
            base.StopEngine();
            TripodEjected = true;
        }
    }
}