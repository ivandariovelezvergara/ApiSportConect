using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Service.Sport
{
    public class SportResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<EvaluationResponse> SelfEvaluation { get; set; } = null!;
        public List<EvaluationResponse> ThirdPartyEvaluation { get; set; } = null!;
        public List<EvaluationResponse> RefereeSelfEvaluation { get; set; } = null!;
        public List<EvaluationResponse> RefereeThirdPartyEvaluation { get; set; } = null!;
        public List<EvaluationResponse> SpecialPlayerSelfEvaluation { get; set; } = null!;
        public List<EvaluationResponse> SpecialPlayerThirdPartyEvaluation { get; set; } = null!;
        public List<EvaluationResponse> CoachSelfEvaluation { get; set; } = null!;
        public List<EvaluationResponse> CoachThirdPartyEvaluation { get; set; } = null!;
        public List<EvaluationResponse> SportsArenaSelfEvaluation { get; set; } = null!;
        public List<EvaluationResponse> SportsArenaThirdPartyEvaluation { get; set; } = null!;
        public List<CategoryResponse> CategorySport { get; set; } = null!;
        public List<PositionResponse> Position { get; set; } = null!;
        public bool Status { get; set; }
    }
}
