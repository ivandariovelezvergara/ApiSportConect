using Entity.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Service.User
{
    public class UserResponse
    {
        public string Mail { get; set; } = null!;
        public dynamic PersonalInformation { get; set; }
        public dynamic PhysicalCharacteristics { get; set; }
        public List<Permission> Permissions { get; set; }
        public dynamic UserSports { get; set; }
        public dynamic Referee { get; set; }
        public dynamic SpecialPlayer { get; set; }
        public dynamic Coach { get; set; }
        public dynamic RolEvaluation { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
