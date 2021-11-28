// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaiDev.DotNet.ImageBuilder.Models.Manifest;

namespace TaiDev.DotNet.ImageBuilder;

[Export(typeof(IDockerService))]
internal class DockerService : IDockerService
{
    private readonly IManifestToolService _manifestToolService;

    public Architecture Architecture => Dock

}
