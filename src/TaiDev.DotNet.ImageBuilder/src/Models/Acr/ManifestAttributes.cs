namespace TaiDev.DotNet.ImageBuilder.Models.Acr;

#nullable disable
public class ManifestAttributes
{
    public string[] Tags { get; set; } = Array.Empty<string>();
    public string Digest { get; set; }
    public DateTime LastUpdateTime { get; set; }
}
#nullable enable
