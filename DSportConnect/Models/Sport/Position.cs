using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DSportConnect.Models.Sport
{
    public class Position
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = null!;
        [BsonElement("description")]
        public string Description { get; set; } = null!;
    }
}
