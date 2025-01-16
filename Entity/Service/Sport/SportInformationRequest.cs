namespace Entity.Service.Sport
{
    public class SportInformationRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<EvaluationRequest> SelfEvaluation { get; set; } = null!;
        public List<EvaluationRequest> ThirdPartyEvaluation { get; set; } = null!;
        public List<EvaluationRequest> RefereeSelfEvaluation { get; set; } = null!;
        public List<EvaluationRequest> RefereeThirdPartyEvaluation { get; set; } = null!;
        public List<EvaluationRequest> SpecialPlayerSelfEvaluation { get; set; } = null!;
        public List<EvaluationRequest> SpecialPlayerThirdPartyEvaluation { get; set; } = null!;
        public List<EvaluationRequest> CoachSelfEvaluation { get; set; } = null!;
        public List<EvaluationRequest> CoachThirdPartyEvaluation { get; set; } = null!;
        public List<EvaluationRequest> SportsArenaSelfEvaluation { get; set; } = null!;
        public List<EvaluationRequest> SportsArenaThirdPartyEvaluation { get; set; } = null!;
        public List<CategoryRequest> Category { get; set; } = null!;
        public List<PositionRequest> Position { get; set; } = null!;
        public bool Status { get; set; }
    }
}
