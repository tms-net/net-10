using homework_05.interfaces;

namespace homework_05.vehicles
{
    internal abstract class VehicleBase : IMovable
    {
        protected int CurrentSpeed;
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int MaxSpeed { get; }

        protected VehicleBase(string mark, string model, string year, int horsepower, int maxSpeed)
        {
            CurrentSpeed = 0;
            Mark = mark;
            Model = model;
            Year = year;
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            var stringValue =
                @$" Vehicle type: {GetType().Name}
                    Vehicle mark: {Mark}
                    Vehicle model: {Model}
                    Vehicle creation year: {Year}
<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";

            return stringValue;
        }

        public string GetCurrentStateOfVehicle()
        {
            var stringValue =
                @$"Current {GetType().Name} speed: {CurrentSpeed}
<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";

            return stringValue;
        }

        public void IncreaseSpeed(int speedValue)
        {
            var newSpeed = CurrentSpeed + speedValue;
            CurrentSpeed = newSpeed > MaxSpeed ? MaxSpeed : newSpeed;
        }

        public void DecreaseSpeed(int speedValue)
        {
            var newSpeed = CurrentSpeed - speedValue;
            CurrentSpeed = newSpeed < 0 ? 0 : newSpeed;
        }
    }
}