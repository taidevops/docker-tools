// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.Composition;
using Cottle;
using TaiDev.DotNet.ImageBuilder.ViewModel;

namespace TaiDev.DotNet.ImageBuilder.Commands;

#nullable disable
[Export(typeof(ICommand))]
internal class GenerateReadmesCommand : GenerateArtifactsCommand<GenerateReadmesOptions, GenerateReadmesOptionsBuilder>
{
    private const string ArtifactName = "Readme";

    [ImportingConstructor]
    public GenerateReadmesCommand(IEnvironmentService environmentService) : base(environmentService)
    {

    }
    
    protected override string Description =>
        "Generates the Readmes from the Cottle based templates (http://r3c.github.io/cottle/) and updates the tag listing section";

    public override async Task ExecuteAsync()
    {
        Logger.WriteHeading("GENERATING READMES");

        await GenerateArtifactsAsync(
            new ManifestInfo[] { Manifest },
            (manifest) => manifest.ReadmeTemplatePath,
            (manifest) => manifest.ReadmePath,
            (manifest) => GetSymbols(manifest),
            "",
            ArtifactName);

        // Generate Product Family Readme
    }

    public Dictionary<Value, Value> GetSymbols(ManifestInfo manifest) =>
        GetCommonSymbols(manifest.ReadmeTemplatePath, manifest, (manifest) => GetSymbols(manifest));

    private Dictionary<Value, Value> GetCommonSymbols<TContext>(
        string sourceTemplatePath,
        TContext context,
        Func<TContext, IReadOnlyDictionary<Value, Value>> getSymbols)
    {
        Dictionary<Value, Value> symbols = GetSymbols();
        symbols["IS_PRODUCT_FAMILY"] = context is ManifestInfo;
        symbols["InsertTemplate"] = Value.FromFunction(Function.CreatePure1((state, path) =>
            RenderTemplateAsync(Path.Combine(Path.GetDirectoryName(sourceTemplatePath), path.AsString), context, getSymbols).Result));

        return symbols;
    }

    private string UpdateTagsListing(string readme, RepoInfo repo)
    {
        return string.Empty;
    }
}
#nullable enable
