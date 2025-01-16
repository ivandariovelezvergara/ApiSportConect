using DSportConnect.Repositories.Master;
using Entity.Service.Security;
using Entity.Service;
using Entity.Service.Master;
using DSportConnect.Models.Master;
using MongoDB.Driver;
using System.Data.Common;

namespace BSportConect.Master.Service
{
    public class ParameterService : IParameterService
    {
        private readonly IParameterRepository _repository;

        public ParameterService(IParameterRepository repository)
        {
            _repository = repository;
        }

        #region GetAllParametersAsync
        public Task<List<MasterTableResponse>> GetAllParametersAsync() => _repository.GetAllParametersAsync();
        #endregion

        #region GetParametersDetailIdAsync
        public Task<List<ParametersDetailResponse>> GetParametersDetailIdAsync(string id) => _repository.GetParametersDetailIdAsync(id);
        #endregion

        #region GetParametersDetailNameAsync
        public Task<List<ParametersDetailResponse>> GetParametersDetailNameAsync(string masterName) => _repository.GetParametersDetailNameAsync(masterName);
        #endregion

        #region CreateParameterAsync
        public async Task<BaseResponse> CreateParameterAsync(MasterTableRequest master)
        {
            if (string.IsNullOrWhiteSpace(master.MasterName))
                throw new ArgumentException("El campo MasterName no puede estar vacío.");

            _repository.CreateParameterAsync(master);

            return new BaseResponse
            {
                IdStaus = 200,
                IsError = false,
                Message = "La información se ha almacenado correctamente."
            };
        }
        #endregion

        #region AddParameterDetailAsync
        public async Task<BaseResponse> AddParameterDetailAsync(Guid masterId, MasterParameterRequest newParameter)
        {
            bool result = await _repository.AddParameterDetailAsync(masterId, newParameter);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha agregado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro informacion de maestra para editar.");
            }
        }
        #endregion

        #region UpdateParameterDetailAsync
        public async Task<BaseResponse> UpdateParameterDetailAsync(Guid masterId, Guid parameterId, MasterParameterRequest newParameter)
        {
            bool result = await _repository.UpdateParameterDetailAsync(masterId, parameterId, newParameter);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha editado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro informacion de maestra para editar.");
            }
        }
        #endregion

        #region DeleteParameterDetailAsync
        public async Task<BaseResponse> DeleteParameterDetailAsync(Guid masterId, Guid parameterId)
        {
            bool result = await _repository.DeleteParameterDetailAsync(masterId, parameterId);
            if (result)
            {
                return new BaseResponse
                {
                    IdStaus = 200,
                    IsError = false,
                    Message = "La información se ha editado correctamente."
                };
            }
            else
            {
                throw new ArgumentException("No encontro informacion de maestra para editar.");
            }
        }
        #endregion
    }
}
