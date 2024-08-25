using System.Text;
using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Services;

public class ProductService : IProductService
{
    private const string apiUrl = "/api/product/";
    private const string clientName = "ProductApi";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JsonSerializerOptions _options;

    private ProductViewModel _productVM;
    private IEnumerable<ProductViewModel> _productsVM;    
    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        //needed to avoid deserialization problems
        _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
    }

    public async Task<ProductViewModel> CreateProductAsync(ProductViewModel model)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        //an instance of the class string content to be able to serialize
        //the content, providing the enconding
        StringContent content = new StringContent(JsonSerializer
                .Serialize(model), Encoding.UTF8, "application/json");

        //here we provide the uri and the content!
        using(var response = await client.PostAsync(apiUrl, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                _productVM = await JsonSerializer
                        .DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
            else
                return null;

        }
        return _productVM;
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient(clientName);

        using(var response = await client.GetAsync(apiUrl))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                _productsVM = await JsonSerializer
                    .DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
            }
            else
                return null;

        }
        return _productsVM;
    }

    public async Task<ProductViewModel> GetByIdAsync(string id)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        //create a scope, and dispose the content after its use. It can only be used
        //when the used class, in the parentheses, implements the IDisposible interface
        using (var response = await client.GetAsync(apiUrl + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                _productVM = await JsonSerializer
                    .DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
            else
                return null;
        }
        return _productVM;
    }

    public async Task<ProductViewModel> UpdateProductAsync(ProductViewModel model)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        StringContent content = new StringContent(JsonSerializer
                             .Serialize(model), Encoding.UTF8, "application/json");

        using (var response = await client.PutAsJsonAsync(apiUrl, content))
        {
            if (response.IsSuccessStatusCode) 
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                _productVM = await JsonSerializer
                        .DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
        }
        return _productVM;
    }

    public async Task<bool> DeleteProductAsync(string id)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        using (var response = await client.DeleteAsync(apiUrl + id))
        {
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
        }
        return true;
    }
}
