using DSportConnect.Models.Security;
using DSportConnect.Repositories.Security;
using Entity.Service;
using Entity.Service.Security;
using System.Linq;

namespace BSportConect.Security.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IAppObjectRepository _objRepository;

        public RoleService(IRoleRepository repository, IAppObjectRepository objRepository)
        {
            _repository = repository;
            _objRepository = objRepository;
        }

        #region GetAllRolesAsync
        public Task<List<RoleGetResponse>> GetAllRolesAsync() => _repository.GetAllRolesAsync();
        #endregion

        #region GetRoleByIdAsync
        public Task<RoleGetResponse?> GetRoleByIdAsync(string id) => _repository.GetRoleByIdAsync(id);
        #endregion

        #region CreateRoleAsync
        public async Task<BaseResponse> CreateRoleAsync(RoleRequest role)
        {
            AppObjectResponse obj;
            if (string.IsNullOrWhiteSpace(role.RoleName))
                throw new ArgumentException("El nombre del rol no puede estar vacío.");

            foreach (var permission in role.Permissions)
            {
                if (string.IsNullOrWhiteSpace(permission.ObjName) || permission.Id == null)
                    throw new ArgumentException("El objeto no puede estar vacío.");

                obj = await _objRepository.GetAppObjectByIdAsync(permission.Id.ToString());
                if (obj == null)
                    throw new ArgumentException($"El objeto {permission.Id} no existe.");

                if (obj.ObjectName != permission.ObjName)
                    throw new ArgumentException($"El nombre del objeto {permission.ObjName} no es igual al almacenado en la base de datos.");
            }

            RoleGetResponse? roleGetResponse = await _repository.GetRoleByRoleNameAsync(role.RoleName);
            if (roleGetResponse != null)
                throw new ArgumentException("El nombre del rol ya existe en la base de datos.");

            _repository.CreateRoleAsync(role);

            return new BaseResponse
            {
                IdStaus = 200,
                IsError = false,
                Message = "La información se ha almacenado correctamente."
            };
        }
        #endregion

        #region UpdateRoleAsync
        public async Task<BaseResponse> UpdateRoleAsync(string id, RoleRequest role)
        {
            AppObjectResponse obj;
            RoleGetResponse? roleGetResponse = await _repository.GetRoleByIdAsync(id);
            if (roleGetResponse == null)
                throw new ArgumentException("El ID proporcionado no está registrado en la base de datos.");

            if (string.IsNullOrWhiteSpace(role.RoleName))
                throw new ArgumentException("El nombre del rol no puede estar vacío.");

            foreach (var permission in role.Permissions)
            {
                if (string.IsNullOrWhiteSpace(permission.ObjName) || permission.Id == null)
                    throw new ArgumentException("El objeto no puede estar vacío.");

                obj = await _objRepository.GetAppObjectByIdAsync(permission.Id.ToString());
                if (obj == null)
                    throw new ArgumentException($"El objeto {permission.Id} no existe.");

                if (obj.ObjectName != permission.ObjName)
                    throw new ArgumentException($"El nombre del objeto {permission.ObjName} no es igual al almacenado en la base de datos.");
            }

            roleGetResponse = await _repository.GetRoleByRoleNameAsync(role.RoleName);
            if (roleGetResponse != null && !roleGetResponse.Id.ToString().Equals(id))
                throw new ArgumentException("El nombre del rol ya existe en la base de datos.");

            await _repository.UpdateRoleAsync(id, role);
            return new BaseResponse
            {
                IdStaus = 200,
                IsError = false,
                Message = "La información se ha editado correctamente."
            };
        }
        #endregion

        #region DeleteRoleAsync
        public Task DeleteRoleAsync(string id) => _repository.DeleteRoleAsync(id);
        #endregion
    }
}
