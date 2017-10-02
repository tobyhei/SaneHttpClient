using System;
using System.Net.Http.Headers;

namespace SaneHttpClient.Abstractions
{
    public interface IUniqueHttpClientBuilder
    {
        HttpRequestHeaders DefaultRequestHeaders { get; }
        TimeSpan Timeout { get; set; }
        long MaxResponseContentBufferSize { get; set; }
        Uri BaseAddress { get; set; }

        IUniqueHttpClient Build();
    }
}
