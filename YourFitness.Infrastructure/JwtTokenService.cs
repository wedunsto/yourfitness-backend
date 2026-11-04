using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using YourFitness.Application;
using YourFitness.Domain;

namespace YourFitness.Infrastructure;

public class JwtTokenService : ITokenService
{
    private readonly JwtOptions _options;

    // Creates a token service using the given JWT settings.
    public JwtTokenService(JwtOptions options)
    {
        _options = options;
    }

    // Creates a signed, expiring token identifying the given user
    public string CreateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SigningKey));

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _options.Issuer,
            Audience = _options.Audience,
            Expires = DateTime.UtcNow.AddMinutes(_options.ExpiryMinutes),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
            Claims = new Dictionary<string, object>
            {
                [JwtRegisteredClaimNames.Sub] = user.Id,
                [JwtRegisteredClaimNames.Name] = user.Username
            }
        };

        return new JsonWebTokenHandler().CreateToken(descriptor);
    }
}