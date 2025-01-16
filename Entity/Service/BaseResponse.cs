using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Service
{
    public class BaseResponse
    {
        public int IdStaus { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsError { get; set; }
    }
}
