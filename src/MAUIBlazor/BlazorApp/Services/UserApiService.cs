using Api.DTO;
using System.Net.Http.Json;

namespace BlazorApp.Services;

public class UserApiService
{
    private readonly HttpClient client;
    public UserApiService(HttpClient client) => this.client = client;
    public Task<IEnumerable<UserDTO>?> GetAllAsync()
    {
        return client.GetFromJsonAsync<IEnumerable<UserDTO>>("/api/users");
    }
}
