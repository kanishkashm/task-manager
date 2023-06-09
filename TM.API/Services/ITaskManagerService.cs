namespace TM.API.Services
{
    public interface ITaskManagerService
    {
        Task<DateOnly> GetTaskCompletionDate(string startDateStr, int numOfDaysNeeded);
    }
}
