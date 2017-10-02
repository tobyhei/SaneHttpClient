using System;
using System.Net.Http;
using SaneHttpClient.Abstractions;

namespace SaneHttpClient
{
    /// <summary>
    /// Implementation of <see cref="ISharedHttpClient"/> which does not expose it's internal <see cref="HttpClient"/>
    /// or any of it's stateful methods making it safe to share between multiple consumers
    /// 
    /// Safe to use for as little or as long as needed, as it internally shares a single default <see cref="HttpClient"/> instance
    /// </summary>
    public class SingleHttpClient : HttpClientBase, ISharedHttpClient
    {
        private static readonly Lazy<HttpClient> Instance = new Lazy<HttpClient>(() => new HttpClient());

        /// <summary>
        /// Creates an instance of <see cref="SingleHttpClient"/> using <see cref="Instance"/>"/>
        /// </summary>
        public SingleHttpClient()
            : base(Instance.Value)
        {
        }
    }
}
