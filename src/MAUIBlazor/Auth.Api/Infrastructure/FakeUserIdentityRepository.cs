using Auth.Api.Abstractions;
using Auth.Api.Model;
using Microsoft.AspNetCore.Identity;

namespace Auth.Api.Infrastructure;

public class FakeUserIdentityRepository : IUserIdentityRepository
{
    private readonly IPasswordHasher<UserIdentity> _passwordHasher;

    public FakeUserIdentityRepository(IPasswordHasher<UserIdentity> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public UserIdentity GetByUsername(string username)
    {
        var identity = new UserIdentity { Username = username, Email = $"{username}@domain.com" };
        identity.HashedPassword = _passwordHasher.HashPassword(identity, "123");
        return identity;
}
}
