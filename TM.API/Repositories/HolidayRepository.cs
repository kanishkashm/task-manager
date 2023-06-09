using MongoDB.Driver;
using TM.API.Data;
using TM.API.Entities;

namespace TM.API.Repositories
{
    public class HolidayRepository : IHolidayRepository
    {
        ITaskManagerContext _context;
        public HolidayRepository(ITaskManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Holiday>> GetHolidays()//DateOnly startDate, DateOnly endDate
        {
            var holidays = await _context.Holidays.Find(p => true).ToListAsync();
            return holidays;
        }
    }
}
