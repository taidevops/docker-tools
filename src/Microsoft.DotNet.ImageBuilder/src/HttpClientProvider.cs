// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel.Composition;
using System.Net.Http;
using System.Threading;

namespace Microsoft.DotNet.ImageBuilder
{
    [Export(typeof(IHttpClientProvider))]
    internal class HttpClientProvider : IHttpClientProvider
    {
        private readonly Lazy<HttpClient> _httpClient;

        [ImportingConstructor]
        public HttpClientProvider(ILoggerService loggerService)
        {
            if (loggerService is null)
            {
                throw new ArgumentNullException(nameof(loggerService));
            }

            _httpClient = new Lazy<HttpClient>(() => new HttpClient(new LoggingHandler(loggerService)));
        }

        public HttpClient GetClient()
        {
            return _httpClient.Value;
        }

        private class LoggingHandler : MessageProcessingHandler
        {
            private readonly ILoggerService _loggerService;

            public LoggingHandler(ILoggerService loggerService)
            {
                _loggerService = loggerService;
                InnerHandler = new HttpClientHandler();
            }

            protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                _loggerService.WriteMessage($"Sending HTTP request: {request.RequestUri}");
                return request;
            }

            protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
            {
                return response;
            }
        }
    }
}
