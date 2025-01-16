using Entity.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSportConnect.Repositories.Security
{
    public interface IAppObjectRepository
    {
        Task<List<AppObjectResponse>> GetAllAppObjectAsync();
        Task<AppObjectResponse?> GetAppObjectByIdAsync(string id);
        Task<AppObjectResponse?> GetAppObjectByNameAsync(string objectName);
        Task CreateAppObjectAsync(AppObjectRequest obj);
        Task UpdateAppObjectAsync(string id, AppObjectRequest obj);
        Task DeleteAppObjectAsync(string id);
    }
}
