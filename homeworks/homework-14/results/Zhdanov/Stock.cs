using CsvSerializer;
using CcvSerializer;

namespace CsvSerializer.Example
{
    [CsvHeader("Symbol,Price,Volume")]
    public class Stock
    {
        public string? Symbol { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
    }
}