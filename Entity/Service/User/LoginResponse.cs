using Entity.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Service.User
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public UserResponse User { get; set; }
    }
}
