
namespace TaiDev.DotNet.ImageBuilder;

#nullable disable
public static class PathHelper
{
    public static string NormalizePath(string path) => path.Replace(@"\", "/");

    /// <summary>
    /// Trims the <paramref name="trimPath"/> string from <paramref name="path"/>.
    /// </summary>
    /// <param name="trimPath">The path segment to remove from <paramref name="path"/>.</param>
    /// <param name="path">The path to be trimmed.</param>
    public static string TrimPath(string trimPath, string path)
    {
        if (!NormalizePath(path).StartsWith(NormalizePath(trimPath)))
        {
            throw new InvalidOperationException($"'{path}' must start with '{trimPath}'");
        }
        string result = path.Substring(trimPath.Length);
        if (result.StartsWith("/") || result.StartsWith("\\"))
        {
            result = result.Substring(1);
        }

        return result;
    }

    public static string GetNormalizedDirectory(string path)
    {
        return PathHelper.NormalizePath(Path.GetDirectoryName(path));
    }
}
#nullable enable
