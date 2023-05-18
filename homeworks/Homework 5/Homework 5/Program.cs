Car car = new Car(
    year: "2023",
    make: "BMW",
    model: "666",
    numberOfDoors: 2);
car.OpenDoor(1);
car.CloseDoor(1);
car.Start();


internal abstract class Vehicle : IMovable, IRefuel
{
    protected int CurrentSpeed;
    protected int MaxFuelLevel;
    protected int CurrentFuelLevel;
    private bool _isFuelCapOpen;
    private readonly int _year;
    protected bool[] _isDoorOpen;

    public string Make { get; }
    public string Model { get; }
    public string Year { get; }

    protected Vehicle (string year, string make, string model, int numberOfDoors = 0)
    {
        Year = year;
        Make = make;
        Model = model;

        if(numberOfDoors > 0)
        {
            _isDoorOpen = new bool[numberOfDoors];
        }
        else
        {
            _isDoorOpen = new bool[0];
        }
    }

    public abstract void Start();

    public virtual void Stop()
    {
        CurrentSpeed = 0;
    }

    private void OpenFuelCap()
    {
        _isFuelCapOpen = true;
    }

    private void CloseFuelCap()
    {
        _isFuelCapOpen = false;
    }

    public void Refuel()
    {
        OpenFuelCap();
        CurrentFuelLevel = MaxFuelLevel;
        CloseFuelCap();
    }
}

interface IMovable
{
    void Start();
    void Stop();
}

interface IHaveDoors
{
    void OpenDoor(int doorId);
    void CloseDoor(int doorId);
}

interface IHaveHood
{    
    void OpenHood();
    void CloseHood();
}

interface IHaveTrunk
{
    void OpenTrunk();
    void CloseTrunk();
}

interface IRefuel
{
    void Refuel();
}

internal class Car : Vehicle, IHaveDoors, IHaveHood, IHaveTrunk
{
    bool _isHoodOpen;
    bool _isTrunkOpen;

    public Car(string year, string make, string model, int numberOfDoors) : base(year, make, model, numberOfDoors)
    {

    }

    public void OpenDoor(int doorId)
    {
        if(doorId < _isDoorOpen.Length && CurrentSpeed == 0)
        {
            _isDoorOpen[doorId] = true;
        }
    }

    public void CloseDoor(int doorId)
    {
        if(doorId < _isDoorOpen.Length && CurrentSpeed == 0)
        {
            _isDoorOpen[doorId] = false;
        }
    }

    public void OpenHood()
    {
        _isHoodOpen = true;
    }

    public void CloseHood()
    {
        _isHoodOpen = false;
    }

    public void OpenTrunk()
    {
        _isTrunkOpen = true;
    }

    public void CloseTrunk()
    {
        _isTrunkOpen = false;
    }

    public override void Start()
    {
        CurrentSpeed = 10;
    }
}

internal class Truck : Car
{
    bool _isHoodOpen;

    public Truck(string year, string make, string model, int numberOfDoors) : base(year, make, model, numberOfDoors)
    {

    }

    public override void Start()
    {
        CurrentSpeed = 8;
    }
}

internal class Motorcycle : Vehicle
{
    private bool _tripodEjected;

    public Motorcycle(string year, string make, string model) : base(year, make, model)
    {

    }

    public override void Start()
    {
        CurrentSpeed = 50;
    }

    public override void Stop()
    {
        base.Stop();
        _tripodEjected = true;
    }
}