using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using DigitalOceanDotNet.Objets;
using Newtonsoft.Json;

namespace DigitalOceanDotNet
{
    public class Core
    {
        public static long PerPage = 2;

        private const string ApiServer = "https://api.digitalocean.com/v2";

        public static async Task<string> SendGetRequest(string token, string url)
        {
            HttpResponseMessage httpResponseMessage;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod("GET"), $"{ApiServer}{url}"))
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                }
            }

            // IsNullOrEmpty
            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("there has been some error, the API has responded empty.");
            }

            // No OK
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("{error.Message}");
            }

            return json;
        }


        public static async Task<string> SendPostRequest(string token, string url, string content)
        {
            HttpResponseMessage httpResponseMessage;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), $"{ApiServer}{url}"))
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpRequestMessage.Content = new StringContent(content);
                    httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                }
            }

            // IsNullOrEmpty
            string json = await httpResponseMessage.Content.ReadAsStringAsync();

            // Empty
            if (string.IsNullOrEmpty(json) && httpResponseMessage.StatusCode != HttpStatusCode.NoContent)
            {
                throw new Exception("there has been some error, the API has responded empty.");
            }

            // No Created
            if (httpResponseMessage.StatusCode != HttpStatusCode.Created && httpResponseMessage.StatusCode != HttpStatusCode.NoContent && httpResponseMessage.StatusCode != HttpStatusCode.Accepted)
            {
                Universal.Error error = JsonConvert.DeserializeObject<Universal.Error>(json) ?? new Universal.Error();
                throw new Exception($"{error.Message}");
            }

            return json;
        }

        public static async Task<string> SendPutRequest(string token, string url, string content)
        {
            HttpResponseMessage httpResponseMessage;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod("PUT"), $"{ApiServer}{url}"))
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpRequestMessage.Content = new StringContent(content);
                    httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                }
            }

            // IsNullOrEmpty
            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("there has been some error, the API has responded empty.");
            }

            // No Update
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                Universal.Error error = JsonConvert.DeserializeObject<Universal.Error>(json) ?? new Universal.Error();
                throw new Exception($"{error.Message}");
            }

            return json;
        }

        public static async Task SendDeleteRequest(string token, string url)
        {
            HttpResponseMessage httpResponseMessage;
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), $"{ApiServer}{url}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpResponseMessage = await httpClient.SendAsync(request);
                }
            }

            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.OK:
                    break;

                default:
                    string json = await httpResponseMessage.Content.ReadAsStringAsync();
                    Universal.Error error = JsonConvert.DeserializeObject<Universal.Error>(json) ?? new Universal.Error();
                    throw new Exception($"{error.Message}");
            }
        }

        public static async Task<string> SendDeleteRequest(string token, string url, string content)
        {
            HttpResponseMessage httpResponseMessage;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod("DELETE"), $"{ApiServer}{url}"))
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpRequestMessage.Content = new StringContent(content);
                    httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                }
            }

            // IsNullOrEmpty
            string json = await httpResponseMessage.Content.ReadAsStringAsync();

            // Empty
            if (string.IsNullOrEmpty(json) && httpResponseMessage.StatusCode != HttpStatusCode.NoContent)
            {
                throw new Exception("there has been some error, the API has responded empty.");
            }

            // No Created
            if (httpResponseMessage.StatusCode != HttpStatusCode.Created && httpResponseMessage.StatusCode != HttpStatusCode.NoContent && httpResponseMessage.StatusCode != HttpStatusCode.Accepted)
            {
                Universal.Error error = JsonConvert.DeserializeObject<Universal.Error>(json) ?? new Universal.Error();
                throw new Exception($"{error.Message}");
            }

            return json;
        }
    }
}
