

using System.ComponentModel.Composition;

namespace TaiDev.DotNet.ImageBuilder.Commands;

[Export(typeof(ICommand))]
internal class BuildCommand : Command<BuildOptions, BuildOptionsBuilder>
{
    private readonly ILoggerService _loggerService;

    [ImportingConstructor]
    public BuildCommand(ILoggerService loggerService)
    {
        _loggerService = loggerService;
    }

    protected override string Description => "Builds Dockerfiles";

    public override Task ExecuteAsync()
    {
        if (Options.ImageInfoOutputPath != null)
        {

        }

        WriteBuildSummary();

        return Task.CompletedTask;
    }

    private void WriteBuildSummary()
    {
        _loggerService.WriteHeading("IMAGES BUILT");
    }
}

