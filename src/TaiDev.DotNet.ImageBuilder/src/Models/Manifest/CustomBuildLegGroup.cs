using System.ComponentModel;

namespace TaiDev.DotNet.ImageBuilder.Models.Manifest;

#nullable disable
[Description(
    "This object describes the tag dependencies of the image for a specific named scenario. This is " +
    "for advanced cases only. It allows tooling to modify the build matrix that would normally be " +
    "generated for the image by including the customizations described in this metadata. An example " +
    "usage of this is in PR builds where it is necessary to build and test in the same job. In such " +
    "a scenario, some images are part of a test matrix that require images to be available on the " +
    "build machine that aren't part of that images dependency graph in normal scenarios. By " +
    "specifying a customBuildLegGroup for this scenario, those additional image dependencies can " +
    "be specified and the build pipeline can make use of them when constructing its build graph when " +
    "specified to do so."
    )]
public class CustomBuildLegGroup
{
    [Description(
        "Name of the group describing the scenario in which it's relevant. This is just a " +
        " custom label that can then be used by tooling to lookup the group when necessary."
        )]
    public string Name { get; set; }

    [Description("The type of the dependency which impacts how it's used during the build.")]
    public CustomBuildLegDependencyType Type { get; set; }

    [Description("The set of dependencies the image has for this scenario.")]
    public string[] Dependencies { get; set; } = Array.Empty<string>();
}
#nullable enable
