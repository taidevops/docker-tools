using System.ComponentModel;

namespace TaiDev.DotNet.ImageBuilder.Models.Manifest;

#nullable disable
[Description(
    "A description of where a tag should be syndicated to."
    )]
public class TagSyndication
{
    [Description(
        "Name of the repo to syndicate the tag to."
    )]
    public string Repo { get; set; }

    [Description(
        "List of destination tag names to syndicate the tag to."
    )]
    public string[] DestinationTags { get; set; }
}
#nullable enable
