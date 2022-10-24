namespace MinimalApiTest.MediatR.RestFormatters;

internal class DefaultRestFormatter : IRestFormatter
{
    public bool CanFormat(ApiResult apiResult) => true;

    public IResult FormatRest(ApiResult apiResult)
    {
        return Results.StatusCode((int)apiResult.StatusCode);
    }
}