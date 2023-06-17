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
            //var client = new MongoClient(configuration.GetValue<string>("TaskManagerDbSettings:ConnectionString"));
            //_database = client.GetDatabase(configuration.GetValue<string>("TaskManagerDbSettings:DatabaseName"));
            //Holidays = _database.GetCollection<Holiday>(configuration.GetValue<string>("TaskManagerDbSettings:CollectionName"));
            //TaskManagerContextSeed.SeedData(Holidays);

            var client2 = new MongoClient(configuration.GetValue<string>("TestDbSettings:ConnectionString"));
            _database = client2.GetDatabase(configuration.GetValue<string>("TestDbSettings:DatabaseName"));
            Addsss = _database.GetCollection<Adds>(configuration.GetValue<string>("TestDbSettings:CollectionName"));
        }

        public IMongoCollection<Holiday> Holidays { get; set; }
        public IMongoCollection<Adds> Addsss { get; set; }
    }
}
