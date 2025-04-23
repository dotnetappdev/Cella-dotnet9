using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; private set; }
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string? ErrorCode { get; private set; }
        public string ExceptionMessage { get; private set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Exception Exception { get; private set; }

        private ServiceResponse() { }

        public static ServiceResponse<T> Create(
            T data = default,
            string message = null,          
            int? errorCode = null,
            Exception exception = null
          )
        {
            return new ServiceResponse<T>
            {
                Data = data,
                Success = exception == null,
                Message = message ?? (exception == null ? "Success" : "An error occurred."),
                ErrorCode = errorCode,
                ExceptionMessage = exception?.Message,
                Exception = exception
            };
        }
    }


}
