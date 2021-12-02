using TaiDev.DotNet.ImageBuilder.Models.Manifest;

namespace TaiDev.DotNet.ImageBuilder;

/// <summary>
/// Caches state returned from Docker commands.
/// </summary>
internal class DockerServiceCache : IDockerService
{
    private readonly IDockerService _inner;

    public DockerServiceCache(IDockerService inner)
    {
        _inner = inner;

    }
    public Architecture Architecture => throw new NotImplementedException();

    public string? BuildImage(string dockerfilePath, string buildContextPath, IEnumerable<string> tags, IDictionary<string, string?> buildArgs, bool isRetryEnabled, bool isDryRun) => throw new NotImplementedException();
    public void CreateTag(string image, string tag, bool isDryRun) => throw new NotImplementedException();
    public DateTime GetCreatedDate(string image, bool isDryRun) => throw new NotImplementedException();
    public string? GetImageDigest(string image, bool isDryRun) => throw new NotImplementedException();
    public IEnumerable<string> GetImageManifestLayers(string image, bool isDryRun) => throw new NotImplementedException();
    public long GetImageSize(string image, bool isDryRun) => throw new NotImplementedException();
    public bool LocalImageExists(string tag, bool isDryRun) => throw new NotImplementedException();
    public void PullImage(string image, bool isDryRun) => throw new NotImplementedException();
    public void PushImage(string tag, bool isDryRun) => throw new NotImplementedException();
}

