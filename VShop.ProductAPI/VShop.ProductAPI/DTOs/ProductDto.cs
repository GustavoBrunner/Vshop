using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.DTOs;

public class ProductDto
{
    public string ProductId { get; set; } = string.Empty;

    [Required(ErrorMessage ="Price is required!")]
    [Precision(12,2)]
    public decimal Price { get; set; }

    [Required(ErrorMessage ="Name is required!")]
    [MinLength(1)]
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage ="Stock is required!")]
    [DefaultValue(0)]
    [Range(0,99999)]
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }
    public string CategoryId { get; set; } = string.Empty ;
    [JsonIgnore]
    public Category? Category { get; set; }
}
