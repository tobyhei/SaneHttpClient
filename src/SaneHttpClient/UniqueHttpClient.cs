using System.Net.Http;
using SaneHttpClient.Abstractions;

namespace SaneHttpClient
{
    /// <summary>
    /// An adapter for <see cref="HttpClient"/> so that it can inherit from <see cref="IUniqueHttpClient"/>
    /// 
    /// <seealso cref="SharedHttpClient"/>> should be preferred unless the stateful properties of <seealso cref="HttpClient"/> are required
    /// </summary>
    public class UniqueHttpClient : HttpClient, IUniqueHttpClient
    {
        public UniqueHttpClient()
        {
        }

        public UniqueHttpClient(HttpMessageHandler handler)
            : base(handler)
        {
        }

        public UniqueHttpClient(HttpMessageHandler handler, bool disposeHandler)
            : base(handler, disposeHandler)
        {
        }
    }
}