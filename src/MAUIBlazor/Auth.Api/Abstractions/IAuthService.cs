using Auth.Api.Model;

namespace Auth.Api.Abstractions;

public interface IAuthService
{
    bool TryAuthorize(string username, string password, out UserIdentity identity);
}
