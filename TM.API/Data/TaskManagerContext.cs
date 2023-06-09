using Catalog.API.Data;
using MongoDB.Driver;
using TM.API.Entities;

namespace TM.API.Data
{
    public class TaskManagerContext : ITaskManagerContext
    {
        private readonly IMongoDatabase _database;

        public TaskManagerContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("TaskManagerDbSettings:ConnectionString"));
            _database = client.GetDatabase(configuration.GetValue<string>("TaskManagerDbSettings:DatabaseName"));
            Holidays = _database.GetCollection<Holiday>(configuration.GetValue<string>("TaskManagerDbSettings:CollectionName"));
            TaskManagerContextSeed.SeedData(Holidays);
        }

        public IMongoCollection<Holiday> Holidays { get; set; }
    }
}
