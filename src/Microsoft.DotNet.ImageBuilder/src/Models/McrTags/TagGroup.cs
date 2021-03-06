// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace Microsoft.DotNet.ImageBuilder.Models.McrTags
{
    public class TagGroup
    {
        public List<string> Tags { get; set; }

        public string Architecture { get; set; }

        [YamlMember(Alias = "os")]
        public string OS { get; set; }

        public string OsVersion { get; set; }

        public string Dockerfile { get; set; }

        public string CustomSubTableTitle { get; set; }
    }
}
