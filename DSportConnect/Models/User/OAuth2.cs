using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DSportConnect.Models.User
{
    public class OAuth2
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("refreshToken")]
        public string RefreshToken { get; set; }
        [BsonElement("refreshTokenExpiryTime")]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
