using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Entity.Enumerable;

namespace DSportConnect.Models.Sport
{
    public class Evaluation
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("group")]
        public EnumGroupEvaluation Group { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = null!;
        [BsonElement("description")]
        public string Description { get; set; } = null!;
        [BsonElement("maximumValue")]
        public int? MaximumValue { get; set; }
        [BsonElement("minimumValue")]
        public int? MinimumValue { get; set; }
    }
}
