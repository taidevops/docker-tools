
namespace TaiDev.DotNet.ImageBuilder.Commands;

internal static class CommandExtensions
{
    public static string GetCommandName(this ICommand command)
    {
        string commandName = command.GetType().Name.TrimEnd("Command");
        return char.ToLowerInvariant(commandName[0]) + commandName.Substring(1);
    }
}

