internal class Truck : Vehicle
{
    private readonly int _boxVolume;
    public Truck(int year, string make, string model, int boxVolume) : base(year, make, model)
    {
        _boxVolume = boxVolume;
    } 
    public override void Start()
    {
        _currentSpeed = 70; // устанавливаем скорость движения
    }
    public override string Info()
    {
        return $"Truck model: {Model}, make {Make}, year: {Year}, Box Volume: {_boxVolume} m^3";
    }
}
