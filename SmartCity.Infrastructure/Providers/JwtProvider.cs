using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartCity.Application.Abstractions.Providers;
using SmartCity.Domain.Entities;
using SmartCity.Infrastructure.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartCity.Infrastructure.Providers;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider {
    private readonly JwtOptions _options = options.Value;

    public string GenerateToken(MUser user) {
        var claims = new Claim[] {
            new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email)
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddMinutes(5),
            signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenValue;
    }
}
