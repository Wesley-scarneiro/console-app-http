namespace ConsoleAppHttp;
public static class Extensions
{
    public static void WriteRequest(this HttpResponseMessage response)
    {
        if (response is not null)
        {
            var request = response.RequestMessage;
            Console.Write($"{request?.Method} ");
            Console.Write($"{request?.RequestUri} ");
            Console.WriteLine($"HTTP/{request?.Version}"); 
        }
    }
}
