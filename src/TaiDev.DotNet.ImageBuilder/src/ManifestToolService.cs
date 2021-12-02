using System.ComponentModel.Composition;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace TaiDev.DotNet.ImageBuilder;

#nullable disable
[Export(typeof(IManifestToolService))]
public class ManifestToolService : IManifestToolService
{
    public const string ManifestListMediaType = "application/vnd.docker.distribution.manifest.list.v2+json";
    public const string ManifestMediaType = "application/vnd.docker.distribution.manifest.v2+json";

    public void PushFromSpec(string manifestFile, bool isDryRun)
    {
        // ExecuteWithRetry because the manifest-tool fails periodically while communicating
        // with the Docker Registry.
        ExecuteHelper.ExecuteWithRetry("manifest-tool", $"push from-spec {manifestFile}", isDryRun);
    }

    public JsonArray Inspect(string image, bool isDryRun)
    {
        string output = ExecuteHelper.ExecuteWithRetry("manifest-tool", $"inspect {image} --raw", isDryRun);
        if (isDryRun)
        {
            return new JsonArray();
        }

        return JsonSerializer.Deserialize<JsonArray>(output);
    }
}
#nullable enable
