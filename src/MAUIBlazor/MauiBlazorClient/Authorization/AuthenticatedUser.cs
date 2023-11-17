using System.Security.Claims;

namespace MauiBlazorClient.Authorization;

internal partial class CustomAuthenticationStateProvider
{
    public class AuthenticatedUser
    {
        public ClaimsPrincipal Principal { get; set; } = new();
    }
}
