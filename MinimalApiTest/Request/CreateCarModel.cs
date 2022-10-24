using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApiTest.MediatR;

namespace MinimalApiTest.Request
{
    public record CreateCarModelRequest(string Name) : IRequest<ApiResult>;

    public class CreateCarModelHandler: IRequestHandler<CreateCarModelRequest, ApiResult>
    {
        public async Task<ApiResult> Handle(CreateCarModelRequest request, CancellationToken cancellationToken)
        {
            var result = ApiResult.Fail(HttpStatusCode.Conflict, "Resourse already exists");
            return await Task.FromResult(result);
        }
    }
}

