using BlazorApp.Services;
using Blazored.LocalStorage;
using Domain.Abstractions;
using Domain.Model;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace RazorClassLibrary.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTracker(this IServiceCollection Services)
        {
            // dotnet add package Microsoft.Extensions.Http
            Services.AddHttpClient<UserApiService>();
            Services.AddHttpClient<CustomerApiService>();

            Services.AddScoped<UserApiService>();
            Services.AddScoped<CustomerApiService>();

            Services.AddBlazoredLocalStorage();

            Services.AddSingleton<IMessageService, FakeMessageService>();

            Services.AddSingleton<IEnumerable<User>>(_ => new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Smith", Email = "john@domain.com"},
            new User { Id = 2, FirstName = "Kate", LastName = "Smith", Email = "kate@domain.com"},
            new User { Id = 3, FirstName = "Bob", LastName = "Smith",  Email = "bob@domain.com"},
        });

            return Services;
        }
    }
}
