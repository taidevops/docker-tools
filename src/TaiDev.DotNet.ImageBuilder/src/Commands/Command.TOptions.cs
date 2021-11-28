
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace TaiDev.DotNet.ImageBuilder.Commands;

public abstract class Command<TOptions, TOptionsBuilder> : ICommand
    where TOptions : Options, new()
    where TOptionsBuilder : CliOptionsBuilder, new()
{
    public TOptions Options { get; private set; }

    Options ICommand.Options => Options;

    protected abstract string Description { get; }

    public Command()
    {
        Options = new TOptions();
    }

    public Command GetCliCommand()
    {
        Command cmd = new Command(this.GetCommandName(), Description);

        TOptionsBuilder OptionsBuilder = new TOptionsBuilder();

        foreach (Argument argument in OptionsBuilder.GetCliArguments())
        {
            cmd.AddArgument(argument);
        }

        foreach (Option option in OptionsBuilder.GetCliOptions())
        {
            cmd.AddOption(option);
        }

        cmd.Handler = CommandHandler.Create<TOptions>(options =>
        {
            Initialize(options);
            return ExecuteAsync();
        });

        return cmd;
    }

    protected virtual void Initialize(TOptions options)
    {
        Options = options;
    }

    public abstract Task ExecuteAsync();
}
