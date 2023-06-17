using TM.API.Entities;

namespace TM.API.Services
{
    public interface ITaskManagerService
    {
        Task<DateOnly> GetTaskCompletionDate(string startDateStr, int numOfDaysNeeded);
        Task<List<Adds>> GetAdds();
    }
}
