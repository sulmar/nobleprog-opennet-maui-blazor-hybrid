using Api.Fakers;
using Bogus;
using Domain.Abstractions;
using Domain.Model;
using FastEndpoints;
using FastEndpoints.Security;
using Infrastructure;

// dotnet add package FastEndpoints
// dotnet add package FastEndpoints.Security

var secretKey = "your-256-bit-secret-your-256-bit-secret-your-256-bit-secret-your-256-bit-secret";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints()
    .AddJWTBearerAuth(secretKey) 
    .AddAuthorization();


builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
builder.Services.AddSingleton<Faker<User>, UserFaker>();

builder.Services.AddSingleton<IEnumerable<User>>(sp =>
{
    var faker = sp.GetRequiredService<Faker<User>>();

    return faker.Generate(1000);
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
app.UseAuthentication()
   .UseAuthorization();

app.UseFastEndpoints();
app.Run();
