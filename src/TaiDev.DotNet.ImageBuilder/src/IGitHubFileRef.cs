namespace TaiDev.DotNet.ImageBuilder;

public interface IGitHubFileRef : IGitHubBranchRef
{
    string Path { get; }
}
