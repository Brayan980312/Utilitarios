namespace Utilitarios
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    public class JwtService
    {
        private readonly string _secretKey = "NPBA10338052213015585139PESM52542135";
        private readonly string _issuer = "ProyectoFlyHub.Api";
        private readonly string _audience = "ProyectoFlyHub.Clientes";
        //private readonly int _expirationMinutes = 120;
        private readonly int _expirationMinutes = 500;

        public string GenerateToken(int userId, string username, string[] roles)
        {
            // Crear clave de firma
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var rolSeleccionado = roles?.FirstOrDefault();

            string rolNombre = rolSeleccionado switch
            {
                "1" => "Administrador",
                "2" => "Cliente",
                _ => "Desconocido"
            };

            // Crear lista de claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UsuarioId", userId.ToString()),
                new Claim(ClaimTypes.Role, rolNombre)
            };

            // Crear token
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_expirationMinutes),
                signingCredentials: credentials
            );

            // Serializar token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
