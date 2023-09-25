namespace Lesson_33_Commerce.Models.Data
{
    public class Tag
    {
        public int Id { get; set; }

        public string TagName { get; set; }

        public List<Product> Products { get; set; }
    }
}
