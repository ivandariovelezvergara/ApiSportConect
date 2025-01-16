using System.Text.RegularExpressions;

namespace BSportConect.Utility
{
    public static class Verify
    {
        /// <summary>
        /// Valida si un correo electrónico tiene un formato válido.
        /// </summary>
        /// <param name="email">El correo electrónico a validar.</param>
        /// <returns>True si el formato es válido, False en caso contrario.</returns>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Valida si un nombre contiene solo letras y espacios.
        /// </summary>
        /// <param name="name">El nombre a validar.</param>
        /// <returns>True si el nombre es válido, False en caso contrario.</returns>
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            string namePattern = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$";
            return Regex.IsMatch(name, namePattern, RegexOptions.Compiled);
        }

        /// <summary>
        /// Valida si un número telefónico tiene un formato válido.
        /// </summary>
        /// <param name="phoneNumber">El número telefónico a validar.</param>
        /// <returns>True si el número es válido, False en caso contrario.</returns>
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return false;
            }
            string phonePattern = @"^\+?[1-9]\d{1,14}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        /// <summary>
        /// Valida si un número de documento de identidad tiene un formato válido.
        /// </summary>
        /// <param name="documentNumber">El número de documento a validar.</param>
        /// <returns>True si el documento es válido, False en caso contrario.</returns>
        public static bool IsValidDocument(string documentNumber)
        {
            if (string.IsNullOrWhiteSpace(documentNumber))
            {
                return false;
            }
            string documentPattern = @"^[a-zA-Z0-9\- ]{4,20}$";
            return Regex.IsMatch(documentNumber, documentPattern);
        }

        /// <summary>
        /// Valida si una contraseña cumple con las condiciones mínimas.
        /// </summary>
        /// <param name="password">La contraseña a validar.</param>
        /// <returns>True si la contraseña cumple las condiciones, False en caso contrario.</returns>
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("El campo Password no puede estar vacío.");
            }
            if (password.Length < 8 || password.Length > 20)
            {
                throw new ArgumentException("La contraseña debe tener entre 8 y 20 caracteres.");
            }
            if (!password.Any(char.IsUpper))
            {
                throw new ArgumentException("La contraseña debe tener al menos una letra mayúscula.");
            }
            if (!password.Any(char.IsLower))
            {
                throw new ArgumentException("La contraseña debe tener al menos una letra minúscula.");
            }
            if (!password.Any(char.IsDigit))
            {
                throw new ArgumentException("La contraseña debe tener al menos una letra número.");
            }
            // Validar al menos un carácter especial.
            //string specialCharacters = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/`~";
            //if (!password.Any(c => specialCharacters.Contains(c)))
            //{
            //    return false;
            //}

            // Validar que no contenga espacios.
            if (password.Contains(" "))
            {
                throw new ArgumentException("La contraseña no debe contener espacios.");
            }
            return true;
        }
    }
}
