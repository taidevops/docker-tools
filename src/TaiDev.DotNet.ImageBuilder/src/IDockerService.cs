using TaiDev.DotNet.ImageBuilder.Models.Manifest;

namespace TaiDev.DotNet.ImageBuilder;

public interface IDockerService
{
    Architecture Architecture { get; }

    void PullImage(string image, bool isDryRun);

    string? GetImageDigest(string image, bool isDryRun);

    IEnumerable<string> GetImageManifestLayers(string image, bool isDryRun);

    void PushImage(string tag, bool isDryRun);

    void CreateTag(string image, string tag, bool isDryRun);

    string? BuildImage(
        string dockerfilePath,
        string buildContextPath,
        IEnumerable<string> tags,
        IDictionary<string, string?> buildArgs,
        bool isRetryEnabled,
        bool isDryRun);

    bool LocalImageExists(string tag, bool isDryRun);

    long GetImageSize(string image, bool isDryRun);

    DateTime GetCreatedDate(string image, bool isDryRun);
}

