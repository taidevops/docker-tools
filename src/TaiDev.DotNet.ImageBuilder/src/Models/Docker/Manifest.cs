namespace TaiDev.DotNet.ImageBuilder.Models.Docker;

public partial class Manifest
{
    public string Ref { get; set; }

    public Descriptor Descriptor { get; set; }

    public SchemaV2Manifest SchemaV2Manifest { get; set; }
}
