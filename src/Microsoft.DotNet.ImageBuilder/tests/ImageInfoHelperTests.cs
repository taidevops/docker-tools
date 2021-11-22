// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.DotNet.ImageBuilder.Models.Image;
using Microsoft.DotNet.ImageBuilder.Models.Manifest;
using Microsoft.DotNet.ImageBuilder.Tests.Helpers;
using Microsoft.DotNet.ImageBuilder.ViewModel;
using Moq;
using Xunit;

using static Microsoft.DotNet.ImageBuilder.Tests.Helpers.DockerfileHelper;
using static Microsoft.DotNet.ImageBuilder.Tests.Helpers.ManifestHelper;

namespace Microsoft.DotNet.ImageBuilder.Tests
{
    public class ImageInfoHelperTests
    {
        [Fact]
        public void LoadFromContent()
        {
            ImageArtifactDetails imageArtifactDetails = new ImageArtifactDetails
            {
                Repos =
                {
                    new RepoData
                    {
                        Repo = "runtime",
                        Images =
                        {
                            new ImageData
                            {
                                Platforms =
                                {
                                    new PlatformData
                                    {
                                        Dockerfile = "1.0/runtime/linux/Dockerfile",
                                        OsType = "Linux",
                                        OsVersion = "focal",
                                        Architecture = "amd64",
                                        SimpleTags = new List<string> { "linux" }
                                    },
                                    new PlatformData
                                    {
                                        Dockerfile = "1.0/runtime/windows/Dockerfile",
                                        OsType = "Windows",
                                        OsVersion = "nanoserver-2004",
                                        Architecture = "amd64",
                                        SimpleTags = new List<string> { "windows" }
                                    }
                                },
                                Manifest = new ManifestData
                                {
                                    SharedTags = new List<string>
                                    {
                                        "shared"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            using TempFolderContext tempFolderContext = new TempFolderContext();

            Manifest manifest = CreateManifest(
                CreateRepo("runtime",
                    CreateImage(
                        new Platform[]
                        {
                            CreatePlatform(
                                CreateDockerfile("1.0/runtime/linux", tempFolderContext),
                                new string[] { "linux" },
                                OS.Linux,
                                "focal"),
                            CreatePlatform(
                                CreateDockerfile("1.0/runtime/windows", tempFolderContext),
                                new string[] { "windows" },
                                OS.Windows,
                                "nanoserver-2004")
                        },
                        new Dictionary<string, Tag>
                        {
                            { "shared", new Tag() }
                        }))
            );

            string manifestPath = Path.Combine(tempFolderContext.Path, "manifest.json");
            File.WriteAllText(manifestPath, JsonHelper.SerializeObject(manifest));

            ManifestInfo manifestInfo = ManifestInfo.Load(new FakeManifestOptions(manifestPath));
            string expected = JsonHelper.SerializeObject(imageArtifactDetails);

            ImageArtifactDetails result = ImageInfoHelper.LoadFromContent(expected, manifestInfo);

            Assert.Equal(expected, JsonHelper.SerializeObject(result));
            RepoData repo = result.Repos.First();
            ImageData image = repo.Images.First();
            RepoInfo expectedRepo = manifestInfo.AllRepos.First();
            ImageInfo expectedImage = expectedRepo.AllImages.First();
            Assert.Same(expectedImage, image.ManifestImage);
            Assert.Same(expectedRepo, image.ManifestRepo);

            Assert.Same(expectedImage, image.Platforms.First().ImageInfo);
            Assert.Same(expectedImage.AllPlatforms.First(), image.Platforms.First().PlatformInfo);
            Assert.Same(expectedImage.AllPlatforms.Last(), image.Platforms.Last().PlatformInfo);
        }

        private class FakeManifestOptions : IManifestOptionsInfo
        {
            public FakeManifestOptions(string manifestPath)
            {
                Manifest = manifestPath;
            }

            public string Manifest { get; }

            public string RegistryOverride => null;

            public string RepoPrefix => null;

            public IDictionary<string, string> Variables { get; } = new Dictionary<string, string>();

            public bool IsDryRun => false;

            public bool IsVerbose => false;

            public ManifestFilter GetManifestFilter() => new ManifestFilter(Enumerable.Empty<string>());

            public string GetOption(string name) => throw new NotImplementedException();
        }
    }
}

