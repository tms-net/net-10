using System.Collections;

public interface IMovable
{
    void Start();
    void Stop();
}
public abstract class Vehicle : IMovable, IHaveEngine
{
    protected int _currentspeed;
    public string Make { get; set; }
    public string Model { get; set; }
    public string color { get; set; }
    public string year { get; }
    public int maxspeedkmh { get; set; }     
    //protected Vehicle()
    //{
    //    year = year;
    //}
    public virtual void Start()
    {
        throw new NotImplementedException();
    }

    public virtual void Stop()
    {
        _currentspeed = 0;
    }

}
public class Car : Vehicle
{  
    //public Car(int year) : base(year)
    //{
    //}
    public override void Start()
    {
        _currentspeed = 20;
        throw new NotImplementedException();
    }
    public override void Stop()
    {
        _currentspeed = 0;
        throw new NotImplementedException();
    }
}
class Truck : Vehicle
{
    public override void Start()
    {
        _currentspeed = 10;
        throw new NotImplementedException();
    }
    public override void Stop()
    {
        _currentspeed = 0;
        throw new NotImplementedException();
    }
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

