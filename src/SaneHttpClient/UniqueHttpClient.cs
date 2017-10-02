using System.Net.Http;
using SaneHttpClient.Abstractions;

namespace SaneHttpClient
{
    /// <summary>
    /// Implementation of <see cref="IUniqueHttpClient"/> which does not expose it's internal <see cref="HttpClient"/>
    /// </summary>
    public class UniqueHttpClient : HttpClientBase, IUniqueHttpClient
    {
        public UniqueHttpClient(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public void Dispose() => HttpClient.Dispose();
    }
}
