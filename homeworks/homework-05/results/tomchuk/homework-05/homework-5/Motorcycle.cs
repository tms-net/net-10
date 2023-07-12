internal class Motorcycle : Vehicle
{
    private bool _tripodEjected;
    private int _weight;

    public Motorcycle(int year, string make, string model, int weight) : base(year, make, model)
    {
        Make = make; 
        Model = model;
        _weight = weight;
    }

    public override void Start()
    {
        _currentSpeed = 50; // устанавливаем скорость движения
    }
    public override void Stop()
    {
        base.Stop(); // сбрасываем скорость движения
        _tripodEjected = true;
    }
    public override string Info()
    {
        return $"Motorcycle model: {Model}, make {Make}, year: {Year}, weight: {_weight}";
    }
}
