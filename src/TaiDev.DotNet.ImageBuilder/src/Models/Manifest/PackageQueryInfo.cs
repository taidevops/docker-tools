using System.ComponentModel;

namespace TaiDev.DotNet.ImageBuilder.Models.Manifest;

[Description(
    "Relative path to the template the Dockerfile is generated from."
    )]
public class PackageQueryInfo
{
    [Description(
        "Relative path from the manifest file to the script which queries the packages installed for a platform Dockerfile."
        )]
    public string? GetInstalledPackagesPath { get; set; }

    [Description(
        "Relative path from the manifest file to the script which queries the packages available for upgrade for a platform Dockerfile."
        )]
    public string? GetUpgradablePackagesPath { get; set; }
}
