
namespace TaiDev.DotNet.ImageBuilder;

internal static class PathHelper
{
    public static string NormalizePath(string path) => path.Replace(@"\", "/");

    public static string GetNormalizedDirectory(string path) =>
        PathHelper.NormalizePath(Path.GetDirectoryName(path)!);
}

