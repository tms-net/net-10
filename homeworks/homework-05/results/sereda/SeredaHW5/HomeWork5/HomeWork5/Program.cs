
public interface IMovable
{
    void Start();
    void Stop();
}

public interface HaveEngine
{
    void OnEngine();
    void OffEngine();
}

internal class Vehicle : IMovable, HaveEngine
{
    //private readonly int year
    protected int CurrentSpeed;

    public string Mark { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public virtual void Start()
    {
        OnEngine();
    }
    public virtual void Stop()
    {
        OffEngine();
    CurrentSpeed = 0;
    }
}

//конкретные сущности
public class Car: Vehicle 
{
    override void Start ()
    {
        CurrentSpeed = 100;
    }
}

public class Truck: Vehicle
{
    override void Start()
    {
        CurrentSpeed = 10;
    }


}

internal class Motorcycle: Vehicle
{
    private bool TripodEjected;
    override void Start()
    {
        CurrentSpeed = 200;
    }

    override void Stop()
    {
        base.Stop();
        TripodEjected = true;

    }
}




