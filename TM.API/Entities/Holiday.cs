using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TM.API.Entities
{
    public class Holiday
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Date")]
        public DateOnly Date { get; set; }


        //[BsonElement("Descrition")]
        public string Descrition { get; set; }
    }
}
