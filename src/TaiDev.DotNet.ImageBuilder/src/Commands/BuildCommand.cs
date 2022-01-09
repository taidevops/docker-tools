

using System.ComponentModel.Composition;
using TaiDev.DotNet.ImageBuilder.Models.Image;
using TaiDev.DotNet.ImageBuilder.ViewModel;

namespace TaiDev.DotNet.ImageBuilder.Commands;

[Export(typeof(ICommand))]
internal class BuildCommand : DockerRegistryCommand<BuildOptions, BuildOptionsBuilder>
{
    private readonly IDockerService _dockerService;
    private readonly ILoggerService _loggerService;
    private readonly IGitService _gitService;
    private readonly IProcessService _processService;
    private readonly ImageDigestCache _imageDigestCache;
    private readonly List<TagInfo> _processedTags = new List<TagInfo>();
    private readonly HashSet<PlatformInfo> _builtPlatforms = new();

    // Metadata about Dockerfiles whose images have been retrieved from the cache
    private readonly Dictionary<string, PlatformData> _cachedPlatforms = new Dictionary<string, PlatformData>();

    private ImageArtifactDetails? _imageArtifactDetails;

    [ImportingConstructor]
    public BuildCommand(IDockerService dockerService, ILoggerService loggerService, IGitService gitService, IProcessService processService)
    {
        _imageDigestCache = new ImageDigestCache(dockerService);
        _dockerService = new DockerServiceCache(dockerService ?? throw new ArgumentNullException(nameof(dockerService)));
        _loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        _gitService = gitService ?? throw new ArgumentNullException(nameof(gitService));
        _processService = processService ?? throw new ArgumentNullException(nameof(processService));
    }

    protected override string Description => "Builds Dockerfiles";

    public override Task ExecuteAsync()
    {
        if (Options.ImageInfoOutputPath != null)
        {

        }

        ExecuteWithUser(() =>
        {
            PullBaseImages();

        });

        WriteBuildSummary();

        return Task.CompletedTask;
    }

    private void PublishImageInfo()
    {
        if (string.IsNullOrEmpty(Options.ImageInfoOutputPath))
        {
            return;
        }

        if (string.IsNullOrEmpty(Options.SourceRepoUrl))
        {
            throw new InvalidOperationException("Source repo URL must be provided when outputting to an image info file.");
        }

        Dictionary<string, PlatformData> platformDataByTag = new Dictionary<string, PlatformData>();
        foreach (PlatformData platformData in GetProcessedPlatforms())
        {
            if (platformData.PlatformInfo is not null)
            {
                foreach (TagInfo tag in platformData.PlatformInfo.Tags)
                {
                    //platformDataByTag.Add(tag.FullyQuantifiedName, platformData);
                }
            }
        }

        IEnumerable<PlatformData> processedPlatforms = GetProcessedPlatforms();
        List<PlatformData> platformsWithNoPushTags = new List<PlatformData>();

        foreach (PlatformData platform in processedPlatforms)
        {
            IEnumerable<TagInfo> pushTags;

            //foreach (TagInfo tag in pushTags)
            //{
            //    if (Options.IsPushEnabled)
            //    {

            //    }
            //}

            //if (!pushTags.Any())
            //{
            //    platformsWithNoPushTags.Add(platform);
            //}
            //else
            //{

            //}
            
        }
    }

    private void SetComponents()
    {
        if (string.IsNullOrEmpty(Options.GetInstalledPackagesScriptPath))
        {
            return;
        }


    }

    private void SetPlatformDataCreatedDate(PlatformData platform, string tag)
    {
        DateTime createdDate = _dockerService.GetCreatedDate(tag, Options.IsDryRun).ToUniversalTime();
        if (platform.Created != default && platform.Created != createdDate)
        {
            // All of the tags associated with the platform should have the same Created date
            throw new InvalidOperationException(
                $"Tag '{tag}' has a Created date that differs from the corresponding image's Created date value of '{platform.Created}'.");
        }

        platform.Created = createdDate;
    }

    private void SetPlatformDataBaseDigest(PlatformData platform, Dictionary<string, PlatformData> platformDataByTag)
    {
        string? baseImageDigest = platform.BaseImageDigest;
        //if (platform.BaseImageDigest is null && platform.Pl)
    }

    private void BuildImages()
    {
        _loggerService.WriteHeading("BUILDING IMAGES");

        ImageArtifactDetails? srcImageArtifactDetails = null;
        if (Options.ImageInfoSourcePath != null)
        {
        }

        foreach (RepoInfo repoInfo in Manifest.FilteredRepos)
        {
            foreach (ImageInfo image in repoInfo.FilteredImages)
            {
                foreach (PlatformInfo platform in image.FilteredPlatforms)
                {
                    // Tag the built images with the shared tags as well as the platform tags.
                    // Some tests and image FROM instructions depend on these tags.

                    IEnumerable<TagInfo> allTagInfos = platform.Tags
                        .ToList();


                }
            }
        }
    }

    private void PullBaseImages()
    {
        if (!Options.IsSkipPullingEnabled)
        {
            Logger.WriteHeading("PULLING LATEST BASE IMAGES");
            //IEnumerable<string> baseImages = Manifest.ge
            //if (baseImages.Any())
            //{
            //    List<string> pulledTags = new List<string>();
            //    foreach (string pullTag in baseImages.Select(tag => tag))
            //    {
            //        pulledTags.Add(pullTag);

            //    }

            //    IEnumerable<string> finalStageExternalFromImages = new List<string>();

            //    if (false)
            //    {
            //        throw new InvalidOperationException(
            //            "The following tags are identified as final stage tags but were not pulled:" +
            //            Environment.NewLine +
            //            string.Join(", ", finalStageExternalFromImages.Except(pulledTags).ToArray()));
            //    }

            //    Parallel.ForEach(finalStageExternalFromImages, fromImage =>
            //    {

            //    });

            //    // Tag the images that were pulled from the mirror as they are referenced in the Dockerfiles
            //    Parallel.ForEach(baseImages, fromImage =>
            //    {

            //    });
            //}
            //else
            //{
            //    Logger.WriteMessage("No external base images to pull");
            //}
        }
    }

    private void WriteBuildSummary()
    {
        _loggerService.WriteHeading("IMAGES BUILT");

        if (_processedTags.Any())
        {
            foreach (TagInfo tag in _processedTags)
            {
                _loggerService.WriteMessage(tag.FullyQualifiedName);
            }
        }
        else
        {
            _loggerService.WriteMessage("No images built");
        }

        _loggerService.WriteMessage();
    }

    private IEnumerable<PlatformData> GetProcessedPlatforms() => _imageArtifactDetails?.Repos
        .Where(repoData => repoData.Images != null)
        .SelectMany(repoData => repoData.Images)
        .SelectMany(imageData => imageData.Platforms)
        ?? Enumerable.Empty<PlatformData>();

    private static string GetBuildCacheKey(PlatformInfo platform) =>
        $"{platform.DockerfilePathRelativeToManifest}-" +
        string.Join('-', platform.BuildArgs.Select(kvp => $"{kvp.Key}={kvp.Value}").ToArray());

    private class BuildCacheInfo
    {
        public BuildCacheInfo(string digest, string? baseImageDigest)
        {
            Digest = digest;
            BaseImageDigest = baseImageDigest;
        }

        public string Digest { get; }
        public string? BaseImageDigest { get; }
    }
}

