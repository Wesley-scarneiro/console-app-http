namespace ConsoleAppHttp;
public static class Print
{
    public static void PrinColor(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
