using System.Net;
using MediatR;
using MinimalApiTest.MediatR;

namespace MinimalApiTest.Request;

public class GetCarModelsRequest : IRequest<ApiResult>
{
}

public record CarModel(int Id, string Name);

public class GetCarModelHandler : IRequestHandler<GetCarModelsRequest, ApiResult>
{
    public async Task<ApiResult> Handle(GetCarModelsRequest request, CancellationToken cancellationToken)
    {
        var result = 
            ApiResult.Success(HttpStatusCode.OK, new List<CarModel>
            { new CarModel(1, "volvo"), new CarModel(2, "vw") });

        
        return await Task.FromResult(result);
    }
}