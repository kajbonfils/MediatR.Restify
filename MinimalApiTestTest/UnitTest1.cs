using MinimalApiTest.Request;

namespace MinimalApiTestTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task HandleAsync()
        {
            var target = new CreateCarModelHandler();

            var actual = await target.Handle(new CreateCarModelRequest("Foo"), new CancellationToken());

            Assert.False(actual.IsSuccess);

        }
    }
}