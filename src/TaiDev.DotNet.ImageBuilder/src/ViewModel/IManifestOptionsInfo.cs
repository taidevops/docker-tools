using TaiDev.DotNet.ImageBuilder.Commands;

namespace TaiDev.DotNet.ImageBuilder.ViewModel;

#nullable disable
public interface IManifestOptionsInfo : IOptions
{
    string Manifest { get; }
    string RegistryOverride { get; }
    string RepoPrefix { get; }
    IDictionary<string, string> Variables { get; }
}
#nullable enable
