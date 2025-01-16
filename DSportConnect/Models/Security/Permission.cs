using Entity.Enumerable;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DSportConnect.Models.Security
{
    public class Permission
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("objName")]
        public string ObjName { get; set; } = null!;

        [BsonElement("actions")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public List<EnumAction> Actions { get; set; } = new();
    }
}
