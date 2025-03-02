﻿using Entity.Service.User;
using Entity.Service;
using DSportConnect.Repositories.User;
using BSportConect.Utility;
using DSportConnect.Models.User;
using DSportConnect.Repositories.Security;
using Entity.Service.Security;
using Entity.AppSettings;
using Microsoft.Extensions.Options;
using BSportConect.Email;
using BSportConect.Email.Service;
using MongoDB.Driver;

namespace BSportConect.User.Service
{
    public class InformationService : IInformationService
    {
        private readonly UserRol _userRol;
        private readonly IInformationRepository _repository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailService _emailService;

        public InformationService(IOptions<UserRol> userRol, IInformationRepository repository, IRoleRepository roleRepository, IEmailService emailService)
        {
            _userRol = userRol.Value;
            _repository = repository;
            _roleRepository = roleRepository;
            _emailService = emailService;
        }

        #region CreateUserAsync
        public async Task<BaseResponse> CreateUserAsync(CreateUserRequest user)
        {
            bool valid = Verify.IsValidPassword(user.Password);

            valid = await _repository.UserExistsAsync(user);

            if (!Verify.IsValidEmail(user.Mail))
                throw new ArgumentException("El correo Mail no es válido.");

            if (string.IsNullOrWhiteSpace(user.DocumentType))
                throw new ArgumentException("El campo tipo de documento no puede estar vacío.");

            if (!Verify.IsValidPhoneNumber(user.DocumentNumber))
                throw new ArgumentException("El número de documento no es válido.");

            if (!Verify.IsValidName(user.Names))
                throw new ArgumentException("El Nombre no es válido, no debe tener carcateres especiales.");

            if (!Verify.IsValidName(user.FirstName))
                throw new ArgumentException("El Primer apellido no es válido, no debe tener carcateres especiales.");

            if (!Verify.IsValidName(user.FirstName))
                throw new ArgumentException("El Segundo apellido no es válido, no debe tener carcateres especiales.");

            if (!Verify.IsValidPhoneNumber(user.PhoneNumber ))
                throw new ArgumentException("El número telefónico no es válido.");

            user.Password = PasswordHelper.HashPassword(user.Password);
            string codeVerified = Generator.RandomAlphaNumericCode(4);

            await _repository.CreateUserAsync(user, codeVerified);
            string routeHtml = string.Format("{0}Resourse\\Html\\VerifiedMail.html", AppContext.BaseDirectory);
            string bodyMessage = await _emailService.LoadHtmlTemplate(routeHtml);
            await _emailService.SendEmailAsync(user.Mail, "Activar cuenta digital SportConnet", bodyMessage.Replace("{CodeVerified}", codeVerified), true);

            return new BaseResponse
            {
                IdStaus = 200,
                IsError = false,
                Message = "La información se ha almacenado correctamente."
            };
        }
        #endregion

        #region GetUserPasswordAsync
        public async Task<UserResponse> GetUserPasswordAsync(LoginRequest loginRequest, bool isSetting)
        {
            UserInformation _user = await _repository.GetUserPasswordAsync(loginRequest);
            if (!_user.EmailVerified)
            {
                throw new ArgumentException("Tu cuenta no está verificada. Por favor, revisa el correo electrónico que utilizaste al registrarte. Busca un mensaje con el asunto \"Activar cuenta digital SportConnect\", donde encontrarás tu código de verificación. Completa este paso para acceder a todas las funcionalidades de nuestra plataforma.");
            }
            bool validPassword = PasswordHelper.VerifyPassword(_user.Password, loginRequest.Password);
            if (!validPassword)
            {
                throw new ArgumentException("Contraseña invalida.");
            }
            return await UserConvertAsync(_user, isSetting); 
        }
        #endregion

