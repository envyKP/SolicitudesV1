using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;


namespace Transacciones.API.Aplicacion.Servicios
{
    public class JwtTokenService
    {

        // SGA Nota: Esta clave está *hardcodeada* solo para fines de prueba y desarrollo.
        // En un entorno real, este valor debe almacenarse de forma segura (por ejemplo, en Azure Key Vault, AWS Secrets Manager o variables de entorno).
        // Idealmente, el token debería ser generado por un Identity Provider como Keycloak, Auth0 o Azure AD.
        private const string SecretKey = "clave-secreta-super-segura-123";


        public string GenerateJwtToken(int userId, string nombre, string rol)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credentials);

            var payload = new JwtPayload
            {
                { "sub", userId.ToString() },
                { "nombre", nombre },
                { "rol", rol },
                { "iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds() },   // Tiempo de emisión
                { "exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds() }  // Tiempo de expiración
            };

            var token = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);  // Devuelve el JWT generado
        }


    }
}
