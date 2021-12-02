using System.Text.Json.Serialization;

namespace TaiDev.DotNet.ImageBuilder.Models.Acr;

#nullable disable
public class Repository
{
    [JsonPropertyName("imageName")]
    public string Name { get; set; }

    public DateTime LastUpdateTime { get; set; }
}
#nullable enable
