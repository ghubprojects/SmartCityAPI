using SmartCity.Domain.Entities;

namespace SmartCity.Application.Abstractions.Providers;
public interface IJwtProvider {
    string GenerateToken(MUser user);
}
