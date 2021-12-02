namespace TaiDev.DotNet.ImageBuilder.Models.McrStatus;

#nullable disable
public class ImageStatus
{
    public string OnboardingRequestId { get; set; }
    public string SourceRepository { get; set; }
    public string TargetRepository { get; set; }
    public DateTime QueueTime { get; set; }
    public string Tag { get; set; }
    public StageStatus OverallStatus { get; set; }
}
#nullable enable
