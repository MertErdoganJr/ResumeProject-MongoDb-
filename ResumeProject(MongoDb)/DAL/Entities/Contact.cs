using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ResumeProject_MongoDb_.DAL.Entities
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
