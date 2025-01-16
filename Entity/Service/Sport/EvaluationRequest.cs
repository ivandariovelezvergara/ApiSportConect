using Entity.Enumerable;

namespace Entity.Service.Sport
{
    public class EvaluationRequest
    {
        public string Name { get; set; } = null!;
        public EnumGroupEvaluation Group { get; set; }
        public string Description { get; set; } = null!;
        public int? MaximumValue { get; set; }
        public int? MinimumValue { get; set; }
    }
}
