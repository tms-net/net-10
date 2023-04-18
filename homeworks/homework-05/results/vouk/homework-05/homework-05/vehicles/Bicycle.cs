using System.Dynamic;

namespace homework_05.vehicles
{
    class Bicycle : VehicleBase
    {
        public int BicycleWeight { get; }
        
        public Bicycle(string mark, string model, string year, int horsepower, int bicycleWeight, int maxSpeed) : base(mark, model, year, horsepower, maxSpeed)
        {
            BicycleWeight = bicycleWeight;
        }
    }
}
