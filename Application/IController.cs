using System.Net;

namespace ConsoleAppHttp.Application;
public interface IController
{
    public Task<T?> PostFromJsonAsync<T>(string resource, T model) where T : class;
    public Task<T?> GetFromJsonAsync<T>(string resource) where T : class;
    public Task<T?> PutFromJsonAsync<T>(string resource, T model) where T : class;
    public Task<HttpStatusCode?> DeleteAsync(string resource);
}
