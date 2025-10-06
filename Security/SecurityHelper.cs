namespace Utilitarios.Security
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>Métodos de hashing y verificación de contraseñas usando ASP.NET Identity.</summary>
    public static class SecurityHelper
    {
        private static readonly PasswordHasher<object> _passwordHasher = new();

        /// <summary>Genera un hash seguro de la contraseña usando el algoritmo por defecto de <see cref="PasswordHasher{TUser}"/>.</summary>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <returns>Hash de la contraseña en formato serializado listo para almacenar en la base de datos.</returns>
        public static string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }
    }
}
