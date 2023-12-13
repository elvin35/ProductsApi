using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;

namespace ProductsApi.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            StatusCode = statusCode;
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 200:
                    return "Success";
                case 400:
                    return "Bad request";
                case 404:
                    return "Response not found";
                case 500:
                    return "Unhandled error occurred";
                default:
                    return null;
            }
        }
    }
}
