using TaiDev.DotNet.ImageBuilder.Models.Manifest;

namespace TaiDev.DotNet.ImageBuilder.ViewModel;

public static class ModelExtensions
{
    public static string GetDockerName(this Architecture architecture) => architecture.ToString().ToLowerInvariant();
    public static string GetDockerName(this OS os) => os.ToString().ToLowerInvariant();
}

