using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSportConnect.Models.User
{
    public class ConfirmAccountRequest
    {
        public string Email { get; set; }
        public string CodeVerified { get; set; }
    }

}
