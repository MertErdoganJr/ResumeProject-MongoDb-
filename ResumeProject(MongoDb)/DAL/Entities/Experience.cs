using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ResumeProject_MongoDb_.DAL.Entities
{
    public class Experience
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ExperienceID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
    }
}
