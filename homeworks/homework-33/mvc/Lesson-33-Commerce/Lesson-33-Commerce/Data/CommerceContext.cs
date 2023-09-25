using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lesson_33_Commerce.Models.Data;

// RDB - Relational Data Bases
// БД - то где хранятся данные
// СУБД - Система Управления ДБ
// RDBMS
// Table

// Id   Name     Price   UpdateDate    Category     
// -------------------------------------------------------------
//  1  | Шорты  | 10.0  |          |  Верхняя   |    |    |    | Row/Record
//  2  | Майка  | 15.0  |          |   Нижняя   |    |    |    |
//  3  | Куртка | 20.0  |          |  Верхняя   |    |    |    |
// -------------------------------------------------------------

// Id   Name     Price   UpdateDate    Category (Foreign_Key)    
// -------------------------------------------------------------
//  1  | Шорты  | 10.0  |          |    1 (FK)  |    |    |    | Row/Record
//  2  | Майка  | 15.0  |          |    2       |    |    |    |
//  3  | Куртка | 20.0  |          |    1       |    |    |    |
// -------------------------------------------------------------

// Category
// Id (PK)   Name          
// ------------------------
//  1     | Верхняя одежда | Row/Record
//  2     | Нижняя         | Delete
// ------------------------


// SQL - Structure Query Language = RDBMS
// DBA - 
public class CommerceContext : DbContext
{
    // Tables/Columns/Rows -> objects

    public CommerceContext (DbContextOptions<CommerceContext> options)
        : base(options)
    {
        // 1. Convensions
        // 2. API
        // 3. Attributes
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mapping
        modelBuilder.Entity<Product>()
                    .ToTable("Products")
                    .Property(x => x.Id)
                    .IsRequired();

        modelBuilder.Entity<Product>(builder =>
        {
            builder.Property(x => x.UpdateDate);
                   //.HasColumnType("time(3)");
        });

        // Add the shadow property to the model
        modelBuilder.Entity<Product>()
            .Property<int>("CategoryId");

        // Add the shadow property to the model
        // modelBuilder.Entity<ProductDetails>()
            //.Property<int>("ProductId");

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey("CategoryId");
            //.HasForeignKey(p => p.CategoryId);

        //modelBuilder.Entity<Product>()
        //    .HasOne(p => p.Details)
        //    .WithOne(pd => pd.Product)
        //    .HasForeignKey("ProductId");

        modelBuilder.Entity<Product>()
            .Property(p => p.Details)
            .HasConversion(
                v => System.Text.Json.JsonSerializer.Serialize(v, typeof(ProductDetails), new System.Text.Json.JsonSerializerOptions()),
                v => System.Text.Json.JsonSerializer.Deserialize<ProductDetails>(v, new System.Text.Json.JsonSerializerOptions()));

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Tags)
            .WithMany(t => t.Products)
            .UsingEntity(j => j.ToTable("HomeworkTag"));
    }

    public DbSet<Product> Products { get; set; } = default!;

    public DbSet<Category> Categories { get; set; } = default!;

    // Model First -> EF works with DB -> db generation -> DB seed (Migrations)

    // Mapping/Designer

    // DB First -> Models according to DB structure -> model generation
}
