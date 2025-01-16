using Entity.Service.Master;

namespace DSportConnect.Repositories.Master
{
    public interface IParameterRepository
    {
        Task<List<MasterTableResponse>> GetAllParametersAsync();
        Task<List<ParametersDetailResponse>> GetParametersDetailIdAsync(string id);
        Task<List<ParametersDetailResponse>> GetParametersDetailNameAsync(string masterName);
        Task CreateParameterAsync(MasterTableRequest master);
        Task<bool> AddParameterDetailAsync(Guid masterId, MasterParameterRequest newParameter);
        Task<bool> UpdateParameterDetailAsync(Guid masterId, Guid parameterId, MasterParameterRequest newParameter);
        Task<bool> DeleteParameterDetailAsync(Guid masterId, Guid parameterId);
    }
}
