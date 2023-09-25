using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson_33_Commerce.Models.Data
{
    // DDD - Domain Driven Design
    // Entity
    // GUID - Globally Unique Identificator 2^big
    // Table Products
    // Code First + Migrations (sql server tools / API)
    public class Product // POCO
    {
        // public Guid Id { get; set } = Guid.NewGuid();

        // Column [Id]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [Column("UpdateDate")]
        public DateTime UpdateDate { get; set; }

        // public int CategoryId { get; set; }

        public SizeType Size { get; set; }

        public Category Category { get; set; } // Reference Property

        public ProductDetails Details { get; set; } // Reference Property

        public List<Tag> Tags { get; set; }
    }

    public enum SizeType
    {
        XS,
        S,
        M,
        L,
        XL
    }

    // DDD - Domain Driven Design
    // - Entity
    // - Value Object
    public class ProductDetails
    {
        // public int Id { get; set; }

        // public int ProductId { get; set; }

        // public Product Product { get; set; }

        public string AdditionalDesription { get; set; }
    }

    [NotMapped]
    public class ProductInfo
    {

    }

}
