using System.Net;

namespace MinimalApiTest.MediatR.RestFormatters;

internal class OkRestFormatter : IRestFormatter
{
    public bool CanFormat(ApiResult apiResult) => apiResult.StatusCode == HttpStatusCode.OK;

    public IResult FormatRest(ApiResult apiResult)
    {
        return Results.Ok(apiResult.Payload);
    }
}