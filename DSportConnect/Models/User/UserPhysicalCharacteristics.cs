using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSportConnect.Models.User
{
    public class UserPhysicalCharacteristics
    {
        [BsonElement("weight")]
        public string Weight { get; set; } = null!;
        [BsonElement("height")]
        public string Height { get; set; } = null!;
        [BsonElement("dominantSide")]
        public string DominantSide { get; set; } = null!;
    }
}
