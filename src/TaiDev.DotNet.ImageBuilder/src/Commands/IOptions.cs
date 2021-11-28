namespace TaiDev.DotNet.ImageBuilder.Commands;

public interface IOptions
{
    bool IsDryRun { get; }
    bool IsVerbose { get; }
    string? GetOption(string name);
}

