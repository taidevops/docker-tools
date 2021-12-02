namespace TaiDev.DotNet.ImageBuilder;

public interface IGitHubBranchRef : IGitHubRepoRef
{
    public string Branch { get; set; }
}
