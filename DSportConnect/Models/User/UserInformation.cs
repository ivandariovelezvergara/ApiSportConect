using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSportConnect.Models.User
{
    public class UserInformation
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("mail")]
        public string Mail { get; set; } = null!;
        [BsonElement("password")]
        public string Password { get; set; } = null!;
        [BsonElement("codeVerified")]
        public string CodeVerified { get; set; } = null!;
        [BsonElement("emailVerified")]
        public bool EmailVerified { get; set; }
        [BsonElement("roles")]
        public List<string> Roles { get; set; } = null;
        [BsonElement("personalInformation")]
        public UserPersonalInformation PersonalInformation { get; set; } = null;
        [BsonElement("physicalCharacteristics")]
        public UserPhysicalCharacteristics PhysicalCharacteristics { get; set; } = null;
        [BsonElement("userSports")]
        public List<UserSports> UserSports { get; set; } = null;
        [BsonElement("referee")]
        public object Referee { get; set; } = null;
        [BsonElement("specialPlayer")]
        public object SpecialPlayer { get; set; } = null;
        [BsonElement("coach")]
        public object Coach { get; set; } = null;
        [BsonElement("rolEvaluation")]
        public UserEvaluation RolEvaluation { get; set; } = null;
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
