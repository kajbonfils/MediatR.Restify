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

internal class CreatedRestFormatter : IRestFormatter
{
    public bool CanFormat(ApiResult apiResult) => apiResult.StatusCode == HttpStatusCode.Created;

    public IResult FormatRest(ApiResult apiResult)
    {
        return Results.Created(apiResult.ResourceLink, apiResult.Payload);
    }
}