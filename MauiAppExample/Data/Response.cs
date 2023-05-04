using System;
namespace MauiAppExample.Data
{
    public abstract class Response
    {
        public static Response Success => new SuccessResponse();
        public static Response Error(string errorMessage) => new ErrorResponse(errorMessage);
    }

    public abstract class Response<T> : Response
    { 
        public static new Response<T> Success(T result) => new SuccessResponse<T>(result);
    }

    public class SuccessResponse : Response
    { 
        public SuccessResponse()
        {
		}
    }

    public class SuccessResponse<T> : Response<T> 
    { 

        public T Result { get; protected set; }

        public SuccessResponse(T result)
        {
            Result = result;
		}
    }    

    public class ErrorResponse : Response
    { 
        public string ErrorMessage { get; }

        public ErrorResponse(string errorMessage = "")
        {
            ErrorMessage = errorMessage;
		}
    }
}

