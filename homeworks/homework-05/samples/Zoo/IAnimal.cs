namespace Zookeeper
{
    public interface IAnimal
    {
        string Speak();
    }

    // public
    // private
    // internal
    // protected

    // classes
    // libraries

    public interface IVegan
    {
        string EatVegetables();
    }

    public abstract class Animal
    {
        private int _distance;

        protected virtual int Move()
        {
            return 1;
        }

        protected abstract void Sleep();

        void GoHome()
        {
            Move();
            Move();
        }
    }

    //public class Turtle : Animal
    //{
    //    protected override int Move()
    //    {
    //        return base.Move();
    //    }
    //}

    public class Dog : Animal
    {
        protected override void Sleep()
        {
            throw new NotImplementedException();
        }
    }

    class Lion : Cat
    {
        public string Speak()
        {
            return "RRR";
        }
    }

    public class Cat : Animal, IAnimal, IVegan
    {
        public string Speak()
        {
            return "Meow";
        }

        internal int Jump()
        {
            return 5;
        }

        public int Jump(int height)
        {
            return height;
        }

        protected override void Sleep()
        {
            throw new NotImplementedException();
        }
    }
}
