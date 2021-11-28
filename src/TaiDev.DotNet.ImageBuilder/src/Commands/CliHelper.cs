
using System.CommandLine;

namespace TaiDev.DotNet.ImageBuilder.Commands;

internal static class CliHelper
{
    public static Option<T> CreateOption<T>(string alias, string propertyName, string description, T defaultValue = default!) =>
        CreateOption(alias, propertyName, description, () => defaultValue);

    public static Option<T> CreateOption<T>(string alias, string propertyName, string description, Func<T> defaultValue) =>
        new Option<T>(FormatAlias(alias), defaultValue!, description)
        {
            Name = propertyName
        };

    public static string FormatAlias(string alias) => $"--{alias}";
}

