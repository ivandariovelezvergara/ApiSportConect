using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DSportConnect.Models.Security
{
    public class AppObject
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("objectName")]
        public string ObjectName { get; set; } = null!;
        [BsonElement("description")]
        public string Description { get; set; } = null!;
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
