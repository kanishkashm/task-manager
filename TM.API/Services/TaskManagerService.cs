using Microsoft.AspNetCore.Http.HttpResults;
using TM.API.Repositories;

namespace TM.API.Services
{
    public class TaskManagerService : ITaskManagerService
    {
        private readonly IHolidayRepository _holidayRepo;
        private readonly ILogger<TaskManagerService> _logger;

        public TaskManagerService(IHolidayRepository holidayRepo, ILogger<TaskManagerService> logger)
        {
            _holidayRepo = holidayRepo;
            _logger = logger;
        }

        public async Task<DateOnly> GetTaskCompletionDate(string startDateStr, int numOfDaysNeeded)
        {
            DateOnly startDate;
            try
            {
                startDate = DateOnly.Parse(startDateStr);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid date: {startDateStr}");
                throw new Exception("Invalid start date");
            }
            if(numOfDaysNeeded <= 0)
            {
                throw new Exception("Invalid numOfDaysNeeded");
            }
            var holidays = (await _holidayRepo.GetHolidays()).Select(x => x.Date).ToList();


            var duration = numOfDaysNeeded;
            var completionDate = startDate;
            while (duration > 0)
            {
                var allHolidays = NumberOfWeekendsAndHolidays(completionDate, duration, holidays);
                completionDate = completionDate.AddDays(duration);
                duration = allHolidays;
            }

            return completionDate.AddDays(-1);
        }

        private int NumberOfWeekendsAndHolidays(DateOnly startDate, int duration, List<DateOnly> holidays)
        {
            int count = 0;
            for (var i = 0; i < duration; i++)
            {
                var date = startDate.AddDays(i);
                var a = holidays.Any(x => x == date);
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || holidays.Any(x => x == date))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
