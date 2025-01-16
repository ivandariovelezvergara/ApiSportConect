using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DSportConnect.Models.Master
{
    public class MasterTable
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("masterName")]
        public string MasterName { get; set; } = null!;
        [BsonElement("parameters")]
        public List<MasterParameter> Parameters { get; set; } = new();
    }
}
