
using TaiDev.DotNet.ImageBuilder.ViewModel;

namespace TaiDev.DotNet.ImageBuilder.Commands;

internal interface IManifestCommand : ICommand
{
    ManifestInfo Manifest { get; }

    void LoadManifest();
}

