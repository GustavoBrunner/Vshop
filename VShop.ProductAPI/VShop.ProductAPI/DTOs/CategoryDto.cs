using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.DTOs;

public class CategoryDto
{
    
    public string CategoryId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Name is required!")]
    [MinLength(1)]
    [MaxLength(30)]
    public string CategoryName { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}
