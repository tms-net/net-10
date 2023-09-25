using Lesson_33_Commerce.Models.Data;

namespace Lesson_33_Commerce.Models.Contracts
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public SizeType Size { get; set; }
    }
}
