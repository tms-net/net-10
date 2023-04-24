internal class Motorcycle : Vehicle
{
    public bool _tripodejected;
    public override void Start()
    {
        _currentspeed = 60;
        throw new NotImplementedException();
    }
    public override void Stop()
    {
     
        base.Stop();
        _tripodejected = true;
        throw new NotImplementedException();
    }
}