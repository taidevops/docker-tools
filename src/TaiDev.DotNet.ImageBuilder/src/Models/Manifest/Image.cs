﻿using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TaiDev.DotNet.ImageBuilder.Models.Manifest;

#nullable disable
[Description("An image object contains metadata about a specific Docker image.")]
public class Image
{
    [Description(
        "The set of platforms that describe the platform-specific variations of the Docker image.")]
    public Platform[] Platforms { get; set; }

    [Description(
        "The set of tags that are shared amongst all platform-specific versions of the image. An " +
        "example of a shared tag, including its repo name, is dotnet/core/runtime:2.2; running " +
        "`docker pull mcr.microsoft.com/dotnet/core/runtime:2.2` on Windows will get the " +
        "default Windows-based tag whereas running it on Linux will get the default " +
        "Linux-based tag.")]
    public IDictionary<string, Tag> SharedTags { get; set; }

    [Description("The full version of the product that the Docker image contains.")]
    public string ProductVersion { get; set; }

    public Image()
    {
    }
}
#nullable enable
