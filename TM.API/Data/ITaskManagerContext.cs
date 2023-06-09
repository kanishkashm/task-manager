using MongoDB.Driver;
using TM.API.Entities;

namespace TM.API.Data
{
    public interface ITaskManagerContext
    {
        IMongoCollection<Holiday> Holidays { get; set; }
    }
}
