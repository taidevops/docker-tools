// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaiDev.DotNet.ImageBuilder.Models.Manifest;

namespace TaiDev.DotNet.ImageBuilder;

public static class DockerHelper
{
    private static readonly Lazy<Architecture> s_architecture = new(GetArchitecture);
    private static readonly Lazy<OS> s_os = new(GetOS);

    public static Architecture Architecture => s_architecture.Value;
    public static OS OS => s_os.Value;

    public const string DockerHubRegistry = "docker.io";

    public static void ExecuteWithUser(Action action, string? username, string? password, string? server, bool isDeryRun)
    {
        bool loggedIn = false;
        if (username is not null && password is not null)
    }

    public static void Login(string username, string password, string server, bool isDryRun)
    {
        Version? clientVersion = 
    }

    public static Docker

    public static string? GetRegistry(string imageName)
    {
        int separatorIndex = imageName.IndexOf("/");
        if (separatorIndex >= 0)
        {
            string firstSegment = imageName.Substring(0, separatorIndex);
            if (firstSegment.Contains(".") || firstSegment.Contains(":"))
            {
                return firstSegment;
            }
        }


        return null;
    }

    private static int GetTagOrDigestSeparatorIndex(string imageName)
    {
        int separatorPosition = imageName.IndexOf('@');
        if (separatorPosition < 0)
        {
            separatorPosition = imageName.IndexOf(':');
        }

        return separatorPosition;
    }

    private static OS GetOS()
    {
        string osString = ExecuteCommandWithFormat("version", ".Server.Os", "Failed to detect Docker OS");
        if (!Enum.TryParse(osString, true, out OS os))
        {
            throw new PlatformNotSupportedException("Unknown Docker OS");
        }

        return os;
    }

    private static Version? GetClientVersion()
    {
        // Docker version string format - <major>.<minor>.<patch>-[ce,ee]
        string versionString = ExecuteCommandWithFormat("version", ".Client.Version", "Failed to retrieve Docker version");

        if (versionString.Contains('-'))
        {
            // Trim off the '-ce' or '-ee' suffix
            versionString = versionString.Substring(0, versionString.IndexOf('-'));
        }

        return Version.TryParse(versionString, out Version? version) ? version : null;
    }

    private static void Logout(string server, bool isDryRun)
    {
        ExecuteHelper.ExecuteWithRetry("docker", $"logout {server}", isDryRun);
    }

    private static bool ResourceExists(ManagementType type, string filterArg, bool isDryRun)
    {
        string output = ExecuteCommand(
            $"{Enum.GetName(typeof(ManagementType), type)?.ToLowerInvariant()} ls -a -q {filterArg}",
            "Failed to find resource",
            isDryRun: isDryRun);
        return output != "";
    }

    private static Architecture GetArchitecture()
    {
        string infoArchitecture = ExecuteCommandWithFormat(
            "info", ".Architecture", "Failed to detect Docker architecture");

        return infoArchitecture switch
        {
            "x86_64" => Architecture.AMD64,
            "arm" or "arm_32" or "armv7l" => Architecture.ARM,
            "aarch64" or "arm64" => Architecture.ARM64,
            _ => throw new PlatformNotSupportedException($"Unknown Docker Architecture '{infoArchitecture}'")
        };
    }

    private static string ExecuteCommand(
        string command, string errorMessage, string? additionalArgs = null, bool isDryRun = false)
    {
        string? output = ExecuteHelper.Execute("docker", $"{command} {additionalArgs}", isDryRun, errorMessage);
        return isDryRun ? "" : output!;
    }

    private static string ExecuteCommandWithFormat(
        string command, string outputFormat, string errorMessage, string? additionalArgs = null, bool isDryRun = false) =>
        ExecuteCommand(command, errorMessage, $"{additionalArgs} -f \"{{{{ {outputFormat} }}}}\"", isDryRun);

    private enum ManagementType
    {
        Image,
        Container,
    }
}

