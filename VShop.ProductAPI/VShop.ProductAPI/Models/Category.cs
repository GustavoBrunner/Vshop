namespace VShop.ProductAPI.Models;

public class Category
{
    public Category() 
    {
        CategoryId = Guid.NewGuid().ToString();
    }
    public string CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public ICollection<Product>? Products { get; set; } 
}
