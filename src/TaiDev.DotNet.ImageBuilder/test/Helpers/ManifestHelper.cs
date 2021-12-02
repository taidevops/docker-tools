
using TaiDev.DotNet.ImageBuilder.Models.Manifest;

namespace TaiDev.DotNet.ImageBuilder.Tests.Helpers;

public static class ManifestHelper
{
    public static Platform CreatePlatform(
        OS os = OS.Linux,
        string osVersion = "focal"
        )
    {
        return new Platform
        {
            OsVersion = osVersion,
            OS = os
        };
    }
}

