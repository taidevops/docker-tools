using System.Text.Json.Serialization;

namespace TaiDev.DotNet.ImageBuilder.Models.Acr;

#nullable disable
public class RepositoryManifests
{
    [JsonPropertyName("imageName")]
    public string RepositoryName { get; set; }

    public List<ManifestAttributes> Manifests { get; set; }
}
#nullable enable
