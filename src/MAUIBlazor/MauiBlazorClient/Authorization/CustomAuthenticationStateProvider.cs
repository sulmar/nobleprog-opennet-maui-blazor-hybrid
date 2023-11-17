using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorClient.Authorization;

internal partial class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var state = new AuthenticationState(new System.Security.Claims.ClaimsPrincipal());

        return Task.FromResult(state);
    }
}
