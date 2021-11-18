// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FilePusher.Models;
using Microsoft.DotNet.VersionTools.Automation;
using Microsoft.DotNet.VersionTools.Automation.GitHubApi;
using Newtonsoft.Json;

namespace FilePusher
{
    public class FilePusher
    {
        public static Task Main(string[] args)
        {
            RootCommand command = new RootCommand();
            foreach (Symbol symbol in Options.GetCliOptions())
            {
                command.Add(symbol);
            }

            command.Handler = CommandHandler.Create<Options>()
        }

        private static async Task ExecuteAsync(Options options)
        {
            // TODO:    Add support for delete file scenarios

            // Hookup a TraceListener to capture details from Microsoft.DotNet.VersionTools
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

            string configJson = File.ReadAllText(options.ConfigPath);
            Config config = JsonConvert.DeserializeObject<Config>(configJson);
            await 
        }

        private async static Task AddUpdatedFile(
            List<GitObject> updatedFiles,
            GitHubClient client,
            GitHubBranch branch,
            string filePath,
            string updatedContent)
        {
            if (updatedContent.Contains("\r\n"))
            {
                updatedContent = updatedContent.Replace("\r\n", "\n");
            }

            filePath = filePath.Replace('\\', '/');
            string currentContent = await client.GetGitHubFileContentsAsync(filePath, branch);

            if (currentContent == updatedContent)
            {
                Console.WriteLine($"File '{filePath}' has not changed.");
            }
            else
            {
                Console.WriteLine($"File '{filePath}' has changed.");
                updatedFiles.Add(new GitObject
                {
                    Path = filePath,
                    Type = GitObject.TypeBlob,
                    Mode = GitObject.ModeFile,
                    Content = updatedContent
                });
            }
        }

        private static IEnumerable<string> GetFiles(string path)
        {
            if (File.Exists(path))
            {
                return new string[] { path };
            }
            else
            {
                return Directory.GetDirectories(path)
                    .SelectMany(dir => GetFiles(dir))
                    .Concat(Directory.GetFiles(path));
            }
        }


        private static string GetFilterRegexPattern(params string[] patterns)
        {
            string processedPatterns = patterns
                .Select(pattern => Regex.Escape(pattern).Replace(@"\*", ".*").Replace(@"\?", "."))
                .Aggregate((working, next) => $"{working}|{next}");
            return $"^({processedPatterns})$";
        }

        private async static Task<GitObject[]> GetUpdatedFiles(string sourcePath, GitHubClient client, GitHubBranch branch)
        {
            List<GitObject> updatedFiles = new List<GitObject>();

            foreach (string file in GetFiles(sourcePath))
            {
                await AddUpdatedFile(updatedFiles, client, branch, file, File.ReadAllText(file));
            }

            return updatedFiles.ToArray();
        }
    }
}
