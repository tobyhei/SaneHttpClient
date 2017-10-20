using System;
using System.Net.Http;
using SaneHttpClient.Abstractions;

namespace SaneHttpClient
{
    /// <summary>
    /// An implementation of <see cref="IHttpClient"/> which allows custom configuration
    /// and is therefore not safe to share
    /// </summary>
    public class UniqueHttpClient : HttpClientBase, IUniqueHttpClient
    {
        /// <summary>
        /// Creates an instance of <see cref="UniqueHttpClient"/>
        /// </summary>
        public UniqueHttpClient()
            : base(new HttpClient())
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="UniqueHttpClient"/>
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="disposeHandler"></param>
        public UniqueHttpClient(HttpMessageHandler handler, bool disposeHandler = true)
            : base(new HttpClient(handler, disposeHandler))
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="UniqueHttpClient"/>
        /// </summary>
        /// <param name="httpClient"></param>
        internal UniqueHttpClient(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public TimeSpan Timeout => HttpClient.Timeout;
        public long MaxResponseContentBufferSize => HttpClient.MaxResponseContentBufferSize;
        public Uri BaseAddress => HttpClient.BaseAddress;
    }
}