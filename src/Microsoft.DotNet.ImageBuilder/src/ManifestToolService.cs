// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.Composition;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.DotNet.ImageBuilder
{
    [Export(typeof(IManifestToolService))]
    public class ManifestToolService : IManifestToolService
    {
        public const string ManifestListMediaType = "application/vnd.docker.distribution.manifest.list.v2+json";
        public const string ManifestMediaType = "application/vnd.docker.distribution.manifest.v2+json";

        public JArray Inspect(string image, bool isDryRun) => throw new System.NotImplementedException();
        public void PushFromSpec(string manifestFile, bool isDryRun) => throw new System.NotImplementedException();
    }
}
