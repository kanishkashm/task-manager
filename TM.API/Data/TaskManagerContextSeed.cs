using MongoDB.Driver;
using TM.API.Entities;

namespace Catalog.API.Data
{
    public class TaskManagerContextSeed
    {
        public static void SeedData(IMongoCollection<Holiday> holidayCollection)
        {
            var a = holidayCollection.DeleteMany(p => true);
            bool existProduct = holidayCollection.Find(p => true).Any();
            if(!existProduct)
            {
                holidayCollection.InsertManyAsync(GetPreconfigureProducts());
            }
        }

        public static IEnumerable<Holiday> GetPreconfigureProducts()
        {
            return new List<Holiday>()
            {
                //new Holiday()
                //{
                //    Id = "602d2149e773f2a3990b47f5",
                //    DateStr = "2022/08/23",
                //    Descrition = "Poya Day"
                //},
                //new Holiday()
                //{
                //    Id = "602d2149e773f2a3990b47f6",
                //    DateStr = "2022/08/25",
                //    Descrition = "Another Holiday"
                //}
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
            };
        }
    }
}
