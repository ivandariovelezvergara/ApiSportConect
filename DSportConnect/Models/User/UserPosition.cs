using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSportConnect.Models.User
{
    public class UserPosition
    {
        [BsonElement("id")]
        public Guid Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = null!;
        [BsonElement("userSelfEvaluation")]
        public UserSelfEvaluation UserSelfEvaluation { get; set; } = null!;
        [BsonElement("userThirdPartyEvaluation")]
        public List<UserThirdPartyEvaluation> UserThirdPartyEvaluation { get; set; } = null!;
    }
}
