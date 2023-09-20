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

        public Category Category { get; set; }
    }

    [NotMapped]
    public class ProductInfo
    {

    }

}
