using System.Net;
using ConsoleAppHttp.Interface;

namespace ConsoleAppHttp.Application;
public class Controller : IController
{
    private readonly IHttpService _httpService;

    public Controller(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<T?> PostFromJsonAsync<T>(string resource, T model) where T : class
    {
        try
        {
            var response = await _httpService.PostFromJsonAsync(resource, model);
            return response;
        }
        catch(Exception ex)
        {
            Print.PrinColor(ConsoleColor.Red, ex.Message);
            return null;
        }
    }

    public async Task<T?> GetFromJsonAsync<T>(string resource) where T : class
    {
        try
        {
            var response = await _httpService.GetFromJsonAsync<T>(resource);
           return response;
        }
        catch(Exception ex)
        {
            Print.PrinColor(ConsoleColor.Red, ex.Message);
            return null;
        }
    }

    public async Task<T?> PutFromJsonAsync<T>(string resource, T model) where T : class
    {
        try
        {
            var response = await _httpService.PutFromJsonAsync<T>(resource, model);
           return response;
        }
        catch(Exception ex)
        {
            Print.PrinColor(ConsoleColor.Red, ex.Message);
            return null;
        }
    }

    public async Task<HttpStatusCode?> DeleteAsync(string resource)
    {
        try
        {
            return await _httpService.DeleteAsync(resource);
        }
        catch(Exception ex)
        {
            Print.PrinColor(ConsoleColor.Red, ex.Message);
            return null;
        }
    }
}
