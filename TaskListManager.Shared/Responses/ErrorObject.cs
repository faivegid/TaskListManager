namespace TaskListManager.Shared.Responses
{
    public class ErrorObject
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }

        public ErrorObject()
        {
        }

        public ErrorObject(string message, string errCode)
        {
            ErrorMessage = message;
            ErrorCode = errCode;
        }
    }
}
