
namespace TaiDev.DotNet.ImageBuilder.Models.McrStatus;

#nullable disable
public class CommitResult
{
    public string CommitDigest { get; set; }
    public string Branch { get; set; }
    public List<string> ContentFiles { get; set; } = new List<string>();
    public List<CommitStatus> Value { get; set; } = new List<CommitStatus>();
}
#nullable enable
