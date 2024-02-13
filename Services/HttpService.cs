using System.Net;
using System.Net.Http.Json;
using ConsoleAppHttp.Interface;

namespace ConsoleAppHttp.Services;
public class HttpService : IHttpService
{
    private HttpClient _httpClient;

    public HttpService(HttpClient httpClient, Uri baseAddress)
    {
        _httpClient = new()
        {
            BaseAddress = baseAddress
        };
    }

    public async Task<T?> PostFromJsonAsync<T>(string resource, T model)
    {
        using var response = await _httpClient.PostAsJsonAsync<T>(resource, model);
        response.EnsureSuccessStatusCode().WriteRequest();
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<T?> GetFromJsonAsync<T>(string resource)
    {
        Print.PrinColor(ConsoleColor.White, $"GET {_httpClient.BaseAddress}{resource} HTTP/1.1");
        var response = await _httpClient.GetFromJsonAsync<T>(resource);
        return response;
    }

    public async Task<T?> PutFromJsonAsync<T>(string resource, T model)
    {
        using var response = await _httpClient.PutAsJsonAsync(resource, model);
        response.EnsureSuccessStatusCode().WriteRequest();
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<HttpStatusCode> DeleteAsync(string resource)
    {
        using var response = await _httpClient.DeleteAsync(resource);
        response.EnsureSuccessStatusCode().WriteRequest();
        return response.StatusCode;
    }
}
