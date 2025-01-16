using BSportConect.Email;
using BSportConect.Sport;
using BSportConect.Utility;
using DSportConnect.Models.User;
using DSportConnect.Repositories.Sport;
using DSportConnect.Repositories.User;
using Entity.Service;
using Entity.Service.User;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BSportConect.User.Service
{
    public class OAuth2Service : IOAuth2Service
    {
        private readonly IOAuth2Repository _repository;
        private readonly IEmailService _emailService;

        public OAuth2Service(IOAuth2Repository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        #region GetByUsernameAsync
        public async Task<OAuth2> GetByUsernameAsync(Entity.Service.User.LoginRequest request)
        {
            return await _repository.GetByUsernameAsync(request);
        }
        #endregion

        #region GetByRefreshTokenAsync
        public async Task<OAuth2> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _repository.GetByRefreshTokenAsync(refreshToken);
        }
        #endregion

        #region SaveAsync
        public async Task<BaseResponse> SaveAsync(OAuth2Request oAuth2)
        {
            if (string.IsNullOrWhiteSpace(oAuth2.Username))
                throw new ArgumentException("El campo UserName no puede estar vacío.");

            await _repository.SaveAsync(oAuth2);

            return new BaseResponse
            {
                IdStaus = 200,
                IsError = false,
                Message = "La información se ha almacenado correctamente."
            };
        }
        #endregion

        #region GenerateRefreshToken
        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }
        #endregion

        #region ResendVerificationCodeAsync
        public async Task<BaseResponse> ResendVerificationCodeAsync(string email)
        {
            string codeVerified = Generator.RandomAlphaNumericCode(4);
            _repository.ResendVerificationCodeAsync(email, codeVerified);
            string routeHtml = string.Format("{0}Resourse\\Html\\VerifiedMail.html", AppContext.BaseDirectory);
            string bodyMessage = await _emailService.LoadHtmlTemplate(routeHtml);
            await _emailService.SendEmailAsync(email, "Activar cuenta digital SportConnet", bodyMessage.Replace("{CodeVerified}", codeVerified), true);
            return new BaseResponse
            {
                IdStaus = 200,
                IsError = false,
                Message = "El código de verificación ha sido enviado exitosamente. Por favor, revisa tu correo electrónico para completar el proceso de activación."
            };
        }
        #endregion

    }
}
