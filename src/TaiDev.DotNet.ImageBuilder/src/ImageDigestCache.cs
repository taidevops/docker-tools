namespace TaiDev.DotNet.ImageBuilder;

public class ImageDigestCache
{
    private readonly IDockerService _dockerService;
    private readonly Dictionary<string, string?> _digestCache = new();

    public ImageDigestCache(IDockerService dockerService)
    {
        _dockerService = dockerService;
    }

    public void AddDigest(string tag, string digest)
    {
        lock (_digestCache)
        {
            _digestCache[tag] = digest;
        }
    }

    public string? GetImageDigest(string tag, bool isDryRun) =>
        LockHelper.DoubleCheckedLockLookup(_digestCache, _digestCache, tag,
            () => _dockerService.GetImageDigest(tag, isDryRun),
            // Don't allow null digests to be cached. A locally built image won't have a digest until
            // it is pushed so if its digest is retrieved before pushing, we don't want that 
            // null to be cached.
            val => !string.IsNullOrEmpty(val));
}

