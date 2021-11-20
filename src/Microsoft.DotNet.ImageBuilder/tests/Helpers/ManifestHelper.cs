// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.DotNet.ImageBuilder.Models.Manifest;
using Microsoft.DotNet.ImageBuilder.ViewModel;
using Moq;

namespace Microsoft.DotNet.ImageBuilder.Tests.Helpers
{
    public static class ManifestHelper
    {
        public static IManifestOptionsInfo GetManifestOptions(string manifestPath)
        {
            Mock<IManifestOptionsInfo> manifestOptionsMock = new Mock<IManifestOptionsInfo>();

            manifestOptionsMock
                .SetupGet(o => o.Manifest)
                .Returns(manifestPath);

            manifestOptionsMock
                .Setup(o => o.GetManifestFilter())
                .Returns(new ManifestFilter(Enumerable.Empty<string>()));

            return manifestOptionsMock.Object;
        }
    }
}
