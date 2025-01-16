using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DSportConnect.Models.User
{
    public class UserPersonalInformation
    {
        [BsonElement("documentType")]
        public string DocumentType { get; set; }
        [BsonElement("documentNumber")]
        public string DocumentNumber { get; set; } = null!;
        [BsonElement("names")]
        public string Names { get; set; } = null!;
        [BsonElement("firstName")]
        public string FirstName { get; set; } = null!;
        [BsonElement("lastName")]
        public string LastName { get; set; } = null!;
        [BsonElement("gender")]
        public string Gender { get; set; }
        [BsonElement("birthdate")]
        public DateTime Birthdate { get; set; }
        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; } = null!;
    }
}
