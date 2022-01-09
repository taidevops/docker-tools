using Newtonsoft.Json;

namespace TaiDev.DotNet.ImageBuilder.Models.Docker;

public partial class Platform
{
    public string Architecture { get; set; }

    public string Os { get; set; }

    [JsonProperty("os.version")]
    public string OsVersion { get; set; }
}
