using TM.API.Entities;

namespace TM.API.Repositories
{
    public interface IHolidayRepository
    {
        //Task<List<Holiday>> GetHolidays(DateOnly startDate, DateOnly endDate);
        Task<List<Holiday>> GetHolidays();
        Task<List<Adds>> GetAdds();
    }
}
