using System.Net.Http;
using SaneHttpClient.Abstractions;

namespace SaneHttpClient
{
    /// <summary>
    /// Implementation of <see cref="ISharedHttpClient"/> which does not expose it's internal <see cref="HttpClient"/>
    /// or any of it's stateful methods making it safe to share between multiple consumers
    /// 
    /// It creates a default HttpClient per instance so instances should be reused, safe to use as a singleton
    /// </summary>
    public class DefaultHttpClient : HttpClientBase, ISharedHttpClient
    {
        /// <summary>
        /// Creates an instance of <see cref="SingleHttpClient"/>
        /// </summary>
        public DefaultHttpClient()
            : base(new HttpClient())
        {
        }
    }
}