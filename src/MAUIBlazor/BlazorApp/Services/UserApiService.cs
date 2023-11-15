using Api.DTO;
using System.Net.Http.Json;

namespace BlazorApp.Services;

public class UserApiService
{
    private readonly HttpClient client;
    public UserApiService(HttpClient client)
    {
        this.client = client;

        client.BaseAddress = new Uri("https://localhost:7014");

    }

    public Task<IEnumerable<UserDTO>?> GetAllAsync()
    {
        return client.GetFromJsonAsync<IEnumerable<UserDTO>>("/api/users");
    }
}
