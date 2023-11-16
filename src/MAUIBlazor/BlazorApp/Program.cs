using BlazorApp;
using BlazorApp.Services;
using Blazored.LocalStorage;
using Domain.Abstractions;
using Domain.Model;
using Infrastructure;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RazorClassLibrary.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTracker();


await builder.Build().RunAsync();
