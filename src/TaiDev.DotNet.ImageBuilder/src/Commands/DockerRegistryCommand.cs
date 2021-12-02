
namespace TaiDev.DotNet.ImageBuilder.Commands;

public abstract class DockerRegistryCommand<TOptions, TOptionsBuilder> : ManifestCommand<TOptions, TOptionsBuilder>
    where TOptions : DockerRegistryOptions, new()
    where TOptionsBuilder : DockerRegistryOptionsBuilder, new()
{
    protected void ExecuteWithUser(Action action)
    {
        Options.CredentialsOptions.Credentials.TryGetValue(Manifest.Registry ?? "", out RegistryCredentials? credentials);
        DockerHelper.ExecuteWithUser(action, credentials?.Username, credentials?.Password, Manifest.Registry, Options.IsDryRun);
    }
}

