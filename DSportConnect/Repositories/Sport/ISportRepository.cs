using Entity.Enumerable;
using Entity.Service.Sport;

namespace DSportConnect.Repositories.Sport
{
    public interface ISportRepository
    {
        Task<List<SportResponse>> GetAllSportsAsync();
        Task<SportResponse> GetSportIdAsync(string id);
        Task<SportResponse> GetSportNameAsync(string name);
        Task CreateSportAsync(SportInformationRequest sport);
        Task<bool> UpdateStatusSportAsync(Guid id, bool status);
        Task<bool> AddSportDetailAsync(Guid id, EnumEvaluation type, EvaluationRequest newEvaluation);
        Task<bool> UpdateSportDetailAsync(Guid id, EnumEvaluation type, Guid evaluationId, EvaluationRequest newEvaluation);
        Task<bool> DeleteSportDetailAsync(Guid id, EnumEvaluation type, Guid evaluationId);
        Task<bool> AddSportCategoryAsync(Guid id, CategoryRequest newCategory);
        Task<bool> UpdateSportCategoryAsync(Guid id, Guid categoryId, CategoryRequest newCategory);
        Task<bool> DeleteSportCategoryAsync(Guid id, Guid categoryId);
        Task<bool> AddPositionAsync(Guid id, PositionRequest newPosition);
        Task<bool> UpdatePositionAsync(Guid id, Guid positionId, PositionRequest newPosition);
        Task<bool> DeletePositionAsync(Guid id, Guid positionId);
    }
}
