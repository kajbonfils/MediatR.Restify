using System.Net;
using MediatR;
using MinimalApiTest.MediatR;
using MinimalApiTest.Repo;

namespace MinimalApiTest.Request;

public record GetSpecificCarModelRequest(int Id) : IRequest<ApiResult>;

public class GetCarModelHandler : IRequestHandler<GetSpecificCarModelRequest, ApiResult>
{
    private readonly ICarModelRepository repository;

    public GetCarModelHandler(ICarModelRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ApiResult> Handle(GetSpecificCarModelRequest request, CancellationToken cancellationToken)
    {
        var entity = repository.Get(request.Id);
        ApiResult result;
        if (entity != null) { 
            result = ApiResult.Success(HttpStatusCode.OK, new CarModel(entity.Id, entity.Name));
        }
        else
        {
            result = ApiResult.Fail(HttpStatusCode.NotFound, "Id not found");
        }
        return await Task.FromResult(result);
    }
}