using System.Text.Json.Nodes;

namespace TaiDev.DotNet.ImageBuilder;

public interface IManifestToolService
{
    void PushFromSpec(string manifestFile, bool isDryRun);
    JsonArray Inspect(string image, bool isDryRun);
}

