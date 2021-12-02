

using System.ComponentModel.Composition;
using TaiDev.DotNet.ImageBuilder.Models.Image;
using TaiDev.DotNet.ImageBuilder.ViewModel;

namespace TaiDev.DotNet.ImageBuilder.Commands;

[Export(typeof(ICommand))]
internal class BuildCommand : DockerRegistryCommand<BuildOptions, BuildOptionsBuilder>
{
    private readonly IDockerService _dockerService;
    private readonly ILoggerService _loggerService;

    [ImportingConstructor]
    public BuildCommand(IDockerService dockerService, ILoggerService loggerService)
    {
        _loggerService = loggerService;
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

       
    }

    private void SetComponents()
    {
        if (string.IsNullOrEmpty(Options.GetInstalledPackagesScriptPath))
        {
            return;
        }


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
            IEnumerable<string> baseImages = new List<string>();
            if (baseImages.Any())
            {
                List<string> pulledTags = new List<string>();
                foreach (string pullTag in baseImages.Select(tag => tag))
                {
                    pulledTags.Add(pullTag);

                }

                IEnumerable<string> finalStageExternalFromImages = new List<string>();

                if (false)
                {
                    throw new InvalidOperationException(
                        "The following tags are identified as final stage tags but were not pulled:" +
                        Environment.NewLine +
                        string.Join(", ", finalStageExternalFromImages.Except(pulledTags).ToArray()));
                }

                Parallel.ForEach(finalStageExternalFromImages, fromImage =>
                {

                });

                // Tag the images that were pulled from the mirror as they are referenced in the Dockerfiles
                Parallel.ForEach(baseImages, fromImage =>
                {

                });
            }
            else
            {
                Logger.WriteMessage("No external base images to pull");
            }
        }
    }

    private void WriteBuildSummary()
    {
        _loggerService.WriteHeading("IMAGES BUILT");
    }
}

