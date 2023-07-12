using homework_5.interfaces;

internal abstract class Vehicle : IMovable
{
    protected int _currentSpeed;
    public string Make { get; set; } // Производитель
    public string Model { get; set; } // Модель
    public int Year { get; } // Год выпуска

    protected Vehicle(int year, string make, string model)
    {
        Year = year;
        Make = make;
        Model = model;
    }
    
    public abstract void Start();

    public virtual void Stop()
    {
        _currentSpeed = 0;
    }

    public virtual string Info()
    {
        return $"Vehicle model: {Model}, make {Make}, year: {Year}";
    }
}
