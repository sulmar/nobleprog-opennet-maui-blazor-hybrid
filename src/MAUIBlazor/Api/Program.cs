using Domain.Abstractions;
using Domain.Model;
using FastEndpoints;
using Infrastructure;

// dotnet add package FastEndpoints

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();

builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();

builder.Services.AddSingleton<IEnumerable<User>>(_ => new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Smith", Email = "john@domain.com", HashedPassword = "abc"},
            new User { Id = 2, FirstName = "Kate", LastName = "Smith", Email = "kate@domain.com", HashedPassword = "abc"},
            new User { Id = 3, FirstName = "Bob", LastName = "Smith",  Email = "bob@domain.com", HashedPassword = "abc"},
        });

builder.Services.AddSingleton<IEnumerable<Customer>>(_ => new List<Customer>
        {
            new Customer { Id = 1, FirstName = "John", LastName = "Smith"},
            new Customer { Id = 2, FirstName = "Kate", LastName = "Smith"},
            new Customer { Id = 3, FirstName = "Bob", LastName = "Smith"},
        });


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7171", "http://localhost:5003");
        policy.WithMethods("GET");
        policy.AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();

app.UseFastEndpoints();
app.Run();
