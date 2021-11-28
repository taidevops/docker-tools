using TaiDev.DotNet.ImageBuilder.ViewModel;

namespace TaiDev.DotNet.ImageBuilder.Commands;

#nullable disable
public abstract class ManifestCommand<TOptions, TOptionsBuilder> : Command<TOptions, TOptionsBuilder>, IManifestCommand
    where TOptions : ManifestOptions, new()
    where TOptionsBuilder : ManifestOptionsBuilder, new()
{
    public ManifestInfo Manifest { get; private set; }

    public virtual void LoadManifest()
    {
        if (Manifest is null)
        {
            Manifest = ManifestInfo.Load(Options);
        }
    }

    protected override void Initialize(TOptions options)
    {
        base.Initialize(options);
        LoadManifest();
    }
}
#nullable enable
