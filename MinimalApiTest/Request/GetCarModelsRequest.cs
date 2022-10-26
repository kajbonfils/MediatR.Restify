using System.Net;
using MediatR;
using MinimalApiTest.MediatR;
using MinimalApiTest.Repo;

namespace MinimalApiTest.Request;

public record GetCarModelsRequest : IRequest<ApiResult>
{
}

public record CarModel(int Id, string Name);

public class GetCarModelsHandler : IRequestHandler<GetCarModelsRequest, ApiResult>
{
    private readonly ICarModelRepository repository;

    public GetCarModelsHandler(ICarModelRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ApiResult> Handle(GetCarModelsRequest request, CancellationToken cancellationToken)
    {
        var result =
            ApiResult.Success(HttpStatusCode.OK, repository.GetAll().Select(p => new CarModel(p.Id, p.Name)).ToList());

        
        return await Task.FromResult(result);
    }
}