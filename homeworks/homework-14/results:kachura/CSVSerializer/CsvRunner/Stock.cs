namespace CsvRunner
{
    public class Stock
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int[] Indexes { get; init; } = Array.Empty<int>();

        public Stock()
        {

        }

        public Stock(string symbol)
        {
            Symbol = symbol;
        }

        public override string ToString()
        {
            string indexes = string.Empty;

            if(Indexes.Length > 0)
            {
                foreach (int index in Indexes)
                {
                    indexes += $" {index}, ";
                }

                indexes.Remove(indexes.Length - 1);
            }
            else
            {
                indexes = string.Empty;
            }

            return Symbol + " - " + Price + indexes + " " + Date;
        }
    }
}