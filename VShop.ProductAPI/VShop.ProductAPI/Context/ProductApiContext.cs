using Microsoft.EntityFrameworkCore;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.Context;

public class ProductApiContext : DbContext
{
    public ProductApiContext(DbContextOptions<ProductApiContext> options ) : base(options)
    {}
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder mB)
    {
        //products
        mB.Entity<Product>().ToTable("products");
        mB.Entity<Product>()
            .HasKey(p => p.ProductId);
        mB.Entity<Product>()
            .Property(nameof(Product.ProductId))
            .HasMaxLength(50)
            .HasColumnName("PK_product_id");
        mB.Entity<Product>()
            .Property(nameof(Product.Name))
            .HasColumnName("name")
            .IsRequired();
        //by default, the entityframeworkcore set the length of the text to store until 4GB,
        //so we need to reconfigure 
        mB.Entity<Product>()
            .Property(nameof(Product.Stock))
            .HasColumnName("stock")
            .HasDefaultValue(100)
            .IsRequired();
        mB.Entity<Product>()
            .Property(nameof(Product.Description))
            .HasColumnName("description")
            .HasMaxLength(100);
        mB.Entity<Product>()
             .Property(nameof(Product.Price))
             .HasColumnName("price")
             .HasPrecision(12,2)
             .IsRequired();
        mB.Entity<Product>()
            .Property(nameof(Product.CategoryId))
            .HasColumnName("FK_category_id");

        //categories

        mB.Entity<Category>()
            .ToTable("categories");
        mB.Entity<Category>()
            .Property(nameof(Category.CategoryId))
            .HasColumnName("PK_category_id");
        mB.Entity<Category>()
            .HasKey(c => c.CategoryId);
        mB.Entity<Category>()
            .Property(nameof(Category.CategoryName))
            .HasColumnName("category_name")
            .HasMaxLength(20)
            .IsRequired();

        //defining a one to many relationship with the category relation
        mB.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .OnDelete(DeleteBehavior.Cascade);


        //first additions to the category relation
        mB.Entity<Category>()
            .HasData(
                new Category()
                {
                    CategoryName = "Scholar material"
                },
                new Category()
                {
                    CategoryName = "Food"
                },
                new Category()
                {
                    CategoryName = "Clothes"
                }
            );

    }
}
