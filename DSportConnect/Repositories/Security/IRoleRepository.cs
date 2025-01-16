using DSportConnect.Models.Security;
using Entity.Service.Security;

namespace DSportConnect.Repositories.Security
{
    public interface IRoleRepository
    {
        Task<List<RoleGetResponse>> GetAllRolesAsync();
        Task<RoleGetResponse?> GetRoleByIdAsync(string id);
        Task<RoleGetResponse?> GetRoleByRoleNameAsync(string roleName);
        Task CreateRoleAsync(RoleRequest role);
        Task UpdateRoleAsync(string id, RoleRequest role);
        Task DeleteRoleAsync(string id);
    }
}
