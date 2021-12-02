
using System.Text;

namespace TaiDev.DotNet.ImageBuilder.Models.McrStatus;

#nullable disable
public class ContentSubstatus
{
    /// <summary>
    /// The stage that processes a request in response to a readme change.
    /// </summary>
    public StageStatus Initialization { get; set; }

    /// <summary>
    /// The stage where readmes are updated in Docker Hub.
    /// </summary>
    public StageStatus ContentUpdate { get; set; }

    /// <summary>
    /// The stage which validates that the readme on Docker Hub represents the most recent version of the readme checked into GitHub.
    /// </summary>
    public StageStatus ValidateNoDocRepoChanges { get; set; }

    public override string ToString()
    {
        return ToString(null);
    }

    public string ToString(string prefix)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{prefix}Initialization status: {Initialization}");
        stringBuilder.AppendLine($"{prefix}Content update status: {ContentUpdate}");
        stringBuilder.AppendLine($"{prefix}Validate no doc repo changes status: {ValidateNoDocRepoChanges}");
        return stringBuilder.ToString();
    }
}
#nullable enable
