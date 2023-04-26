internal class Truck : Vehicle
{
    private bool _tripodEjected;

    public Truck(int year, string make, string model) : base(year, make, model)
    { } 
    public override void Start()
    {
        _currentSpeed = 70; // устанавливаем скорость движения
    }

    public override void Stop()
    {
        base.Stop(); // сбрасываем скорость движения
        _tripodEjected = false;
    }
    public override string Info()
    {
        return $"Truck model: {Model}, make {Make}, year: {Year}";
    }
}