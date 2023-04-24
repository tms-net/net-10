using System.Collections;

public interface IMovable
{
    void Start();
    void Stop();
}

public abstract class Vehicle : IMovable, IHaveEngine
{
    protected int _currentsped;
    public string Make { get; set; }
    public string Model { get; set; }
    public string yesr { get; set; }
    public int maxspeedkmh { get; set; }
    public virtual void Start()
    {
        throw new NotImplementedException();
    }

    public virtual void Stop()
    {

        _currentsped = 0;
    }

}
