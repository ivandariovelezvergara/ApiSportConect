using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DSportConnect.Models.Master
{
    public class MasterParameter
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = null!;
        [BsonElement("diminutive")]
        public string Diminutive { get; set; } = null!;
        [BsonElement("code")]
        public string Code { get; set; } = null!;
        [BsonElement("idFather")]
        public Guid? IdFather { get; set; }
    }
}
