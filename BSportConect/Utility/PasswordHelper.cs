using Microsoft.AspNetCore.Identity;

namespace BSportConect.Utility
{
    public static class PasswordHelper
    {
        private static readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

        /// <summary>
        /// Cifra una contraseña utilizando un algoritmo seguro con salting y hashing.
        /// </summary>
        /// <param name="password">La contraseña a cifrar.</param>
        /// <returns>El hash seguro de la contraseña.</returns>
        public static string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        /// <summary>
        /// Verifica si una contraseña coincide con su hash almacenado.
        /// </summary>
        /// <param name="hashedPassword">El hash almacenado de la contraseña.</param>
        /// <param name="providedPassword">La contraseña ingresada por el usuario.</param>
        /// <returns>True si las contraseñas coinciden; False de lo contrario.</returns>
        public static bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            if (string.IsNullOrWhiteSpace(hashedPassword) || string.IsNullOrWhiteSpace(providedPassword))
            {
                return false;
            }
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
