using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.ProductAPI.Models;

public class Product
{
    public Product()
    {
        ProductId = Guid.NewGuid().ToString();
    }

    public string ProductId { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }
    public string CategoryId { get; set; }
    [NotMapped]
    public Category? Category { get; set; }

}
