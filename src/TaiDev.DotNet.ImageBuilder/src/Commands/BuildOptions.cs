
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using static TaiDev.DotNet.ImageBuilder.Commands.CliHelper;

namespace TaiDev.DotNet.ImageBuilder.Commands;

internal class BuildOptions : Options
{
    public string? ImageInfoOutputPath { get; set; }
}

internal class BuildOptionsBuilder : CliOptionsBuilder
{
    public override IEnumerable<Option> GetCliOptions() =>
        base.GetCliOptions()
            .Concat(
                new Option[]
                {
                    CreateOption<string?>("image-info-output-path", nameof(BuildOptions.ImageInfoOutputPath),
                        "Path to output image info"),
                });

    public override IEnumerable<Argument> GetCliArguments() =>
        base.GetCliArguments();
}

