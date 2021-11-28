using System.Text.Json.Serialization;

namespace TaiDev.DotNet.ImageBuilder.Models.Docker;

#nullable disable
public partial class Platform
{
    public string Architecture { get; set; }

    public string Os { get; set; }

    [JsonPropertyName("os.version")]
    public string OsVersion { get; set; }
}
#nullable enable
