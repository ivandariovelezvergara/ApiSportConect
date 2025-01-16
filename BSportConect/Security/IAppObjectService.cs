using Entity.Service.Security;
using Entity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSportConect.Security
{
    public interface IAppObjectService
    {
        Task<List<AppObjectResponse>> GetAllAppObjectAsync();
        Task<AppObjectResponse?> GetAppObjectByIdAsync(string id);
        Task<BaseResponse> CreateAppObjectAsync(AppObjectRequest obj);
        Task<BaseResponse> UpdateAppObjectAsync(string id, AppObjectRequest obj);
        Task DeleteAppObjectAsync(string id);
    }
}
