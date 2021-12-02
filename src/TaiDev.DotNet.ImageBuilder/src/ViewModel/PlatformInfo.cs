// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaiDev.DotNet.ImageBuilder.Models.Manifest;

namespace TaiDev.DotNet.ImageBuilder.ViewModel;

public class PlatformInfo
{
    private const string ArgGroupName = "arg";
    private const string FromImageMatchName = "fromImage";
    private const string StageIdMatchName = "stageId";
    private const string ScratchIdentifier = "scratch";

    private static Regex FromRegex { get; } = new Regex($@"FROM\s+(?<{FromImageMatchName}>\S+)(\s+AS\s+(?<{StageIdMatchName}>\S+))?");

    private static readonly string s_argPattern = $"\\$(?<{ArgGroupName}>[\\w\\d-_]+)";

    private List<string> _overriddenFromImages = new();
    private IEnumerable<string> _internalRepos = Enumerable.Empty<string>();

    public string BaseOsVersion { get; private set; }

    public Platform Model { get; private set; }

    public IEnumerable<TagInfo> Tags { get; private set; }

    private PlatformInfo(Platform model, string baseOsVersion)
    {
        Model = model;
        BaseOsVersion = baseOsVersion;
    }

    public static PlatformInfo Create(Platform model) =>
        new(
            model,
            model.OsVersion.TrimEnd("-slim"));

    public string GetOSDisplayName()
    {
        string os = BaseOsVersion;

        if (Model.OS == OS.Windows)
        {
            string version = os.Split('-')[1];
            return os switch
            {
                string a when a.StartsWith("nanoserver") => GetWindowsVersionDisplayName("Nano Server", version),
                string a when a.StartsWith("windowsservercore") => GetWindowsVersionDisplayName("Windows Server Core", version),
                _ => throw new NotSupportedException($"The OS version '{os}' is not supported.")
            };
        }
        else
        {
            return os switch
            {
                string a when a.Contains("debian") => "Debian",
                string a when a.Contains("jessie") => "Debian 8",
                string a when a.Contains("stretch") => "Debian 9",
                string a when a.Contains("buster") => "Debian 10",
                string a when a.Contains("bullseye") => "Debian 11",
                string a when a.Contains("xenial") => "Ubuntu 16.04",
                string a when a.Contains("bionic") => "Ubuntu 18.04",
                string a when a.Contains("disco") => "Ubuntu 19.04",
                string a when a.Contains("focal") => "Ubuntu 20.04",
                string a when a.Contains("hirsute") => "Ubuntu 21.04",
                string a when a.Contains("impish") => "Ubuntu 21.10",
                string a when a.Contains("alpine") || a.Contains("centos") || a.Contains("fedora")
                    => FormatVersionableOsName(a, name => name.FirstCharToUpper()),
                string a when a.Contains("cbl-mariner") => FormatVersionableOsName(a, name => "CBL-Mariner"),
                string a when a.Contains("leap") => FormatVersionableOsName(a, name => "openSUSE Leap"),
                _ => throw new NotSupportedException($"The OS version '{os}' is not supported.")
            };
        }
    }

    private static string GetWindowsVersionDisplayName(string windowsName, string version)
    {
        if (version.StartsWith("ltsc"))
            return $"{windowsName} {version.TrimStart("ltsc")}";
        return $"{windowsName}, version {version}";

    }

    private static string FormatVersionableOsName(string os, Func<string, string> formatName)
    {
        (string osName, string osVersion) = GetOsVersionInfo(os);
        if (string.IsNullOrEmpty(osVersion))
            return formatName(osName);
        return $"{formatName(osName)} {osVersion}";
    }

    private static (string Name, string Version) GetOsVersionInfo(string osVersion)
    {
        int versionIndex = osVersion.IndexOfAny(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
        if (versionIndex != -1)
        {
            return (osVersion.Substring(0, versionIndex), osVersion.Substring(versionIndex));
        }

        return (osVersion, string.Empty);
    }
}

