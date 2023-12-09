using MongoDB.Bson.Serialization.Attributes;

namespace PoliceStationMongo.Models
{
    public class Policeman
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string jobTitle { get; set; }
        public string rank { get; set; }
        public Weapon weapon { get; set; }
    }
}
