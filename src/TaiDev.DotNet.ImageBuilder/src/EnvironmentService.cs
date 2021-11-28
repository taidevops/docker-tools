
using System.ComponentModel.Composition;

namespace TaiDev.DotNet.ImageBuilder;

[Export(typeof(IEnvironmentService))]
public class EnvironmentService : IEnvironmentService
{
    public void Exit(int exitCode)
    {
        Environment.Exit(exitCode);
    }
}

