using System.Net;

namespace MinimalApiTest.MediatR;

public class ApiResult 
{

    // TODO: Resource Link
    public HttpStatusCode StatusCode { get; }
    public string? Message { get; }

    public bool IsSuccess { get; protected set; }
    private ApiResult(HttpStatusCode statusCode, object payload) 
    {
        StatusCode = statusCode;
        Payload = payload;
    }

    private ApiResult(HttpStatusCode statusCode, string message) 
    {
        StatusCode = statusCode;
        Message = message;
    }

    public object Payload { get; } 

    public static ApiResult Fail(HttpStatusCode failureStatus, string message) => new(failureStatus, message) { IsSuccess = false };
    public static ApiResult Success(HttpStatusCode statusCode, object payLoad) => new(statusCode, payLoad) { IsSuccess = true };

    public static implicit operator bool(ApiResult result) => result.IsSuccess;
}
