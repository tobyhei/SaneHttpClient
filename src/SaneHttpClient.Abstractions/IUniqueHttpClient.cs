using System.Net.Http;

namespace SaneHttpClient.Abstractions
{
    /// <summary>
    /// Exposes all safe functionality of <see cref="HttpClient"/> with an interface specifying that it should only be used by one consumer
    /// and that it is not safe for sharing between multiple consumers.
    /// 
    /// Can be configured and built by <see cref="IUniqueHttpClientBuilder"/>>
    /// 
    /// <seealso cref="ISharedHttpClient"/>> should be preferred unless the stateful properties of <seealso cref="HttpClient"/> are required
    /// </summary>
    public interface IUniqueHttpClient : IHttpClient
    {
    }
}
