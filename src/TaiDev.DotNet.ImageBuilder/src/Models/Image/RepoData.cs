using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace TaiDev.DotNet.ImageBuilder.Models.Image;

public class RepoData : IComparable<RepoData>
{
    [JsonProperty(Required = Required.Always)]
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
