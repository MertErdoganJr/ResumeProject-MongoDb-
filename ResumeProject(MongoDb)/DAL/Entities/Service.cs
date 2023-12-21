using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ResumeProject_MongoDb_.DAL.Entities
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceID { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; } 
    }
}
