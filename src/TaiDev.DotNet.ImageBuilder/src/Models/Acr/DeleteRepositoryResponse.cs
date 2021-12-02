namespace TaiDev.DotNet.ImageBuilder.Models.Acr;

public class DeleteRepositoryResponse
{
    public string[] ManifestsDeleted { get; set; } = Array.Empty<string>();
    public string[] TagsDeleted { get; set; } = Array.Empty<string>();
}
