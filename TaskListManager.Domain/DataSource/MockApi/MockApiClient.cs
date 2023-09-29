using Newtonsoft.Json;
using System.Text;
using TaskListManager.Shared.Exceptions;

namespace TaskListManager.Domain.DataSource.MockApi
{
    public class MockapiClient : IMockapiClient
    {
        private readonly HttpClient _httpClient;

        public MockapiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string relativeUrl, object data = null)
        {
            var request = new HttpRequestMessage(httpMethod, relativeUrl);
            if (data != null)
            {
                var stringData = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(stringData, Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.SendAsync(request);
            if(response.IsSuccessStatusCode)
            {
                return response;
            }

            throw new ApiCallException(response);
        }
    }
}
