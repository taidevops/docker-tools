
namespace TaiDev.DotNet.ImageBuilder.Models.McrStatus;

#nullable disable
public class ImageResult
{
    public string Digest { get; set; }
    public List<ImageStatus> Value { get; set; } = new List<ImageStatus>();
}
#nullable enable
