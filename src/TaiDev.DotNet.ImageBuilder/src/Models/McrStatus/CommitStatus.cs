
namespace TaiDev.DotNet.ImageBuilder.Models.McrStatus;

#nullable disable
public class CommitStatus
{
    public string OnboardingRequestId { get; set; }
    public DateTime QueueTime { get; set; }
    public StageStatus OverallStatus { get; set; }
}
#nullable enable
