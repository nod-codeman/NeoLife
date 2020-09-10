using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            // ?? is null coalease operator. Means execute anything on the right if value is null
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode); 
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request was made",
                401 => "You are not authorized",
                404 => "Resource not found",
                500 => "An internal server error occured",
                _ => null
            };
        }
    }
}