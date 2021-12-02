using System.Text.Json.Serialization;

namespace TaiDev.DotNet.ImageBuilder.Models.Acr;

#nullable disable
public class Catalog
{
    [JsonPropertyName("repositories")]
    public List<string> RepositoryNames { get; set; }
}
#nullable enable
