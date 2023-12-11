using System;

namespace GeoLocationDemoAPI.WebAPI.Models
{
    public class GeneralResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
    }

    public class ExceptionResponse
    {
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        public string? Source { get; set; }
        public ExceptionResponse? InnerException { get; set; }

        public ExceptionResponse(Exception exception)
        {
            if (exception != null)
            {
                Message = exception.Message;
                StackTrace = exception.StackTrace;
                Source = exception.Source;
                InnerException = exception.InnerException != null
                    ? new ExceptionResponse(exception.InnerException)
                    : null;
            }
        }
    }
}
