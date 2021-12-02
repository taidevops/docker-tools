
using TaiDev.DotNet.ImageBuilder.Models.Manifest;
using TaiDev.DotNet.ImageBuilder.ViewModel;
using Xunit;
using static TaiDev.DotNet.ImageBuilder.Tests.Helpers.ManifestHelper;

namespace TaiDev.DotNet.ImageBuilder.Tests;

public class PlatformInfoTests
{
    [Theory]
    [InlineData("debian", "Debian")]
    [InlineData("jessie", "Debian 8")]
    [InlineData("stretch", "Debian 9")]
    [InlineData("stretch-slim", "Debian 9")]
    [InlineData("buster", "Debian 10")]
    [InlineData("buster-slim", "Debian 10")]
    [InlineData("xenial", "Ubuntu 16.04")]
    [InlineData("bionic", "Ubuntu 18.04")]
    [InlineData("disco", "Ubuntu 19.04")]
    [InlineData("focal", "Ubuntu 20.04")]
    [InlineData("alpine3.12", "Alpine 3.12")]
    [InlineData("centos8", "Centos 8")]
    [InlineData("fedora32", "Fedora 32")]
    public void GetOSDisplayName_Linux(string osVersion, string expectedDisplayName)
    {
        ValidateGetOSDisplayName(OS.Linux, osVersion, expectedDisplayName);
    }

    [Theory]
    [InlineData("windowsservercore-ltsc2016", "Windows Server Core 2016")]
    [InlineData("windowsservercore-ltsc2019", "Windows Server Core 2019")]
    [InlineData("nanoserver-1809", "Nano Server, version 1809")]
    [InlineData("windowsservercore-1903", "Windows Server Core, version 1903")]
    [InlineData("nanoserver-1903", "Nano Server, version 1903")]
    [InlineData("nanoserver-ltsc2022", "Nano Server 2022")]
    public void GetOSDisplayName_Windows(string osVersion, string expectedDisplayName)
    {
        ValidateGetOSDisplayName(OS.Windows, osVersion, expectedDisplayName);
    }

    private void ValidateGetOSDisplayName(OS os, string osVersion, string expectedDisplayName)
    {
        Platform platform = CreatePlatform(os: os, osVersion: osVersion);
        PlatformInfo platformInfo = PlatformInfo.Create(platform);

        Assert.Equal(expectedDisplayName, platformInfo.GetOSDisplayName());
    }
}

