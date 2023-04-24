class Truck : Vehicle
{
    public override void Start()
    {
        _currentspeed = 40;
        throw new NotImplementedException();
    }
    public override void Stop()
    {
        _currentspeed = 0;
        throw new NotImplementedException();
    }

    internal class Motorcycle : Vehicle
    {
        public bool _tripodejected;
        public override void Start()
        {
            _currentspeed = 30;
            throw new NotImplementedException();
        }
        public override void Stop()
        {
            //_currentspeed = 0;
            base.Stop();
            _tripodejected = true;
            throw new NotImplementedException();
        }
    }