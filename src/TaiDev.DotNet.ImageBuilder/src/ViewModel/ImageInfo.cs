using TaiDev.DotNet.ImageBuilder.Models.Manifest;

namespace TaiDev.DotNet.ImageBuilder.ViewModel;

public class ImageInfo
{
    /// <summary>
    /// All of the platforms that are defined in the manifest for this image.
    /// </summary>
    public IEnumerable<PlatformInfo> AllPlatforms { get; set; }

    /// <summary>
    /// The subet of image platforms after applying the command line filter options.
    /// </summary>
    public IEnumerable<PlatformInfo> FilteredPlatforms { get; private set; }

    public Image Model { get; private set; }
    public IEnumerable<TagInfo> SharedTags { get; private set; }
    public string? ProductVersion { get; private set; }

    private ImageInfo(Image model, string? productVersion, IEnumerable<TagInfo> sharedTags, IEnumerable<PlatformInfo> allPlatforms,
        IEnumerable<PlatformInfo> filteredPlatforms)
    {
        Model = model;
        ProductVersion = productVersion;
        SharedTags = sharedTags;
        AllPlatforms = allPlatforms;
        FilteredPlatforms = filteredPlatforms;
    }

    public static ImageInfo Create(
        Image model, string fullRepoModelName, string repoName, ManifestFilter manifestFilter, string baseDirectory)
    {
        IEnumerable<TagInfo> sharedTags;
        if (model.SharedTags == null)
        {
            sharedTags = Enumerable.Empty<TagInfo>();
        }
        else
        {
            sharedTags = model.SharedTags
                .Select(kvp => TagInfo.Create(kvp.Key, kvp.Value, repoName))
                .ToArray();
        }

        IEnumerable<PlatformInfo> allPlatforms = model.Platforms
            .Select(platform => PlatformInfo.Create)
        string? productVersion = model.ProductVersion;
        return new(
            model,
            productVersion);
    }
}
