using Entity.Enumerable;
using Entity.Service;
using Entity.Service.Sport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSportConect.Sport
{
    public interface ISportService
    {
        Task<List<SportResponse>> GetAllSportsAsync(); 
        Task<SportResponse> GetSportIdAsync(string id);
        Task<SportResponse> GetSportNameAsync(string name);
        Task<BaseResponse> CreateSportAsync(SportInformationRequest sport);
        Task<BaseResponse> UpdateStatusSportAsync(Guid id, bool status);
        Task<BaseResponse> AddSportDetailAsync(Guid id, EnumEvaluation type, EvaluationRequest newEvaluation);
        Task<BaseResponse> UpdateSportDetailAsync(Guid id, EnumEvaluation type, Guid evaluationId, EvaluationRequest newEvaluation);
        Task<BaseResponse> DeleteSportDetailAsync(Guid id, EnumEvaluation type, Guid evaluationId);
        Task<BaseResponse> AddSportCategoryAsync(Guid id, CategoryRequest newCategory);
        Task<BaseResponse> UpdateSportCategoryAsync(Guid id, Guid categoryId, CategoryRequest newCategory);
        Task<BaseResponse> DeleteSportCategoryAsync(Guid id, Guid categoryId);
        Task<BaseResponse> AddPositionAsync(Guid id, PositionRequest newPosition);
        Task<BaseResponse> UpdatePositionAsync(Guid id, Guid positionId, PositionRequest newPosition);
        Task<BaseResponse> DeletePositionAsync(Guid id, Guid positionId);
    }
}
