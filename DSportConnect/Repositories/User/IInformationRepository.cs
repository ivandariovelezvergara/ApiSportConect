using DSportConnect.Models.User;
using Entity.Service.User;

namespace DSportConnect.Repositories.User
{
    public interface IInformationRepository
    {
        Task CreateUserAsync(CreateUserRequest user, string codeVerified);
        Task UpdateUserAsync(string id, UserInformation user);
        Task<bool> UserExistsAsync(CreateUserRequest user);
        Task<UserInformation> GetUserPasswordAsync(LoginRequest loginRequest);
        Task ForgotPasswordAsync(string username, string newPassword);
    }
}
