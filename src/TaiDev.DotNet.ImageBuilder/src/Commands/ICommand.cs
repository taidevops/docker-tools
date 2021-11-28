using System.CommandLine;

namespace TaiDev.DotNet.ImageBuilder.Commands;

public interface ICommand
{
    Options Options { get; }

    Task ExecuteAsync();

    Command GetCliCommand();
}
