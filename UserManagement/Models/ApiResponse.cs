namespace UserManagement.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public int StatusCode { get; set; }

        public T Data { get; set; }

        public ApiResponse(bool success, string message, int statusCode, T data)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
            Data = data ;
        }
    }
}
