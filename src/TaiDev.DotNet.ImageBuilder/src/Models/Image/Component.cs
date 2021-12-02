using System.Diagnostics.CodeAnalysis;

namespace TaiDev.DotNet.ImageBuilder.Models.Image;

public class Component : IComparable<Component>
{
    public string Name { get; }
    public string Version { get; }
    public string Type { get; }

    public Component(string type, string name, string version)
    {
        Type = type;
        Name = name;
        Version = version;
    }

    public int CompareTo([AllowNull] Component other)
    {
        if (other is null)
        {
            return 1;
        }

        return ToString().CompareTo(other.ToString());
    }

    public override string ToString() => $"{Type}:{Name}={Version}";
}

