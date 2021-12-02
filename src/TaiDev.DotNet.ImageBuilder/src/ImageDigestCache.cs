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
}

