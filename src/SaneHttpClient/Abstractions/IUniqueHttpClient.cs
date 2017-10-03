using System;

namespace SaneHttpClient.Abstractions
{
    /// <summary>
    /// Exposes an interface over <see cref="IHttpClient"/> that is uniquely configured and should not be shared
    /// </summary>
    public interface IUniqueHttpClient : IHttpClient
    {
        TimeSpan Timeout { get; }
        long MaxResponseContentBufferSize { get; }
        Uri BaseAddress { get; }
    }
}