using DSportConnect.Models.User;
using Entity.Service;
using Entity.Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSportConect.User
{
    public interface IOAuth2Service
    {
        Task<OAuth2> GetByUsernameAsync(LoginRequest request);
        Task<OAuth2> GetByRefreshTokenAsync(string refreshToken);
        Task<BaseResponse> SaveAsync(OAuth2Request oAuth2);
        string GenerateRefreshToken();
        Task<BaseResponse> ResendVerificationCodeAsync(string email);
    }
}
