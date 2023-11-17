using BlazorAuthApp.Model;
using BlazorAuthApp.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlazorAuthApp.Authorization;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private const string AccessTokenKey = "access-token";

    private readonly ILocalStorageService localStorage;
    private readonly AuthApiService Api;

    public CustomAuthenticationStateProvider(ILocalStorageService localStorage, AuthApiService api)
    {
        this.localStorage = localStorage;
        Api = api;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var state = new AuthenticationState(new ClaimsPrincipal());

        var token = await localStorage.GetItemAsStringAsync(AccessTokenKey);

        // dotnet add package System.IdentityModel.Tokens.Jwt
        if (!string.IsNullOrEmpty(token))
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var jwt = tokenHandler.ReadJwtToken(token);

            var identity = new ClaimsIdentity(jwt.Claims, "JWT Tokens");

            state = new AuthenticationState(new ClaimsPrincipal( identity));
        }

        return state;
    }

    public async Task LoginAsync(LoginModel model)
    {
        var token = await Api.Create(model);

        await localStorage.SetItemAsStringAsync(AccessTokenKey, token);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task LogoutAsync()
    {
        await localStorage.RemoveItemAsync(AccessTokenKey);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

    }

}
