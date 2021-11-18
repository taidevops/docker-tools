// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using Microsoft.DotNet.ImageBuilder.ViewModel;
using static Microsoft.DotNet.ImageBuilder.Commands.CliHelper;

#nullable enable
namespace Microsoft.DotNet.ImageBuilder.Commands
{
    public class ManifestFilterOptions
    {
        public string Architecture { get; set; } = string.Empty;
        public string OsType { get; set; } = string.Empty;
        public IEnumerable<string> OsVersions { get; set; } = Array.Empty<string>();
        public IEnumerable<string> Paths { get; set; } = Array.Empty<string>();
        public IEnumerable<string> ProductVersions { get; set; } = Array.Empty<string>();
    }

    public class ManifestFilterOptionsBuilder
    {
        public const string PathOptionName = "path";
        public const string OsVersionOptionName = "os-version";

        public IEnumerable<Option> GetCliOptions() =>
            new Option[]
            {
                CreateOption("architecture", nameof(ManifestFilterOptions.Architecture),
                    "Architecture of Dockerfiles to operate on - wildcard chars * and ? supported (default is current OS architecture)",
                    () => DockerHelper.Architecture.GetDockerName()),
            };

        public IEnumerable<Argument> GetCliArguments() => Enumerable.Empty<Argument>();
    }
}
#nullable disable
