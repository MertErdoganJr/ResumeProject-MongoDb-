using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ResumeProject_MongoDb_.DAL.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
