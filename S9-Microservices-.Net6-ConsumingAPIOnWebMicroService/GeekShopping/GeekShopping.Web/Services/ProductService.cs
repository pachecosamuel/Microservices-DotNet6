using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Mime;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        public const string BasePath = "api/v1/product";


        public ProductService(HttpClient client)
        {
            _http = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _http.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();

        }

        public async Task<ProductModel> FindProductById(Guid id)
        {
            var response = await _http.GetAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
                throw new Exception($"Something went wrong when calling API {response.ReasonPhrase}");
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _http.PostAsJson(BasePath, model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
                throw new Exception($"Something went wrong when calling API {response.ReasonPhrase}");
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _http.PutAsJson(BasePath, model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
                throw new Exception($"Something went wrong when calling API {response.ReasonPhrase}");
        }

        public async Task<bool> DeleteProductById(Guid id)
        {
            var response = await _http.DeleteAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception($"Something went wrong when calling API {response.ReasonPhrase}");
        }

    }
}
