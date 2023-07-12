internal class Car : Vehicle
{

    public Car(int year, string make, string model) : base(year, make, model)
    { }

    public override void Start()
    {
        _currentSpeed = 90; // устанавливаем скорость движения
    }

    public override string Info()
    {
        return $"Car model: {Model}, make {Make}, year: {Year}";
    }
}
