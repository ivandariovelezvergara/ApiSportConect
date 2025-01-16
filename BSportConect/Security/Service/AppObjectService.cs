using DSportConnect.Repositories.Security;
using Entity.Service.Security;
using Entity.Service;

namespace BSportConect.Security
{
    public class AppObjectService : IAppObjectService
    {
        private readonly IAppObjectRepository _repository;

        public AppObjectService(IAppObjectRepository repository)
        {
            _repository = repository;
        }

        #region GetAllAppObjectAsync
        public Task<List<AppObjectResponse>> GetAllAppObjectAsync() => _repository.GetAllAppObjectAsync();
        #endregion

        #region GetAppObjectByIdAsync
        public Task<AppObjectResponse?> GetAppObjectByIdAsync(string id) => _repository.GetAppObjectByIdAsync(id);
        #endregion

        #region CreateAppObjectAsync
        public async Task<BaseResponse> CreateAppObjectAsync(AppObjectRequest obj)
        {
            if (string.IsNullOrWhiteSpace(obj.ObjectName))
                throw new ArgumentException("El nombre del objeto no puede estar vacío.");

            _repository.CreateAppObjectAsync(obj);

            return new BaseResponse
            {
                IdStaus = 200,
                IsError = false,
                Message = "La información se ha almacenado correctamente."
            };
        }
        #endregion

        #region UpdateAppObjectAsync
        public async Task<BaseResponse> UpdateAppObjectAsync(string id, AppObjectRequest obj)
        {
            AppObjectResponse? objResponse = await _repository.GetAppObjectByIdAsync(id);
            if (objResponse == null)
                throw new ArgumentException("El ID proporcionado no está registrado en la base de datos.");

            await _repository.UpdateAppObjectAsync(id, obj);
            return new BaseResponse
            {
                IdStaus = 200,
                IsError = false,
                Message = "La información se ha editado correctamente."
            };
        }
        #endregion

        #region DeleteAppObjectAsync
        public Task DeleteAppObjectAsync(string id) => _repository.DeleteAppObjectAsync(id);
        #endregion
    }
}
