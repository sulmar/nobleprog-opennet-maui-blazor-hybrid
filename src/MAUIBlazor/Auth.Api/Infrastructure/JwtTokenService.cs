using Auth.Api.Abstractions;
using Auth.Api.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Api.Infrastructure;

// dotnet add package System.IdentityModel.Tokens.Jwt
public class JwtTokenService : ITokenService
{
    public string Create(UserIdentity identity)
    {
        var claims = new List<Claim>();
        claims.Add(new Claim(JwtRegisteredClaimNames.Name, identity.Username));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, identity.Email));
        claims.Add(new Claim(ClaimTypes.Role, "developer"));
        claims.Add(new Claim(ClaimTypes.Role, "trainer"));
        claims.Add(new Claim("licence", "B"));


        var secretKey = "your-256-bit-secret-your-256-bit-secret-your-256-bit-secret-your-256-bit-secret";
        var key = Encoding.ASCII.GetBytes(secretKey);

        var credentials = new SymmetricSecurityKey(key);
        var singingCredentials = new SigningCredentials(credentials, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            issuer: "Abc",
            audience: "Xyz",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: singingCredentials
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;

    }
}
