using System.Net;

namespace MinimalApiTest.MediatR;

internal class OkRestFormatter : IRestFormatter
{
    public bool CanFormat(ApiResult apiResult) => apiResult.StatusCode == HttpStatusCode.OK;

    public IResult FormatRest(ApiResult apiResult)
    {
        return Results.Ok(apiResult.Payload);
    }
}