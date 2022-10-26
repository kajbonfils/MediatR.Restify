using MinimalApiTest.Request;
using Xunit;

namespace MinimalApiTestTests
{
    public class CreateCarModelHandlerTest
    {
        [Fact]
        public async Task Handle()
        {
            var target = new CreateCarModelHandler();

            var actual = await target.Handle(new CreateCarModelRequest("Foo"), new CancellationToken());

            Assert.Equal(false, actual.IsSuccess);
        }
    }
}