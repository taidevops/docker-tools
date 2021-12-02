namespace TaiDev.DotNet.ImageBuilder;

[Flags]
public enum ManifestMediaType
{
    Manifest = 1,
    ManifestList = 2,
    Any = Manifest | ManifestList
}
