using Domain.Abstractions;
using Domain.Model;
using FastEndpoints;
using Infrastructure;

// dotnet add package FastEndpoints

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();

builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<IEnumerable<User>>(_ => new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Smith", Email = "john@domain.com", HashedPassword = "abc"},
            new User { Id = 2, FirstName = "Kate", LastName = "Smith", Email = "kate@domain.com", HashedPassword = "abc"},
            new User { Id = 3, FirstName = "Bob", LastName = "Smith",  Email = "bob@domain.com", HashedPassword = "abc"},
        });

var app = builder.Build();


app.UseFastEndpoints();
app.Run();
