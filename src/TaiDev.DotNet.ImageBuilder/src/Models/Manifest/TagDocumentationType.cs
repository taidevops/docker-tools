namespace TaiDev.DotNet.ImageBuilder.Models.Manifest;

public enum TagDocumentationType
{
    /// <summary>
    /// The tag is always documented.
    /// </summary>
    Documented,

    /// <summary>
    /// The tag is never documented.
    /// </summary>
    Undocumented,

    /// <summary>
    /// The tag is only documented if there are corresponding platform tags that are documented.
    /// </summary>
    PlatformDocumented
}
