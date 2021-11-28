
using System;
using System.IO;

namespace TaiDev.DotNet.ImageBuilder.Tests.Helpers;

internal static class TestHelper
{
    public static TempFolderContext UseTempFolder()
    {
        return new TempFolderContext();
    }
}

internal class TempFolderContext : IDisposable
{
    public TempFolderContext()
    {
        do
        {
            Path = System.IO.Path.Combine(
                System.IO.Path.GetTempPath(),
                Guid.NewGuid().ToString());
        }
        while (Directory.Exists(Path));

        Directory.CreateDirectory(Path);
    }

    public string Path { get; }

    public void Dispose()
    {
        Directory.Delete(Path, true);
    }
}
