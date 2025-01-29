using Entity.Service.User;
using Entity.Service;
using DSportConnect.Models.User;

namespace BSportConect.User
{
    public interface IInformationService
    {
        Task<BaseResponse> CreateUserAsync(CreateUserRequest user);
        Task<UserResponse> GetUserPasswordAsync(LoginRequest loginRequest, bool isSetting);
        Task<UserResponse> GetUserNameAsync(string username);
        Task<BaseResponse> ForgotPasswordAsync(string username);
        Task<BaseResponse> ConfirmAccountAsync(string email, string codeVerified);
        Task<BaseResponse> RetrieveEmailByDocumentNumberAsync(string documentNumber);
    }
}
