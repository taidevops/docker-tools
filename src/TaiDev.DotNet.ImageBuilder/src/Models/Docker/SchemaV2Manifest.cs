namespace TaiDev.DotNet.ImageBuilder.Models.Docker;

#nullable disable
public partial class SchemaV2Manifest
{
    public long SchemaVersion { get; set; }

    public string MediaType { get; set; }

    public Descriptor Config { get; set; }

    public Descriptor[] Layers { get; set; }
}
#nullable enable
