// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;

namespace TaiDev.DotNet.ImageBuilder.Models.Image;

#nullable disable
public class RepoData : IComparable<RepoData>
{
    public string Repo { get; set; }

    public List<ImageData> Images { get; set; } = new List<ImageData>();

    public int CompareTo([AllowNull] RepoData other)
    {
        if (other is null)
        {
            return 1;
        }

        return Repo.CompareTo(other.Repo);
    }
}
#nullable enable
