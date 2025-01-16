using BSportConect.User;
using BSportConect.Utility;
using DSportConnect.Models.Security;
using DSportConnect.Models.User;
using Entity.AppSettings;
using Entity.Service;
using Entity.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace APISportConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IOAuth2Service _oauth2Service;
        private readonly IInformationService _informationService;

        public OAuthController(IOptions<JwtSettings> jwtOptions, IOAuth2Service oauth2Service, IInformationService informationService)
        {
            _jwtSettings = jwtOptions.Value;
            _oauth2Service = oauth2Service;
            _informationService = informationService;
        }

        #region Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Entity.Service.User.LoginRequest request)
        {
            BaseResponse response;
            try
            {
                var user = await _informationService.GetUserPasswordAsync(request, false);

                OAuth2Request oAuth2 = new OAuth2Request()
                {
                    Username = request.Username,
                    RefreshToken = _oauth2Service.GenerateRefreshToken(),
                    RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays)
                };

                var accessToken = GenerateAccessToken(false, request.Username, user.PersonalInformation.Names, user.PersonalInformation.FirstName, 
                                                        user.PersonalInformation.LastName, user.PersonalInformation.Gender);

                await _oauth2Service.SaveAsync(oAuth2);

                LoginResponse loginResponse = new LoginResponse()
                {
                    Token = accessToken,
                    RefreshToken = oAuth2.RefreshToken,
                    User = user
                };

                return Ok(loginResponse);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }            
        }
        #endregion

        #region LoginSettings
        [HttpPost("LoginSettings")]
        public async Task<IActionResult> LoginSettings([FromBody] Entity.Service.User.LoginRequest request)
        {
            BaseResponse response;
            try
            {
                var user = await _informationService.GetUserPasswordAsync(request, true);

                OAuth2Request oAuth2 = new OAuth2Request()
                {
                    Username = request.Username,
                    RefreshToken = _oauth2Service.GenerateRefreshToken(),
                    RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays)
                };

                var accessToken = GenerateAccessToken(true, request.Username, user.PersonalInformation.Names, user.PersonalInformation.FirstName,
                                                        user.PersonalInformation.LastName, user.PersonalInformation.Gender);

                await _oauth2Service.SaveAsync(oAuth2);

                LoginResponse loginResponse = new LoginResponse()
                {
                    Token = accessToken,
                    RefreshToken = oAuth2.RefreshToken,
                    User = user
                };

                return Ok(loginResponse);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region RefreshToken
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> Refresh([FromBody] Entity.Service.User.RefreshRequest request)
        {
            BaseResponse response;
            try
            {
                UserResponse user = await _informationService.GetUserNameAsync(request.Username);
                if (user == null)
                {
                    throw new ArgumentException("El usuario no existe.");
                }
                OAuth2 oauth = await _oauth2Service.GetByRefreshTokenAsync(request.RefreshToken);
                if (oauth == null)
                {
                    throw new ArgumentException("El RefreshToken no existe.");
                }
                OAuth2Request oAuth2 = new OAuth2Request()
                {
                    Username = request.Username,
                    RefreshToken = _oauth2Service.GenerateRefreshToken(),
                    RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays)
                };

                var accessToken = GenerateAccessToken(false, request.Username, user.PersonalInformation.Names, user.PersonalInformation.FirstName,
                                                        user.PersonalInformation.LastName, user.PersonalInformation.Gender);

                await _oauth2Service.SaveAsync(oAuth2);

                LoginResponse loginResponse = new LoginResponse()
                {
                    Token = accessToken,
                    RefreshToken = oAuth2.RefreshToken,
                    User = user
                };

                return Ok(loginResponse);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region GenerateAccessToken
        private string GenerateAccessToken(bool isSettings, string username, string name, string firstName, string lastName, string gender)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username)
            };

            SymmetricSecurityKey key;
            if (isSettings)
            {
                key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.KeySettings));
            }
            else
            {
                key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            }
            
            if (key.KeySize < 256)
            {
                throw new ArgumentException("Se presenta un error con la seguridad de la API.");
            }

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_jwtSettings.TokenExpiryDays),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

        #region ResendVerificationCode
        [HttpPost("ResendVerificationCode/{email}")]
        public async Task<IActionResult> ResendVerificationCode(string email)
        {
            BaseResponse response;
            try
            {
                response = await _oauth2Service.ResendVerificationCodeAsync(email);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion

        #region ForgotPassword
        [HttpPost("ForgotPassword/{email}")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            BaseResponse response;
            try
            {
                response = await _informationService.ForgotPasswordAsync(email);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 400,
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    IdStaus = 404,
                    Message = ex.Message,
                    IsError = true
                };
                return NotFound(response);
            }
        }
        #endregion
    }
}
