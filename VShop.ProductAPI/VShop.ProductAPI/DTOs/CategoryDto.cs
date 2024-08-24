using System.ComponentModel.DataAnnotations;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.DTOs;

public class CategoryDto
{
    
    public string CategoryId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Name is required!")]
    [MinLength(1)]
    [MaxLength(30)]
    public string CategoryName { get; set; } = string.Empty;

    public ICollection<Product>? Products { get; set; }
}
