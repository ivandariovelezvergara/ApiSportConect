using DSportConnect.Models.User;
using Entity.Service.User;

namespace DSportConnect.Repositories.User
{
    public interface IOAuth2Repository
    {
        Task<OAuth2> GetByUsernameAsync(LoginRequest request);
        Task<OAuth2> GetByRefreshTokenAsync(string refreshToken);
        Task SaveAsync(OAuth2Request oAuth2);
        Task ResendVerificationCodeAsync(string email, string codeVerified);
    }
}
