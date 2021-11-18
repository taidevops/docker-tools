// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using Microsoft.DotNet.ImageBuilder.Models.Image;
using Microsoft.DotNet.ImageBuilder.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#nullable enable
namespace Microsoft.DotNet.ImageBuilder.Commands
{
    [Export(typeof(ICommand))]
    public class BuildCommand : DockerRegistryCommand<BuildOptions, BuildOptionsBuilder>
    {
        private readonly IDockerService _dockerService;
        private readonly ILoggerService _loggerService;
        private readonly ImageDigestCache _imageDigestCache;

        // Metadata about Dockerfiles whose images have been retrieved from the cache
        private readonly Dictionary<string, BuildCacheInfo> _cachedDockerfilePaths = new Dictionary<string, BuildCacheInfo>();

        [ImportingConstructor]
        public BuildCommand(IDockerService dockerService, ILoggerService loggerService)
        {
            _imageDigestCache = new ImageDigestCache(dockerService);
            _dockerService = new DockerServiceCache(dockerService ?? throw new ArgumentNullException(nameof(dockerService)));
            _loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }

        protected override string Description => "Builds Dockerfiles";

        public override Task ExecuteAsync()
        {
            ExecuteWithUser(() =>
            {

            });

            return Task.CompletedTask;
        }

        private void PullBaseImages()
        {
            if (!Options.IS)
        }

        private class BuildCacheInfo
        {
            public BuildCacheInfo(string digest, string? baseImageDigest)
            {
                Digest = digest;
                BaseImageDigest = baseImageDigest;
            }

            public string Digest { get; }
            public string? BaseImageDigest { get; }
        }
    }
}
#nullable restore
