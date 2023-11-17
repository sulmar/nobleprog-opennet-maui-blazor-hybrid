using Auth.Api.Model;

namespace Auth.Api.Abstractions;

public interface IUserIdentityRepository
{
    UserIdentity GetByUsername(string username);
}
