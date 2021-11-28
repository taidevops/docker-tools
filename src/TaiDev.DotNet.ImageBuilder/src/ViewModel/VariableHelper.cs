
namespace TaiDev.DotNet.ImageBuilder.ViewModel;

public class VariableHelper
{
    private const char BuiltInDelimiter = ':';

    public IDictionary<string, string?> ResolvedVariables { get; } = new Dictionary<string, string?>();
}

