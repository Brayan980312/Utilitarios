namespace Utilitarios.Security
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>Métodos de hashing y verificación de contraseñas usando ASP.NET Identity.</summary>
    public static class SecurityHelper
    {
        private static readonly PasswordHasher<object> _passwordHasher = new();

        /// <summary>Genera un hash seguro de la contraseña usando el algoritmo por defecto de <see cref="PasswordHasher{TUser}"/>.
        /// </summary>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <returns>Hash de la contraseña en formato serializado listo para almacenar en la base de datos.</returns>
        public static string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        /// <summary>Verifica si una contraseña en texto plano coincide con el hash almacenado.</summary>
        /// <param name="password">Contraseña en texto plano que se desea verificar.</param>
        /// <param name="hashedPassword">Hash previamente almacenado (producido por <see cref="HashPassword"/>).</param>
        /// <returns><c>true</c> si la contraseña coincide; <c>false</c> en caso contrario.</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
