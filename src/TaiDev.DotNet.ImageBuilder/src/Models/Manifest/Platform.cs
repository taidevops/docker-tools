using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TaiDev.DotNet.ImageBuilder.Models.Manifest;

[Description(
    "A platform object contains metadata about a platform-specific version of an " +
    "image and refers to the actual Dockerfile used to build the image.")]
public class Platform
{
    [Description(
        "The processor architecture associated with the image."
        )]
    [DefaultValue(Architecture.AMD64)]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Architecture Architecture { get; set; } = Architecture.AMD64;

    [Description(
        "A set of values that will passed to the `docker build` command " +
        "to override variables defined in the Dockerfile.")]
    public IDictionary<string, string> BuildArgs { get; set; } = new Dictionary<string, string>();

    [Description(
        "Relative path to the associated Dockerfile. This can be a file or a " +
        "directory. If it is a directory, the file name defaults to Dockerfile."
        )]
    public string Dockerfile { get; set; } = string.Empty;

    [Description(
        "Relative path to the template the Dockerfile is generated from."
        )]
    public string? DockerfileTemplate { get; set; }

    [Description(
        "The generic name of the operating system associated with the image."
        )]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OS OS { get; set; }

    [Description(
        "The specific version of the operating system associated with the image. " +
        "Examples: alpine3.9, bionic, nanoserver-1903."
        )]
    public string OsVersion { get; set; } = string.Empty;

    [Description(
        "The set of platform-specific tags associated with the image."
        )]
    public IDictionary<string, Tag> Tags { get; set; } = new Dictionary<string, Tag>();

    [Description(
        "The custom build leg groups associated with the platform."
        )]
    public CustomBuildLegGroup[] CustomBuildLegGroups { get; set; } = Array.Empty<CustomBuildLegGroup>();

    [Description(
        "Overrides the default script paths for querying package info."
        )]
    public PackageQueryInfo? PackageQueryOverrides { get; set; }

    [Description(
        "A label which further distinguishes the architecture when it " +
        "contains variants. For example, the ARM architecture has variants " +
        "named v6, v7, etc."
        )]
    public string? Variant { get; set; }

    public Platform()
    {
    }
}

