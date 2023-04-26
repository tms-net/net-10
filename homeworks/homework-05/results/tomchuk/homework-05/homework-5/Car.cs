internal class Car : Vehicle
{
    private bool _tripodEjected;

    public Car(int year, string make, string model) : base(year, make, model)
    { }

    public override void Start()
    {
        _currentSpeed = 90; // устанавливаем скорость движения
    }

    public override void Stop()
    {
        base.Stop(); // сбрасываем скорость движения
        _tripodEjected = false;
    }

    public override string Info()
    {
        return $"Car model: {Model}, make {Make}, year: {Year}";
    }
}