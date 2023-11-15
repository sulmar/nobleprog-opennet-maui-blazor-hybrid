using Api.DTO;
using System.Net.Http.Json;

namespace BlazorApp.Services;

public class CustomerApiService
{
    private readonly HttpClient client;
    public CustomerApiService(HttpClient client) => this.client = client;
    public Task<CustomerDTO> GetByIdAsync(int id) => client.GetFromJsonAsync<CustomerDTO>($"/api/customers/{id}");
}
