namespace Patterns.Behavioral
{
    public interface IStrategy
    {
        void Apply();
    }

    enum Aggregation
    {
        Sum,
        Count,
        Avg
    }

    // SumComonent/CountComponent/AvgComponent/Median

    internal class Component
    {
        IStrategy _strategy;

        Dictionary<Aggregation, Func<int>> _strategies = new Dictionary<Aggregation, Action>
        {
            [Aggregation.Sum] = SumElements,
            [Aggregation.Avg] = AvgElements,
        };

        private int SumElements()
        {

        }

        public Component(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // void DoWork(Action strategy)
        // public void DoWork(IStrategy strategy)
        public void DoWork(Aggregation strategy)
        {
            new int[0].Where(elem => elem % 2 == 0);

            // cell1, cell2, 1
            // cell1, cell2, 2
            // cell3, cell4, 3

            // SUM           6
            // COUNT         3
            // AVG           2

            // logic
            _strategy.Apply();

            if ()
            {
                // Strategy 1                
            }
            else if ()
            {
                // Strategy 2
            }
            else
            {
                // Stragegy 3
            }

            // logic
        }
    }
}
