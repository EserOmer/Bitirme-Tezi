using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Security
{
    public class Response<T>
    {
        public int StatusCode { get; set; }

        public IReadOnlyList<T> Results { get; set; }

        public T Result { get; set; }

        public ResponseError Error { get; set; }

        public bool HasError
        {
            get
            {
                return Error != null
;
            }
        }

        public static async Task<Response<T>> Run(T data, int statusCode = 200)
        {
            return await Task.FromResult(new Response<T> { Result = data, StatusCode = statusCode });
        }
        public static async Task<Response<T>> Catch(ResponseError error, int? errorCode = null)
        {
            return await Task.FromResult(new Response<T> { Error = error, StatusCode = (errorCode.HasValue) ? errorCode.Value : error.Code });
        }
    }

    public class ResponseError : Exception
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
