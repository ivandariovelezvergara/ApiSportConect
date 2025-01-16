using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Service.Security
{
    public class AppObjectResponse
    {
        public Guid Id { get; set; }
        public string ObjectName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
