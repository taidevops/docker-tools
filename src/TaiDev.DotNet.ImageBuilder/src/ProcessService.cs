
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace TaiDev.DotNet.ImageBuilder;

[Export(typeof(IProcessService))]
public class ProcessService : IProcessService
{
    public string? Execute(
        string fileName, string args, bool isDryRun, string? errorMessage = null, string? executeMessageOverride = null) =>
        ExecuteHelper.Execute(fileName, args, isDryRun, errorMessage, executeMessageOverride);

    public string? Execute(
        ProcessStartInfo info, bool isDryRun, string? errorMessage = null, string? executeMessageOverride = null) =>
        ExecuteHelper.Execute(info, isDryRun, errorMessage, executeMessageOverride);
}
