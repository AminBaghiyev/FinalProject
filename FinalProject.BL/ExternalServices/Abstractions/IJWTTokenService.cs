using System.Security.Claims;

namespace FinalProject.BL.ExternalServices.Abstractions;

public interface IJWTTokenService
{
    string GenerateToken(IEnumerable<Claim> claims);
    string GetSecretKey();
    string GetIssuer();
    string GetAudience();
}