        #region GetUserNameAsync
        public async Task<UserResponse> GetUserNameAsync(string username)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                Username = username,
                Password = ""
            };
            UserInformation _user = await _repository.GetUserPasswordAsync(loginRequest);
            return await UserConvertAsync(_user, false); ;
        }
        #endregion

        #region UserConvertAsync
        private async Task<UserResponse> UserConvertAsync(UserInformation _user, bool isSetting)
        {
            List<Permission> Permissions = new List<Permission>();
            int countAdministrator = 0;
            foreach (string idRol in _user.Roles)
            {
                RoleGetResponse roleGetResponse = await _roleRepository.GetRoleByRoleNameAsync(idRol);
                if (roleGetResponse.RoleName.ToUpper().Equals(_userRol.Administrator.ToUpper()))
                {
                    countAdministrator++;
                }
                foreach (Permission item in roleGetResponse.Permissions)
                {
                    Permissions.Add(item);
                }
            }

            if (isSetting && countAdministrator < 1)
            {
                throw new ArgumentException("El usuario no cuenta con los permisos suficientes para ingresar a esta aplicacion.");
            }
            UserResponse userResponse = new UserResponse();
            userResponse.Mail = _user.Mail;
            userResponse.PersonalInformation = _user.PersonalInformation;
            userResponse.PhysicalCharacteristics = _user.PhysicalCharacteristics;
            userResponse.Permissions = Permissions;
            userResponse.UserSports = _user.UserSports;
            userResponse.Referee = _user.Referee;
            userResponse.SpecialPlayer = _user.SpecialPlayer;
            userResponse.RolEvaluation = _user.RolEvaluation;
            userResponse.CreatedAt = _user.CreatedAt;
            return userResponse;
        }
        #endregion

        #region ForgotPasswordAsync
        public async Task<BaseResponse> ForgotPasswordAsync(string username)
        {
            string newPassword = Generator.RandomAlphaNumericCode(5);
            newPassword = string.Format("New_{0}", newPassword);
            string routeHtml = string.Format("{0}Resourse\\Html\\ForgotPassword.html", AppContext.BaseDirectory);

            string newPasswordHash = PasswordHelper.HashPassword(newPassword);

            await _repository.ForgotPasswordAsync(username, newPasswordHash);

            string bodyMessage = await _emailService.LoadHtmlTemplate(routeHtml);
            await _emailService.SendEmailAsync(username, "Hemos restablecido tu contraseña en SportConnect", bodyMessage.Replace("{NewPassword}", newPassword), true);
            return new BaseResponse
            {
                IdStaus = 200,
                IsError = false,
                Message = "¡Todo listo! Tu contraseña fue actualizada exitosamente. Si detectas alguna actividad inusual, avísanos de inmediato."
            };
        }
        #endregion

        #region ConfirmAccountAsync
        public async Task<BaseResponse> ConfirmAccountAsync(string email, string codeVerified)
        {
            var user = await _repository.GetUserPasswordAsync(new LoginRequest { Username = email });
            if (user == null)
            {
                return new BaseResponse
                {
                    IdStaus = 404,
                    Message = "Usuario no encontrado.",
                    IsError = true
                };
            }

            if (user.CodeVerified != codeVerified)
            {
                return new BaseResponse
                {
                    IdStaus = 400,
                    Message = "El código de verificación no es válido.",
                    IsError = true
                };
            }

            if (user.EmailVerified)
            {
                return new BaseResponse
                {
                    IdStaus = 400,
                    Message = "El correo ya fue verificado previamente.",
                    IsError = true
                };
            }

            user.EmailVerified = true;
            user.CodeVerified = null; // Eliminar el código de verificación
            await _repository.UpdateUserAsync(user.Id.ToString(), user);

            return new BaseResponse
            {
                IdStaus = 200,
                Message = "Correo electrónico verificado con éxito.",
                IsError = false
            };
        }
        #endregion

        #region RetrieveEmailByDocumentNumberAsync
        public async Task<BaseResponse> RetrieveEmailByDocumentNumberAsync(string documentNumber)
        {
            // Buscar usuario por número de documento
            var user = await _repository.GetUserByDocumentNumberAsync(documentNumber);
            if (user == null)
            {
                return new BaseResponse
                {
                    IdStaus = 404,
                    Message = "No se encontró un usuario con este número de documento.",
                    IsError = true
                };
            }

            // Enmascarar el email
            string maskedEmail = MaskEmail(user.Mail);

            // Retornar el email enmascarado
            return new BaseResponse
            {
                IdStaus = 200,
                Message = maskedEmail,
                IsError = false
            };
        }

        // Método para enmascarar el email
        private string MaskEmail(string email)
        {
            var emailParts = email.Split('@');
            var localPart = emailParts[0];
            var domainPart = emailParts[1];

            // Si el local part es muy corto, enmascarar solo el segundo carácter
            if (localPart.Length <= 3)
            {
                return $"{localPart[0]}*{localPart[^1]}@{domainPart}";
            }

            // Enmascarar parcialmente el local part dejando los primeros 2 y últimos 2 caracteres visibles
            var visibleStart = localPart.Substring(0, 2);
            var visibleEnd = localPart.Substring(localPart.Length - 2);
            var maskedMiddle = new string('*', localPart.Length - 4);

            return $"{visibleStart}{maskedMiddle}{visibleEnd}@{domainPart}";
        }

        #endregion
    }
}
