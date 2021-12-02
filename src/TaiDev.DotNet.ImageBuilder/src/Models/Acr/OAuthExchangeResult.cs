using System.Text.Json.Serialization;

namespace TaiDev.DotNet.ImageBuilder.Models.Acr;

#nullable disable
public class OAuthExchangeResult
{
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
}
#nullable enable
