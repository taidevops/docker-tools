namespace TaiDev.DotNet.ImageBuilder.Models.Acr;

#nullable disable
public class GetTagsResponse
{
    public string ImageName { get; set; }
    public string Registry { get; set; }
    public List<TagDetails> Tags { get; set; }
}
#nullable enable
