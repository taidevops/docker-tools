using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using static TaiDev.DotNet.ImageBuilder.Commands.CliHelper;

namespace TaiDev.DotNet.ImageBuilder.Commands;

internal class GenerateReadmesOptions : GenerateArtifactsOptions
{
    public string SourceRepoUrl { get; set; } = string.Empty;

    public string? SourceRepoBranch { get; set; }

    public GenerateReadmesOptions() : base()
    {
    }
}

internal class GenerateReadmesOptionsBuilder : GenerateArtifactsOptionsBuilder
{
    public override IEnumerable<Option> GetCliOptions() =>
        base.GetCliOptions()
            .Concat(
                new Option[]
                {
                    CreateOption<string?>("source-branch", nameof(GenerateReadmesOptions.SourceRepoBranch),
                        "Repo branch of the Dockerfile sources (default is commit SHA)")
                }
            );

    public override IEnumerable<Argument> GetCliArguments() =>
        base.GetCliArguments()
            .Concat(
                new Argument[]
                {
                    new Argument<string>(nameof(GenerateReadmesOptions.SourceRepoUrl),
                        "Repo URL of the Dockerfile sources")
                }
            );
}
