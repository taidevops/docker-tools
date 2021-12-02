namespace TaiDev.DotNet.ImageBuilder.ViewModel;

#nullable disable
public class RepoInfo
{
    /// <summary>
    /// The subet of image platforms after applying the command line filter options.
    /// </summary>
    public IEnumerable<ImageInfo> FilteredImages { get; private set; }

    public string Id { get; private set; }
    public string QualifiedName { get; private set; }
}
#nullable enable
