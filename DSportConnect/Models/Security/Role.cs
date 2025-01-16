using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace DSportConnect.Models.Security
{
    public class Role
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("roleName")]
        public string RoleName { get; set; } = null!;

        [BsonElement("permissions")]
        public List<Permission> Permissions { get; set; } = new();

        [BsonElement("description")]
        public string Description { get; set; } = null!;

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
