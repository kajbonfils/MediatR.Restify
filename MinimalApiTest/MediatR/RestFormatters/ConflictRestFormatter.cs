using System.Net;

namespace MinimalApiTest.MediatR.RestFormatters;

internal class ConflictRestFormatter : IRestFormatter
{
    public bool CanFormat(ApiResult apiResult) => apiResult.StatusCode == HttpStatusCode.Conflict;

    public IResult FormatRest(ApiResult apiResult)
    {
        return Results.Conflict(apiResult.Message);
    }
}