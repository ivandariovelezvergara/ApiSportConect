using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace APISportConnect.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizesAttribute : Attribute, IActionFilter
    {
        private readonly string _typeToken;
        private readonly IConfiguration _configuration;

        public AuthorizesAttribute(string typeToken)
        {
            _typeToken = typeToken;

            // Cargar configuración desde appsettings.json
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            var path = context.HttpContext.Request.Path;
            Console.WriteLine($"Path solicitado: {path}");
            Console.WriteLine($"Es Swagger: {path.StartsWithSegments("/swagger")}");
            if (path.StartsWithSegments("/swagger"))
            {
                Console.WriteLine("Solicitud de Swagger, se omite validación.");
                return;
            }

            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                context.Result = new UnauthorizedObjectResult(new { message = "Token faltante o formato inválido." });
                return;
            }

            var token = authorizationHeader.Substring("Bearer ".Length).Trim();

            if (!ValidateJwtToken(token))
            {
                context.Result = new UnauthorizedObjectResult(new { message = "Token inválido." });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No necesitas lógica aquí
        }

        private bool ValidateJwtToken(string token)
        {
            try
            {
                // Leer configuraciones desde appsettings.json
                var key = _typeToken.Equals("settings")
                    ? Encoding.UTF8.GetBytes(_configuration["JwtSettings:KeySettings"])
                    : Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]);

                var issuer = _configuration["JwtSettings:Issuer"];
                var audience = _configuration["JwtSettings:Audience"];

                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return validatedToken != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
