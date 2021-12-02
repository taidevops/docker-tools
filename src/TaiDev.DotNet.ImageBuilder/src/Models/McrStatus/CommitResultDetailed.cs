namespace TaiDev.DotNet.ImageBuilder.Models.McrStatus;

#nullable disable
public class CommitResultDetailed
{
    public string OnboardingRequestId { get; set; }
    public DateTime QueueTime { get; set; }
    public string CommitDigest { get; set; }
    public string Branch { get; set; }
    public List<string> ContentFiles { get; set; } = new List<string>();
    public StageStatus OverallStatus { get; set; }
    public ContentSubstatus Substatus { get; set; } = new ContentSubstatus();
}
#nullable enable
