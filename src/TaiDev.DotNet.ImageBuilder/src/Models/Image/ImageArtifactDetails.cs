namespace TaiDev.DotNet.ImageBuilder.Models.Image;

public class ImageArtifactDetails
{
    public string SchemaVersion
    {
        get { return "1.0"; }
        set { }
    }

    public List<RepoData> Repos { get; set; } = new List<RepoData>();
}

