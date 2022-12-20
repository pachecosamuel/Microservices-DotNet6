using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue realContentType
            = new("application/json");

        public static async Task<T> ReadContentAs<T>
            (this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException
                    ($"Something went wrong calling the API." +
                     $"{response.ReasonPhrase}");

            if (response.Content != null)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonSerializer.Deserialize<T>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new ArgumentNullException(nameof(response));
            }
        }

        public static Task<HttpResponseMessage> PostAsJson<T>
            (this HttpClient httpClient,
            string url,
            T data)
        {
            var dataAsStr = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsStr);
            content.Headers.ContentType = realContentType;

            return httpClient.PostAsync(url, content);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>
            (this HttpClient httpClient,
            string url,
            T data)
        {
            var dataAsStr = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsStr);
            content.Headers.ContentType = realContentType;

            return httpClient.PutAsync(url, content);
        }
    }
}
