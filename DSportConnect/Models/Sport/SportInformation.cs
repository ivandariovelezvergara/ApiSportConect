using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Entity.Service.Sport;

namespace DSportConnect.Models.Sport
{
    public class SportInformation
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = null!;
        [BsonElement("description")]
        public string Description { get; set; } = null!;
        [BsonElement("selfEvaluation")]
        public List<Evaluation> SelfEvaluation { get; set; } = null!;
        [BsonElement("thirdPartyEvaluation")]
        public List<Evaluation> ThirdPartyEvaluation { get; set; } = null!;
        [BsonElement("refereeSelfEvaluation")]
        public List<Evaluation> RefereeSelfEvaluation { get; set; } = null!;
        [BsonElement("refereeThirdPartyEvaluation")]
        public List<Evaluation> RefereeThirdPartyEvaluation { get; set; } = null!;
        [BsonElement("specialPlayerSelfEvaluation")]
        public List<Evaluation> SpecialPlayerSelfEvaluation { get; set; } = null!;
        [BsonElement("specialPlayerThirdPartyEvaluation")]
        public List<Evaluation> SpecialPlayerThirdPartyEvaluation { get; set; } = null!;
        [BsonElement("coachSelfEvaluation")]
        public List<Evaluation> CoachSelfEvaluation { get; set; } = null!;
        [BsonElement("coachThirdPartyEvaluation")]
        public List<Evaluation> CoachThirdPartyEvaluation { get; set; } = null!;
        [BsonElement("sportsArenaSelfEvaluation")]
        public List<Evaluation> SportsArenaSelfEvaluation { get; set; } = null!;
        [BsonElement("sportsArenaThirdPartyEvaluation")]
        public List<Evaluation> SportsArenaThirdPartyEvaluation { get; set; } = null!;
        [BsonElement("categorySport")]
        public List<Category> CategorySport { get; set; } = null!;
        [BsonElement("position")]
        public List<Position> Position { get; set; } = null!;
        [BsonElement("status")]
        public bool Status { get; set; }
    }
}
