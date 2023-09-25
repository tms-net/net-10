namespace Lesson_33_Commerce.Models.Data
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; } // Navigation Property
    }
}
