using TaiDev.DotNet.ImageBuilder.Models.Manifest;

namespace TaiDev.DotNet.ImageBuilder.ViewModel;

public static class ModelExtensions
{

    public static string GetDockerName(this Architecture architecture) => architecture.ToString().ToLowerInvariant();
    public static string GetDockerName(this OS os) => os.ToString().ToLowerInvariant();

    public static string ResolveDockerfilePath(this Platform platform, string manifestDirectory)
    {
        ValidatePathIsRelative(platform.Dockerfile);

        string dockerfilePath = Path.Combine(manifestDirectory, platform.Dockerfile);
        if (File.Exists(dockerfilePath))
        {
            return platform.Dockerfile;
        }
        else
        {
            return Path.Combine(platform.Dockerfile, "Dockerfile");
        }
    }

    private static void ValidatePathIsRelative(string path)
    {
        if (Path.IsPathRooted(path))
        {
            throw new ValidationException($"Path '{path}' specified in manifest file must be a relative path.");
        }
    }
}

