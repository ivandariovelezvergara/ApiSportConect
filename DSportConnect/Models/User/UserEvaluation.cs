using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSportConnect.Models.User
{
    public class UserEvaluation
    {
        [BsonElement("refereeSelfEvaluation")]
        public UserSelfEvaluation RefereeSelfEvaluation { get; set; } = null!;
        [BsonElement("refereeThirdPartyEvaluation")]
        public List<UserSelfEvaluation> RefereeThirdPartyEvaluation { get; set; } = null!;
        [BsonElement("specialPlayerSelfEvaluation")]
        public UserSelfEvaluation SpecialPlayerSelfEvaluation { get; set; } = null!;
        [BsonElement("specialPlayerThirdPartyEvaluation")]
        public List<UserSelfEvaluation> SpecialPlayerThirdPartyEvaluation { get; set; } = null!;
        [BsonElement("coachSelfEvaluation")]
        public UserSelfEvaluation CoachSelfEvaluation { get; set; } = null!;
        [BsonElement("coachThirdPartyEvaluation")]
        public List<UserSelfEvaluation> CoachThirdPartyEvaluation { get; set; } = null!;
    }
}
