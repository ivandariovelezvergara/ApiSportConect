using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Service.Security
{
    public class RoleGetResponse
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; } = null!;
        public List<Permission> Permissions { get; set; } = new();
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
