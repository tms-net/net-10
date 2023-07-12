using System.Text;

namespace Patterns
{
    internal class BuilderProgram
    {
        public void Main()
        {
            var builder = new TradingDataRetreiverBuilder();

            // FluentInterface
            var instance =
                builder
                    .WithFile("C:\\file")
                    .WithBuffer(400)
                    .Build();

            var sb = new StringBuilder();
            sb.Append("")
                .AppendLine("");

            sb.ToString();
        }
    }

    public class TradingDataRetreiverBuilder 
    {
        private string _file;
        private int _buffer;

        public TradingDataRetreiverBuilder WithFile(string file)
        {
            _file = file;
            return this;
        }

        public TradingDataRetreiverBuilder WithBuffer(int buffer)
        {
            _buffer = buffer;
            return this;
        }

        public ITradingDataRetreiver Build()
        {
            return new TradingDataRetreiver();
        }
    }
}
