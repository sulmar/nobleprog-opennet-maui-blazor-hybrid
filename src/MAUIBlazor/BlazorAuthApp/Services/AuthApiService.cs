using BlazorAuthApp.Model;
using System.Net.Http.Json;

namespace BlazorAuthApp.Services;

public class AuthApiService
{
    private readonly HttpClient _httpClient;

    public AuthApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri("https://localhost:7012");
    }

    public async Task<string> Create(LoginModel model)
    {
        var response = await _httpClient.PostAsJsonAsync("api/token/create", model);

        response.EnsureSuccessStatusCode(); 

        var token = await response.Content.ReadFromJsonAsync<string>();

        return token;
    }
}
