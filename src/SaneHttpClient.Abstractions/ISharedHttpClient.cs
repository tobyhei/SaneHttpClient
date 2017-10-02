namespace SaneHttpClient.Abstractions
{
    /// <summary>
    /// Exposes a safe to share interface over <see cref="IHttpClient"/>
    /// </summary>
    public interface ISharedHttpClient : IHttpClient
    {
    }
}