
using TaiDev.DotNet.ImageBuilder.Models.Image;
using TaiDev.DotNet.ImageBuilder.ViewModel;
using Xunit;

namespace TaiDev.DotNet.ImageBuilder.Tests;

public class PlatformDataTests
{
    [Theory]
    [InlineData("5.0.0-preview.3", "5.0")]
    [InlineData("5.0", "5.0")]
    [InlineData("5.0.1", "5.0")]
    public void GetIdentifier(string productVersion, string expectedVersion)
    {
        PlatformData platform = new PlatformData
        {
            ImageInfo
            Dockerfile = "path"
        };

        string identifier = platform.GetIdentifier();
        Assert.Equal($"path-{expectedVersion}", identifier);
    }

    private static ImageInfo CreateImage(string productVersion) =>
        ImageInfo.C
}

