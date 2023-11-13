using BlazorApp;
using Domain.Abstractions;
using Domain.Model;
using Infrastructure;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<IEnumerable<User>>(_ => new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Smith", Email = "john@domain.com"},
            new User { Id = 2, FirstName = "Kate", LastName = "Smith", Email = "kate@domain.com"},
            new User { Id = 3, FirstName = "Bob", LastName = "Smith",  Email = "bob@domain.com"},
        });


await builder.Build().RunAsync();
