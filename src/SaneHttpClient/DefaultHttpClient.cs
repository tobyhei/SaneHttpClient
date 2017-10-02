using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SaneHttpClient.Abstractions;

namespace SaneHttpClient
{
    /// <summary>
    /// Implementation of <see cref="ISharedHttpClient"/> which does not expose it's internal <see cref="httpClient"/>
    /// or any of it's stateful methods making it safe to share between multiple consumers
    /// 
    /// Safe to use for as little or as long as needed, as it internally reuses a single default <see cref="httpClient"/> instance
    /// </summary>
    public class DefaultHttpClient : ISharedHttpClient
    {
        private static readonly Lazy<HttpClient> Instance = new Lazy<HttpClient>(() => new HttpClient());
        private readonly HttpClient httpClient;

        /// <summary>
        /// Creates an instance of <see cref="DefaultHttpClient"/> using <see cref="Instance"/>"/>
        /// </summary>
        public DefaultHttpClient()
        {
            httpClient = Instance.Value;
        }

        public Task<string> GetStringAsync(string requestUri)
            => httpClient.GetStringAsync(requestUri);
        public Task<string> GetStringAsync(Uri requestUri)
            => httpClient.GetStringAsync(requestUri);

        public Task<byte[]> GetByteArrayAsync(string requestUri)
            => httpClient.GetByteArrayAsync(requestUri);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri)
            => httpClient.GetByteArrayAsync(requestUri);

        public Task<Stream> GetStreamAsync(string requestUri)
            => httpClient.GetStreamAsync(requestUri);
        public Task<Stream> GetStreamAsync(Uri requestUri)
            => httpClient.GetStreamAsync(requestUri);

        public Task<HttpResponseMessage> GetAsync(string requestUri)
            => httpClient.GetAsync(requestUri);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
            => httpClient.GetAsync(requestUri);
        public Task<HttpResponseMessage> GetAsync(
            string requestUri, HttpCompletionOption completionOption)
             => httpClient.GetAsync(requestUri, completionOption);
        public Task<HttpResponseMessage> GetAsync(
            Uri requestUri, HttpCompletionOption completionOption)
            => httpClient.GetAsync(requestUri, completionOption);

        public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
            => httpClient.GetAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
            => httpClient.GetAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(
            string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => httpClient.GetAsync(requestUri, completionOption, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(
            Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => httpClient.GetAsync(requestUri, completionOption, cancellationToken);

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
            => httpClient.PostAsync(requestUri, content);
        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
            => httpClient.PostAsync(requestUri, content);
        public Task<HttpResponseMessage> PostAsync(
            string requestUri, HttpContent content, CancellationToken cancellationToken)
            => httpClient.PostAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> PostAsync(
            Uri requestUri, HttpContent content, CancellationToken cancellationToken)
            => httpClient.PostAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
            => httpClient.PutAsync(requestUri, content);
        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
            => httpClient.PutAsync(requestUri, content);
        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
            => httpClient.PutAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
            => httpClient.PutAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> DeleteAsync(string requestUri)
            => httpClient.DeleteAsync(requestUri);
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
            => httpClient.DeleteAsync(requestUri);
        public Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
            => httpClient.DeleteAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
            => httpClient.DeleteAsync(requestUri, cancellationToken);

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
            => httpClient.SendAsync(request);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, HttpCompletionOption completionOption)
            => httpClient.SendAsync(request, completionOption);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
            => httpClient.SendAsync(request, cancellationToken);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => httpClient.SendAsync(request, completionOption, cancellationToken);
    }
}
