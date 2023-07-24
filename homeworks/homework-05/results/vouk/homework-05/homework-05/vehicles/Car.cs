using homework_05.interfaces;

namespace homework_05.vehicles 
{
    class Car : VehicleWithEngineBase
    {
        public int SittingPlacesCount { get; }
        public int Test { get; }

        public Car(string mark, string model, string year, int horsepower, int maxSpeed, int sittingPlacesCount) : base(mark, model, year, horsepower, maxSpeed)
        {
            SittingPlacesCount = sittingPlacesCount;
        }
    }
}