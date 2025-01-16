using DSportConnect.Models.Security;
using Entity.Service;
using Entity.Service.Security;

namespace BSportConect.Security
{
    public interface IRoleService
    {
        Task<List<RoleGetResponse>> GetAllRolesAsync();
        Task<RoleGetResponse?> GetRoleByIdAsync(string id);
        Task<BaseResponse> CreateRoleAsync(RoleRequest role);
        Task<BaseResponse> UpdateRoleAsync(string id, RoleRequest role);
        Task DeleteRoleAsync(string id);
    }
}
