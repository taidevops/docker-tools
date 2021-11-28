using System.Text.Json;

namespace TaiDev.DotNet.ImageBuilder;

public interface IManifestToolService
{
    void PushFromSpec(string manifestFile, bool isDryRun);
    JsonDocument Inspect(string image, bool isDryRun);
}

