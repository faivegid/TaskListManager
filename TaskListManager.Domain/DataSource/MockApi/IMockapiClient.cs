namespace TaskListManager.Domain.DataSource.MockApi
{
    public interface IMockapiClient
    {
        Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string relativeUrl, object data = null);
    }
}