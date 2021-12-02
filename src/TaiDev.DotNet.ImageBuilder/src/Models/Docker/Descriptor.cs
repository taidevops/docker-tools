using System.Text.Json.Serialization;

namespace TaiDev.DotNet.ImageBuilder.Models.Docker;

#nullable disable
public partial class Descriptor : IEquatable<Descriptor>
{
    public string MediaType { get; set; }

    public string Digest { get; set; }

    public long Size { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Platform Platform { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Uri[] Urls { get; set; }

    public bool Equals(Descriptor other)
    {
        return other != null && Digest == other.Digest;
    }

    public override bool Equals(object obj) => Equals(obj as Descriptor);

    public override int GetHashCode() => Digest.GetHashCode();
}
#nullable enable
