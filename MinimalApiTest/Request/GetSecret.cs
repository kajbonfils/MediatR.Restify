using MediatR;
using MinimalApiTest.MediatR;

namespace MinimalApiTest.Request;
public record SecretRequest(string cpr) : IRequest<ApiResult>;

public class SecretRequestHandler : IRequestHandler<SecretRequest, ApiResult>
{
    public async Task<ApiResult> Handle(SecretRequest request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ApiResult.Success(System.Net.HttpStatusCode.OK, new { Name = $"Hello {request.cpr}" }));
    }
}