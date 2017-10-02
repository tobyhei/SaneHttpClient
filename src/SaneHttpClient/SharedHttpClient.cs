using System.Net.Http;
using SaneHttpClient.Abstractions;

namespace SaneHttpClient
{
    /// <summary>
    /// Implementation of <see cref="ISharedHttpClient"/> which does not expose it's internal <see cref="HttpClient"/>
    /// or any of it's stateful methods making it safe to share between multiple consumers
    /// 
    /// Safe to use for as little or as long as needed, as it internally reuses <see cref="HttpClient"/> instances
    /// </summary>
    public class SharedHttpClient : HttpClientBase, ISharedHttpClient
    {
        /// <summary>
        /// Creates an instance of <see cref="UniqueHttpClient"/> using <see cref="DefaultPool"/>"/>
        /// </summary>
        public SharedHttpClient()
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="UniqueHttpClient"/> using the provided <see cref="returnPool"/>
        /// </summary>
        /// <param name="returnPool"></param>
        public SharedHttpClient(HttpClientPool returnPool) : base(returnPool)
        {
        }
    }
}
