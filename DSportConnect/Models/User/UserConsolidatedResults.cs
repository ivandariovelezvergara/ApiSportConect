using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSportConnect.Models.User
{
    public class UserConsolidatedResults
    {
        [BsonElement("consolidatedAmateurs")]
        public object ConsolidatedAmateurs { get; set; } = null!;
        [BsonElement("consolidatedTournament")]
        public object ConsolidatedTournament { get; set; } = null!;
    }
}
