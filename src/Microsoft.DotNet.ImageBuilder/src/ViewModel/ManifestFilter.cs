// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.DotNet.ImageBuilder.Models.Manifest;

#nullable enable
namespace Microsoft.DotNet.ImageBuilder.ViewModel
{
    public class ManifestFilter
    {
        public string? IncludeArchitecture { get; set; }
        public string? IncludeOsType { get; set; }
        public IEnumerable<string> IncludeRepos { get; set; }
        public IEnumerable<string>? IncludeOsVersions { get; set; }
        public IEnumerable<string>? IncludePaths { get; set; }
        public IEnumerable<string>? IncludeProductVersions { get; set; }

        public ManifestFilter(IEnumerable<string> repos)
        {
            IncludeRepos = repos;
        }

        public static string GetFilterRegexPattern(params string[] patterns)
        {
            string processedPatterns = patterns
                .Select(pattern => Regex.Escape(pattern).Replace(@"\*", ".*").Replace(@"\?", "."))
                .Aggregate((working, next) => $"{working}|{next}");
            return $"^({processedPatterns})$";
        }

        public IEnumerable<Platform> FilterPlatforms(IEnumerable<Platform> platforms, string? resolvedProductVersion)
        {
            if (IncludeProductVersions?.Any() ?? false)
            {
                string includeProductionVersionPattern = GetFilterRegexPattern(IncludeProductVersions.ToArray());
                if (resolvedProductVersion is not null &&
                    !Regex.IsMatch(resolvedProductVersion, includeProductionVersionPattern, RegexOptions.IgnoreCase))
                {
                    return Enumerable.Empty<Platform>();
                }
            }

            if (!string.IsNullOrEmpty(IncludeArchitecture))
            {
                string archRegexPattern = GetFilterRegexPattern(IncludeArchitecture);
                platforms = platforms.Where(platform =>
                    Regex.IsMatch(platform.Architecture.GetDockerName(), archRegexPattern, RegexOptions.IgnoreCase));
            }

            return platforms.ToArray();
        }
    }
}
