
using System.Text.Json;

namespace TaiDev.DotNet.ImageBuilder.ViewModel;

#nullable disable
public class ManifestInfo
{
    public string Registry { get; private set; }
    public VariableHelper VariableHelper { get; set; }

    /// <summary>
    /// Gets the directory of the manifest file.
    /// </summary>
    public string Directory { get; private set; }
    public string ReadmePath { get; private set; }
    public string ReadmeTemplatePath { get; private set; }

    private ManifestInfo()
    {
    }

    public static ManifestInfo Load(IManifestOptionsInfo options)
    {
        Logger.WriteHeading("READING MANIFEST");

        ManifestInfo manifest = ManifestInfo.Create(
            options.Manifest,
            options);

        if (options.IsVerbose)
        {
            Logger.WriteMessage(JsonSerializer.Serialize(manifest, new JsonSerializerOptions { WriteIndented = true }));
        }

        return manifest;
    }

    private static ManifestInfo Create(string manifestPath, IManifestOptionsInfo options)
    {
        string manifestDirectory = PathHelper.GetNormalizedDirectory(manifestPath);
        ManifestInfo manifestInfo = new ManifestInfo
        {
            Registry = options.RegistryOverride ?? "",
        };
        return manifestInfo;
    }
}
#nullable enable
