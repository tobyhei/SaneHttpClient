using System;
using System.Net.Http;
using System.Net.Http.Headers;
using SaneHttpClient.Abstractions;

namespace SaneHttpClient
{
    /// <summary>
    /// Implementation of <see cref="IUniqueHttpClient"/> which does not expose it's internal <see cref="HttpClient"/>
    /// 
    /// Throws NullReferenceExceptions if used after disposed
    /// 
    /// Safe to use for as little or as long as needed, as it internally reuses <see cref="HttpClient"/> instances
    /// </summary>
    public class UniqueHttpClient : HttpClientBase, IUniqueHttpClient
    {
        /// <summary>
        /// Creates an instance of <see cref="UniqueHttpClient"/> using the <see cref="DefaultPool"/>
        /// </summary>
        public UniqueHttpClient()
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="UniqueHttpClient"/> using the provided <see cref="returnPool"/>
        /// </summary>
        /// <param name="returnPool"></param>
        public UniqueHttpClient(HttpClientPool returnPool) : base(returnPool)
        {
        }

        public Uri BaseAddress
        {
            get { return Inner.BaseAddress; }
            set { Inner.BaseAddress = value; }
        }

        public HttpRequestHeaders DefaultRequestHeaders => Inner.DefaultRequestHeaders;

        public long MaxResponseContentBufferSize
        {
            get { return Inner.MaxResponseContentBufferSize; }
            set { Inner.MaxResponseContentBufferSize = value; }
        }

        public TimeSpan Timeout
        {
            get { return Inner.Timeout; }
            set { Inner.Timeout = value; }
        }
    }
}
