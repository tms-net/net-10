
abstract class Vehicle
{
    string Mark { get; set; }
    string Model { get; set; }
    string Year { get; set; }
   protected abstract void Start();//без protected выбивает ошибку
   protected abstract void Stop();
}

