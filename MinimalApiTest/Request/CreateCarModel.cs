using System.Net;
using MediatR;
using MinimalApiTest.MediatR;
using MinimalApiTest.Repo;

namespace MinimalApiTest.Request
{
    public record CreateCarModelRequest(string Name) : IRequest<ApiResult>;

    public class CreateCarModelHandler: IRequestHandler<CreateCarModelRequest, ApiResult>
    {
        private readonly LinkGenerator linkGenerator;
        private readonly IHttpContextAccessor accessor;
        private readonly ICarModelRepository repository;

        public CreateCarModelHandler(LinkGenerator linkGenerator, IHttpContextAccessor accessor, ICarModelRepository repository)
        {
            this.linkGenerator = linkGenerator;
            this.accessor = accessor;
            this.repository = repository;
        }

        public async Task<ApiResult> Handle(CreateCarModelRequest request, CancellationToken cancellationToken)
        {
            var id = repository.Add(request.Name);
            var createdResource = new { Id = id, Name = request.Name };
            var result = ApiResult.Success(HttpStatusCode.Created, createdResource);
            var uri = linkGenerator.GetUriByName(accessor.HttpContext, "GetCarModel", new { id });
            result.ResourceLink = uri;
            return await Task.FromResult(result);
        }
    }
}

