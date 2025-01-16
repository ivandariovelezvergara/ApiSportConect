using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSportConnect.Models.User
{
    public class UserSports
    {
        [BsonElement("names")]
        public string Names { get; set; } = null!;
        [BsonElement("height")]
        public string Height { get; set; } = null!;
        [BsonElement("userPosition")]
        public UserPosition UserPosition { get; set; } = null!;
        [BsonElement("userConsolidatedResults")]
        public UserConsolidatedResults UserConsolidatedResults { get; set; } = null!;
    }
}
