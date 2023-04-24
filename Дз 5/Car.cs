public class Car : Vehicle
{
    public override void Start()
    {
        _currentspeed = 20;
        throw new NotImplementedException();
    }
    public override void Stop()
    {
        _currentsped = 0;
        throw new NotImplementedException();
    
    }
}