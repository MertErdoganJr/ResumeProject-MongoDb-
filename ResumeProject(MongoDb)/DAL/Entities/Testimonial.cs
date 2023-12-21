using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ResumeProject_MongoDb_.DAL.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}
