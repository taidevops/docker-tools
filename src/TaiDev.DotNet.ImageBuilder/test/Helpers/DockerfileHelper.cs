
using System.IO;

namespace TaiDev.DotNet.ImageBuilder.Tests.Helpers;

#nullable disable
internal static class DockerfileHelper
{
    public static string CreateDockerfile(string relativeDirectory, TempFolderContext context, string fromTag = "base")
    {
        string relativeDockerfilePath = PathHelper.NormalizePath(Path.Combine(relativeDirectory, "Dockerfile"));
        CreateFile(relativeDockerfilePath, context, $"FROM {fromTag}");
        return relativeDockerfilePath;
    }

    public static void CreateFile(string relativeFileName, TempFolderContext context, string content)
    {
        string fullFilePath = Path.Combine(context.Path, relativeFileName);
        Directory.CreateDirectory(Directory.GetParent(fullFilePath).FullName);
        File.WriteAllText(fullFilePath, content);
    }
}
#nullable enable
