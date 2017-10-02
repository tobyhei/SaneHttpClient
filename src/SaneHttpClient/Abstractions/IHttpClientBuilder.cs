using System;
using System.Net.Http.Headers;

namespace SaneHttpClient.Abstractions
{
    public interface IHttpClientBuilder
    {
        IUniqueHttpClient Build();

        HttpRequestHeaders DefaultRequestHeaders { get; }
        TimeSpan Timeout { get; set; }
        long MaxResponseContentBufferSize { get; set; }
        Uri BaseAddress { get; set; }

        IHttpClientBuilder SetTimeout(TimeSpan timeout);
        IHttpClientBuilder SetMaxResponseContentBufferSize(long maxResponseContentBufferSize);
        IHttpClientBuilder SetBaseAddress(Uri baseAddress);
    }
}