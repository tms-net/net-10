using homework_05.interfaces;

namespace homework_05.vehicles
{
    class Truck : VehicleWithEngineBase
    {
        private int _maxWeight;

        public Truck(string mark, string model, string year, int horsepower, int maxSpeed, int maxWeight) : base(mark, model, year, maxSpeed, horsepower)
        {
            _maxWeight = maxWeight;
        }
    }
}