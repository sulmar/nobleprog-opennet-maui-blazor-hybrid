using Auth.Api.Abstractions;
using Auth.Api.Infrastructure;
using Auth.Api.Model;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IUserIdentityRepository, FakeUserIdentityRepository>();
builder.Services.AddSingleton<ITokenService, JwtTokenService>();
builder.Services.AddSingleton<IPasswordHasher<UserIdentity>, PasswordHasher<UserIdentity>>();   

var app = builder.Build();

app.MapGet("/", () => "Hello Auth.API!");



// POST /api/token/create
// {
//  "login":"john", "password":"123"
// }

app.MapPost("/api/token/create", (LoginModel model, IAuthService authService, ITokenService tokenService ) =>
{
    if (authService.TryAuthorize(model.Username, model.Password, out var identity))
    {
        string token = tokenService.Create(identity);

        return Results.Ok(token);

    }

    return Results.Problem("Invalid username or password", title: "Authorization failed");
});

app.Run();
