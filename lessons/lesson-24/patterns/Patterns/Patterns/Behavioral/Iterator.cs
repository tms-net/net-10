namespace Patterns.Behavioral
{
    internal class Iterator<T> : IEnumerable<T>
    {
    }

    public class IteratorProgram
    {

        public void Main()
        {
            foreach (var item in collection)
            {
                Handle(item);
            }

            var iterator = enumerable.GetEnumerator();
            while (iterator.MoveNext())
            {
                Handle(iterator.Current);
            }

            GetNumbers().Sum();
        }

        IEnumerable<int> GetNumbers()
        {
            yield return 1;

            yield return 2;

            yield return 3;

            yield return 4;
        }
    }
}
