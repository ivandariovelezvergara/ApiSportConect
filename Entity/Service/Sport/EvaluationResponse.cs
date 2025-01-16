using Entity.Enumerable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Service.Sport
{
    public class EvaluationResponse
    {
        public Guid Id { get; set; }
        public EnumGroupEvaluation Group { get; set; } 
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? MaximumValue { get; set; }
        public int? MinimumValue { get; set; }
    }
}
