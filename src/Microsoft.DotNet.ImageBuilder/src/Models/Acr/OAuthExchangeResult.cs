﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Newtonsoft.Json;

namespace Microsoft.DotNet.ImageBuilder.Models.Acr
{
    public class OAuthExchangeResult
    {
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
