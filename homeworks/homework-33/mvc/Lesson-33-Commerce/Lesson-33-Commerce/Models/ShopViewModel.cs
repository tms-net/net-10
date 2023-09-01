namespace Lesson_33_Commerce.Models
{
    public class ShopViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<ProductInfo> Products { get; set; }
    }

    public class ProductInfo
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }


        // public string ProductUrl { get; set; }

        public string Id { get; set; }

        public string ImageUrl { get; set; }
    }
}
