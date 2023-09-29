using System.Net;

namespace TaskListManager.Shared.Exceptions
{
    public class ApiCallException: Exception
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode ErrorCode { get; set; }

        public ApiCallException(HttpResponseMessage responseMessage)
        {            
            ErrorMessage =  $"A call to the endpoint {responseMessage.RequestMessage.RequestUri} was unsuccessful; status: {responseMessage.StatusCode} Error :{responseMessage.Content.ReadAsStringAsync().Result}";

            ErrorCode = responseMessage.StatusCode;
        }
    }
}
