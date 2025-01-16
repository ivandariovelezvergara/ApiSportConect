using Entity.Service;
using Entity.Service.Master;

namespace BSportConect.Master
{
    public interface IParameterService
    {
        Task<List<MasterTableResponse>> GetAllParametersAsync();
        Task<List<ParametersDetailResponse>> GetParametersDetailIdAsync(string id);
        Task<List<ParametersDetailResponse>> GetParametersDetailNameAsync(string masterName);
        Task<BaseResponse> CreateParameterAsync(MasterTableRequest master);
        Task<BaseResponse> AddParameterDetailAsync(Guid masterId, MasterParameterRequest newParameter);
        Task<BaseResponse> UpdateParameterDetailAsync(Guid masterId, Guid parameterId, MasterParameterRequest newParameter);
        Task<BaseResponse> DeleteParameterDetailAsync(Guid masterId, Guid parameterId);
    }
}
