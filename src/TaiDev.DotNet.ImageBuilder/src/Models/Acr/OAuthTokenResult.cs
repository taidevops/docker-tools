using System.Text.Json.Serialization;

namespace TaiDev.DotNet.ImageBuilder.Models.Acr;

#nullable disable
public class OAuthTokenResult
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
}
#nullable enable
