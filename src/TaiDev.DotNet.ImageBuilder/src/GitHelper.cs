using System.Diagnostics;
using System.IO.Compression;

namespace TaiDev.DotNet.ImageBuilder;

#nullable disable
public static class GitHelper
{
    private const int DefaultMaxTries = 10;
    private const int DefaultRetryMillisecondsDelay = 5000;

    public static string GetCommitSha(string filePath, bool useFullHash = false)
    {
        // Don't make the assumption that the current working directory is a Git repository
        // Find the Git repo that contains the file being checked.
        DirectoryInfo directory = new FileInfo(filePath).Directory;
        while (!directory.GetDirectories(".git").Any())
        {
            directory = directory.Parent;

            if (directory is null)
            {
                throw new InvalidOperationException($"File '{filePath}' is not contained within a Git repository.");
            }
        }

        filePath = Path.GetRelativePath(directory.FullName, filePath);

        string format = useFullHash ? "H" : "h";
        return ExecuteHelper.Execute(
            new ProcessStartInfo("git", $"log -1 --format=format:%{format} {filePath}")
            {
                WorkingDirectory = directory.FullName
            },
            false,
            $"Unable to retrieve the latest commit SHA for {filePath}");
    }

    public static Uri GetArchiveUrl(IGitHubBranchRef branchRef) =>
        new Uri($"https://github.com/{branchRef.Owner}/{branchRef.Repo}/archive/{branchRef.Branch}.zip");

    public static async Task<string> DownloadAndExtractGitRepoArchiveAsync(
        HttpClient httpClient, IGitHubBranchRef branchRef, ILoggerService loggerService)
    {
        string uniqueName = $"{branchRef.Owner}-{branchRef.Repo}-{branchRef.Branch}";
        string extractPath = Path.Combine(Path.GetTempPath(), uniqueName);
        Uri repoContentsUrl = GetArchiveUrl(branchRef);
        string zipPath = Path.Combine(Path.GetTempPath(), $"{uniqueName}.zip");
        byte[] bytes = await RetryHelper.GetWaitAndRetryPolicy<Exception>(loggerService)
            .ExecuteAsync(() => httpClient.GetByteArrayAsync(repoContentsUrl));
        File.WriteAllBytes(zipPath, bytes);

        try
        {
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
        finally
        {
            File.Delete(zipPath);
        }

        return Path.Combine(extractPath, $"{branchRef.Repo}-{branchRef.Branch}");
    }
}
#nullable enable
