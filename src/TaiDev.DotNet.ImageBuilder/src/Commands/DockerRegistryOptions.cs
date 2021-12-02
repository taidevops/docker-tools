using System.CommandLine;

namespace TaiDev.DotNet.ImageBuilder.Commands;

public abstract class DockerRegistryOptions : ManifestOptions
{
    public RegistryCredentialsOptions CredentialsOptions { get; set; } = new RegistryCredentialsOptions();
}

public abstract class DockerRegistryOptionsBuilder : ManifestOptionsBuilder
{
    private readonly RegistryCredentialsOptionsBuilder _registryCredentialsOptionsBuilder =
        new RegistryCredentialsOptionsBuilder();

    public override IEnumerable<Option> GetCliOptions() =>
        base.GetCliOptions().Concat(_registryCredentialsOptionsBuilder.GetCliOptions());

    public override IEnumerable<Argument> GetCliArguments() =>
        base.GetCliArguments().Concat(_registryCredentialsOptionsBuilder.GetCliArguments());
}
