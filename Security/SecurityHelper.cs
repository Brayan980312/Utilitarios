namespace Utilitarios.Security
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// Métodos de hashing y verificación de contraseñas usando ASP.NET Identity.
    /// </summary>
    public static class SecurityHelper
    {
        private static readonly PasswordHasher<object> _passwordHasher = new();

        /// <summary>
        /// Genera un hash seguro de la contraseña.
        /// </summary>
        public static string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        /// <summary>
        /// Verifica si una contraseña coincide con el hash almacenado.
        /// </summary>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
