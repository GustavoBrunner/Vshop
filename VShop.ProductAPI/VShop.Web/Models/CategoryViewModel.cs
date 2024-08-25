using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VShop.Web.Models;

public class CategoryViewModel
{
    public string CategoryId { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

}
