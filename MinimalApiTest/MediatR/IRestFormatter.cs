namespace MinimalApiTest.MediatR;

public interface IRestFormatter
{
    public bool CanFormat(ApiResult apiResult);
    IResult FormatRest(ApiResult apiResult);
}