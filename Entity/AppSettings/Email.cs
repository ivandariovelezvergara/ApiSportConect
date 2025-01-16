using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AppSettings
{
    public class Email
    {
        public string SMTPHost { get; set; } = string.Empty;
        public int SMTPPort { get; set; }
        public string SenderEmail { get; set; } = string.Empty;
        public string SenderPassword { get; set; } = string.Empty;
    }
}
