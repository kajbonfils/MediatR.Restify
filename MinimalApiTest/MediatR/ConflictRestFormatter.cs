using System.Net;

namespace MinimalApiTest.MediatR;

internal class ConflictRestFormatter : IRestFormatter
{
    public bool CanFormat(ApiResult apiResult) => apiResult.StatusCode == HttpStatusCode.Conflict;

    public IResult FormatRest(ApiResult apiResult) 
    {
        return Results.Conflict(apiResult.Message);
    }
}