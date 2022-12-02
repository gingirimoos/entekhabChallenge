using System.Collections.Generic;

namespace Application.Common.Models
{
    public class ServiceResult
    {
        public static ServiceResult<T> Failure<T>(string message = "Failure", IDictionary<string, List<string>> errors = default, T data = default) =>
            new ServiceResult<T>(data, message, errors);

        public static ServiceResult<T> Ok<T>(T data, string message = "Success") =>
            new ServiceResult<T>(data, message);

        public static ServiceResult Ok() => new ServiceResult();
    }

    public class ServiceResult<T>
    {
        public T Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public IDictionary<string, List<string>> Errors { get; set; }

        public ServiceResult(T data, string message)
        {
            Data = data;
            Message = message;
        }

        public ServiceResult()
        {

        }


        public ServiceResult(T data, string message, IDictionary<string, List<string>> errors)
        {
            Data = data;
            Message = message;
            Errors = errors;
        }
    }
}
