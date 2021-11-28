namespace TaiDev.DotNet.ImageBuilder;

public static class Logger
{
    public static void WriteError(string error)
    {
        Console.Error.WriteLine(error);
    }

    public static void WriteHeading(string heading)
    {
        Console.WriteLine();
        Console.WriteLine(heading);
        Console.WriteLine(new string('-', heading.Length));
    }

    public static void WriteMessage()
    {
        Console.WriteLine();
    }

    public static void WriteMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static void WriteSubheading(string subheading)
    {
        WriteMessage($"-- {subheading}");
    }
}
