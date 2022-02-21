using System.Net.Http.Headers;
using System.Text;

namespace FCS.Virk
{
    public class VrHttpRequest
    {
        public async Task<VrResponseView> GetResponseAsync(string endpoint, string jsonData, string auth)
        {
            using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            using var vrRequest = new HttpRequestMessage(HttpMethod.Post, endpoint);

            vrRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", $"{auth}");
            vrRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            vrRequest.Content = content;

            var response = await client.SendAsync(vrRequest).ConfigureAwait(true);
            var jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

            return new VrResponseView
            {
                Code = response.StatusCode,
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                Message = jsonResult
            };
        }
    }
}

