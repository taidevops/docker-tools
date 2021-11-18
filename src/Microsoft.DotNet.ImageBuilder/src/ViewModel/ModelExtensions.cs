// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.DotNet.ImageBuilder.Models.Manifest;

namespace Microsoft.DotNet.ImageBuilder.ViewModel
{
    public static class ModelExtensions
    {
        public static string GetDockerName(this Architecture architecture) => architecture.ToString().ToLowerInvariant();

        public static string GetDockerName(this OS os) => os.ToString().ToLowerInvariant();
    }
}
