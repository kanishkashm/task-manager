using Moq;
using TM.API.Services;

namespace TM.API.Test.Mocks.Services
{
    public class MockTaskManagerService : Mock<ITaskManagerService>
    {
        public MockTaskManagerService MockGetTaskCompletionDate(DateOnly result)
        {
            Setup(x => x.GetTaskCompletionDate(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }
    }
}
