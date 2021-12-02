using LibGit2Sharp;

namespace TaiDev.DotNet.ImageBuilder;

public interface IGitService
{
    string GetCommitSha(string filePath, bool useFullHash = false);

    IRepository CloneRepository(string sourceUrl, string workdirPath, CloneOptions options);

    void Stage(IRepository repository, string path);
}
