// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaiDev.DotNet.ImageBuilder.ViewModel;

namespace TaiDev.DotNet.ImageBuilder.Models.Image
{
    public class PlatformData : IComparable<PlatformData>
    {
        public PlatformData()
        {
        }

        public string Dockerfile { get; set; } = string.Empty;

        public string Digest { get; set; } = string.Empty;

        public string? BaseImageDigest { get; set; }

        public string OsType { get; set; }

        public string OsVersion { get; set; }

        public string Architecture { get; set; } = string.Empty;

        public DateTime Created { get; set; }

        public string CommitUrl { get; set; } = string.Empty;

        public List<Component> Components { get; set; } = new();

        public bool IsUnchanged { get; set; }

        [JsonIgnore]
        public ImageInfo? ImageInfo { get; set; }

        public int CompareTo(PlatformData? other) => throw new NotImplementedException();

        // Product versions are considered equivalent if the major and minor segments are the same
        // See https://github.com/dotnet/docker-tools/issues/688
        public string GetIdentifier(bool excludeProductVersion = false) =>
            $"{Dockerfile}{(excludeProductVersion ? "" : "-" + GetMajorMinorVersion())}";

        private string? GetMajorMinorVersion()
        {
            string? fullVersion = ImageInfo.ProductVersion;

            return new Version(fullVersion).ToString(2);
        }
    }
}
