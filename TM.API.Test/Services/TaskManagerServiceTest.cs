using Microsoft.Extensions.Logging;
using Moq;
using TM.API.Entities;
using TM.API.Services;
using TM.API.Test.Mocks.Repositories;

namespace TM.API.Test.Services
{
    public class TaskManagerServiceTest
    {
        MockHolidayRepository _mockHolidayRepo;
        ILogger<TaskManagerService> _logger;

        public TaskManagerServiceTest()
        {
            _mockHolidayRepo = new MockHolidayRepository().MockGetHolidays(new List<Holiday>
            {
                new Holiday()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Date = new DateOnly(2022, 08, 23),
                    Descrition = "Poya Day"
                },
                new Holiday()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Date = new DateOnly(2022, 08, 25),
                    Descrition = "Another Holiday"
                }
            });

            _logger = Mock.Of<ILogger<TaskManagerService>>();
        }

        [Fact]
        public async void TaskManagerService_GetTaskCompletionDate_DateValidity()
        {
            //Arrange
            var taskService = new TaskManagerService(_mockHolidayRepo.Object, _logger);

            //Act
            var date = await taskService.GetTaskCompletionDate("2022-08-20", 5);

            //Assert
            Assert.Equal(new DateOnly(2022, 08, 30), date);
        }


        [Fact]
        public async void TaskManagerService_GetTaskCompletionDate_StartDateIsNotCorrect()
        {
            //Arrange
            var taskService = new TaskManagerService(_mockHolidayRepo.Object, _logger);

            //Act
            var exception = await Record.ExceptionAsync(() => taskService.GetTaskCompletionDate("2022-08-19rtrt", 5));

            //Assert
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Equal("Invalid start date", exception.Message);
        }

        [Fact]
        public async void TaskManagerService_GetTaskCompletionDate_NumOfDaysNeededIsNotCorrect()
        {
            //Arrange
            var taskService = new TaskManagerService(_mockHolidayRepo.Object, _logger);

            //Act
            var exception = await Record.ExceptionAsync(() => taskService.GetTaskCompletionDate("2022-08-19", -1));

            //Assert
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Equal("Invalid numOfDaysNeeded", exception.Message);
        }
    }
}
