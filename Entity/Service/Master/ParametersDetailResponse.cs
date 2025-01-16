﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Service.Master
{
    public class ParametersDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Diminutive { get; set; } = null!;
        public string Code { get; set; } = null!;
        public Guid? IdFather { get; set; }
    }
}
