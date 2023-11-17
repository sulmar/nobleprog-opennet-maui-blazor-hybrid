using Auth.Api.Abstractions;
using Auth.Api.Model;
using Microsoft.AspNetCore.Identity;

namespace Auth.Api.Infrastructure;

public class AuthService : IAuthService
{
    private readonly IUserIdentityRepository repository;
    private readonly IPasswordHasher<UserIdentity> passwordHasher;

    public AuthService(IUserIdentityRepository repository, IPasswordHasher<UserIdentity> passwordHasher)
    {
        this.repository = repository;
        this.passwordHasher = passwordHasher;
    }

    public bool TryAuthorize(string username, string password, out UserIdentity identity)
    {
        identity = repository.GetByUsername(username);

        return identity != null && passwordHasher.VerifyHashedPassword(identity, identity.HashedPassword, password) != PasswordVerificationResult.Failed;
    }
}
