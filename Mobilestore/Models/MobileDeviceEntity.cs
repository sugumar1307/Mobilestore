using MongoDB.Bson.Serialization.Attributes;

namespace Mobilestore.Models
{
    public class MobileDeviceEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Name{ get; set; }
        public string company{ get; set; }
        public string color{ get; set; }
    }
}
