// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace TaiDev.DotNet.ImageBuilder;

[Export(typeof(IGitService))]
public class GitService : IGitService
{
    public IRepository CloneRepository(string sourceUrl, string workdirPath, CloneOptions options) => throw new NotImplementedException();
    public string GetCommitSha(string filePath, bool useFullHash = false) => throw new NotImplementedException();
    public void Stage(IRepository repository, string path) => throw new NotImplementedException();
}

