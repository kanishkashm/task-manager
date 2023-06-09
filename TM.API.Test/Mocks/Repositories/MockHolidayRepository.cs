using Moq;
using TM.API.Entities;
using TM.API.Repositories;

namespace TM.API.Test.Mocks.Repositories
{
    public class MockHolidayRepository : Mock<IHolidayRepository>
    {
        public MockHolidayRepository MockGetHolidays(List<Holiday> result)
        {
            Setup(x => x.GetHolidays())
                .ReturnsAsync(result);

            return this;
        }
    }
}
