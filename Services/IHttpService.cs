using System.Net;

namespace ConsoleAppHttp.Interface;

public interface IHttpService
{
    public Task<T?> PostFromJsonAsync<T>(string resource, T model);
    public Task<T?> GetFromJsonAsync<T>(string resource);
    public Task<T?> PutFromJsonAsync<T>(string resource, T model);
    public Task<HttpStatusCode> DeleteAsync(string resource);
}
