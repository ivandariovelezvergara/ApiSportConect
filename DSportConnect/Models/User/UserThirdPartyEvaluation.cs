using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSportConnect.Models.User
{
    public class UserThirdPartyEvaluation
    {
        [BsonElement("id")]
        public Guid Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = null!;
        [BsonElement("value")]
        public string Value { get; set; } = null!;
        [BsonElement("userEvaluated")]
        public string userEvaluated { get; set; } = null!;
        [BsonElement("evaluationDate")]
        public DateTime EvaluationDate { get; set; }
    }
}
