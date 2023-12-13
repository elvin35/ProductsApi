using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Runtime.CompilerServices;

namespace ProductsApi.Errors
{
    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }

        public ApiOkResponse(object result) : base(200)
        {
            Result = result;
        }
    }
}