﻿
using System.CommandLine;
using TaiDev.DotNet.ImageBuilder.ViewModel;
using static TaiDev.DotNet.ImageBuilder.Commands.CliHelper;

namespace TaiDev.DotNet.ImageBuilder.Commands;

public abstract class ManifestOptions : Options, IManifestOptionsInfo
{
    public string Manifest { get; set; } = string.Empty;
    public string? RegistryOverride { get; set; }
    public IEnumerable<string> Repos { get; set; } = Enumerable.Empty<string>();
    public string? RepoPrefix { get; set; }
    public IDictionary<string, string> Variables { get; set; } = new Dictionary<string, string>();
}

public abstract class ManifestOptionsBuilder : CliOptionsBuilder
{
    public override IEnumerable<Option> GetCliOptions() =>
        base.GetCliOptions().Concat(
            new Option[]
            {
                CreateOption("manifest", nameof(ManifestOptions.Manifest),
                    "Path to json file which describes the repo", "manifest.json"),
                CreateOption<string?>("registry-override", nameof(ManifestOptions.RegistryOverride),
                    "Alternative registry which overrides the manifest"),

            });
}
