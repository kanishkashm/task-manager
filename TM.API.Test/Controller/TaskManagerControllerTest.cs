using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TM.API.Controllers;
using TM.API.Test.Mocks.Services;

namespace TM.API.Test.Controller
{
    public class TaskManagerControllerTest
    {
        private readonly MockTaskManagerService _taskManagerService;
        private readonly ILogger<TaskManagerController> _logger;
        public TaskManagerControllerTest()
        {
            _taskManagerService = new MockTaskManagerService().MockGetTaskCompletionDate(new DateOnly(2022, 08, 23));
            _logger = Mock.Of<ILogger<TaskManagerController>>();
        }

        [Fact]
        public async void TaskManagerController_Get_ValidCompletionDate()
        {
            //Arrange
            var controller = new TaskManagerController(_taskManagerService.Object, _logger);

            //Act
            var dateResult = (OkObjectResult)await controller.Get("2022-08-20", 5);

            //Assert
            Assert.IsType<OkObjectResult>(dateResult);
            Assert.Equal(new DateOnly(2022, 08, 23), dateResult.Value);
        }
    }
}
