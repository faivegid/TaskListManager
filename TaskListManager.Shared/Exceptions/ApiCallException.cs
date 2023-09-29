namespace TaskListManager.Shared.Exceptions
{
    public class ApiCallException: Exception
    {
        public string ErrorMessage { get; set; }
        public string ApiResponseMessage { get; set; }

        public ApiCallException(HttpResponseMessage responseMessage)
        {            
            ErrorMessage =  $"a call to the endpoint {responseMessage.RequestMessage.RequestUri} was unsuccessful";
            ApiResponseMessage = responseMessage.Content.ReadAsStringAsync().Result;
        }
    }
}
