using homework_05.interfaces;

namespace homework_05.vehicles
{
    class VehicleWithEngineBase : VehicleBase, IHaveEngine
    {
        public int Horsepower { get; set; }
        public bool IsEngineTurnedOn { get; private set; }


        public VehicleWithEngineBase(string mark, string model, string year, int horsepower, int maxSpeed) : base(mark, model, year, horsepower, maxSpeed)
        {
            Horsepower = horsepower;
        }

        public virtual void StartEngine()
        {
            IsEngineTurnedOn = true;
        }

        public void StopEngine()
        {
            CurrentSpeed = 0;
            IsEngineTurnedOn = false;
        }

        public new void IncreaseSpeed(int speedValue)
        {
            if (IsEngineTurnedOn)
            {
                var newSpeed = CurrentSpeed + speedValue;
                CurrentSpeed = newSpeed > MaxSpeed ? MaxSpeed : newSpeed;
            }
        }

        public new void DecreaseSpeed(int speedValue)
        {
            if (IsEngineTurnedOn)
            {
                var newSpeed = CurrentSpeed - speedValue;
                CurrentSpeed = newSpeed < 0 ? 0 : newSpeed;
            }
        }
    }
}
