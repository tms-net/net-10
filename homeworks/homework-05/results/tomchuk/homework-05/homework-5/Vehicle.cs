using System;

internal abstract class Vehicle
{
	public Vehicle()
	{
	
	}

    string Make { get; set; } // Производитель
    string Model { get; set; } // Модель
    string Year { get; set; } // Год выпуска

    public abstract void Start();
    public abstract void Stop();
}
