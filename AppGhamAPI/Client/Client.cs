using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppGhamAPI.Client
{
    public static class ApiClient
    {
        const string BaseUrl = "https://10.0.2.2:5001/";

        private static HttpClient _client;

        static ApiClient()
        {
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true
            };

            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri(BaseUrl);
        }

        public static async Task<T> GetAsync<T>(string url)
        {
            var json = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<Response> PostAsync<Content, Response>(string url, Content content)
        {
            var json = JsonConvert.SerializeObject(content);
            var response = await _client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            
            if(response.IsSuccessStatusCode)
            {
                var contentResponse = await response.Content.ReadAsStringAsync();
                if(!string.IsNullOrEmpty(contentResponse))
                    return JsonConvert.DeserializeObject<Response>(contentResponse);
            }

            return default;
        }
    }
}
