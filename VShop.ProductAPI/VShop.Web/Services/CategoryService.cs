using System.Text;
using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Services;

public class CategoryService : ICategoryService
{
    private const string apiUrl = "/api/category/";
    private const string clientName = "ProductApi";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JsonSerializerOptions _options;


    private CategoryViewModel _categoryVM;
    private IEnumerable<CategoryViewModel> _categoriesVM;

    public CategoryService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        //needed to avoid deserialization problems
        _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
    }

    public async Task<CategoryViewModel> CreateCategoryAsync(CategoryViewModel categoryViewModel)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        StringContent content = new StringContent(JsonSerializer
                .Serialize(categoryViewModel), Encoding.UTF8, "application/json");

        using (var response = await client.PostAsync(apiUrl, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                _categoryVM = await JsonSerializer
                        .DeserializeAsync<CategoryViewModel>(apiResponse, _options);
            }
            else
                return null;
        }
        return _categoryVM;
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
    {
        var client = _httpClientFactory.CreateClient(clientName);

        using (var response = await client.GetAsync(apiUrl))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                _categoriesVM = await JsonSerializer
                        .DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);
            }
            else
                return null;
        }
        return _categoriesVM;
    }

    public async Task<CategoryViewModel> GetCategoryByIdAsync(string id)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        using (var response = await client.GetAsync(apiUrl + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                _categoryVM = await JsonSerializer
                        .DeserializeAsync<CategoryViewModel>(apiResponse, _options);
            }
            else
                return null;
        }
        return _categoryVM;
    }

    public async Task<CategoryViewModel> UpdateCategoryAsync(CategoryViewModel categoryViewModel)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        StringContent content = new StringContent(
                JsonSerializer.Serialize(categoryViewModel), Encoding.UTF8, "application/json");

        using (var response = await client.PutAsJsonAsync(apiUrl, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _categoryVM = await JsonSerializer
                        .DeserializeAsync<CategoryViewModel>(responseApi, _options);
            }
            else
                return null;
        }

        return _categoryVM;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
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
