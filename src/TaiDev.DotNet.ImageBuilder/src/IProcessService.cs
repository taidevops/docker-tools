using System.Diagnostics;

namespace TaiDev.DotNet.ImageBuilder;

public interface IProcessService
{
    string? Execute(string fileName, string args, bool isDryRun, string? errorMessage = null, string? executeMessageOverride = null);

    string? Execute(ProcessStartInfo info, bool isDryRun, string? errorMessage = null, string? executeMessageOverride = null);
}

