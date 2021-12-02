namespace TaiDev.DotNet.ImageBuilder;

public interface IGitHubRepoRef
{
    public string Owner { get; set; }

    public string Repo { get; set; }
}
