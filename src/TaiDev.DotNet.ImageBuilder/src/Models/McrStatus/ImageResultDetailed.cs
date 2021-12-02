
namespace TaiDev.DotNet.ImageBuilder.Models.McrStatus;

#nullable disable
public class ImageResultDetailed
{
    public string OnboardingRequestId { get; set; }
    public string SourceRepository { get; set; }
    public string TargetRepository { get; set; }
    public DateTime QueueTime { get; set; }
    public string Tag { get; set; }
    public StageStatus OverallStatus { get; set; }
    public ImageSubstatus Substatus { get; set; } = new ImageSubstatus();
    public string CommitDigest { get; set; }
}
#nullable enable
