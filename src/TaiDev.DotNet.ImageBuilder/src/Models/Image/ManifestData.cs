namespace TaiDev.DotNet.ImageBuilder.Models.Image;

public class ManifestData
{
    public string Digest { get; set; }
    public List<string> SyndicatedDigests { get; set; } = new();
    public DateTime Created { get; set; }
    public List<string> SharedTags { get; set; } = new();
}
