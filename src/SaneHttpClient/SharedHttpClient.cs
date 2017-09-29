using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SaneHttpClient.Abstractions;

namespace SaneHttpClient
{
    /// <summary>
    /// Implementation of <see cref="ISharedHttpClient"/> which does not expose it's internal <see cref="HttpClient"/>
    /// or any of it's stateful methods making it safe to share between multiple consumers
    /// </summary>
    public class SharedHttpClient : ISharedHttpClient, IDisposable
    {
        private readonly HttpClient inner;

        public SharedHttpClient()
        {
            inner = new HttpClient();
        }

        public SharedHttpClient(HttpMessageHandler handler)
        {
            inner = new HttpClient(handler);
        }

        public SharedHttpClient(HttpMessageHandler handler, bool disposeHandler)
        {
            inner = new HttpClient(handler, disposeHandler);
        }

        public void Dispose() => inner.Dispose();

        public Task<string> GetStringAsync(string requestUri)
            => inner.GetStringAsync(requestUri);
        public Task<string> GetStringAsync(Uri requestUri)
            => inner.GetStringAsync(requestUri);

        public Task<byte[]> GetByteArrayAsync(string requestUri)
            => inner.GetByteArrayAsync(requestUri);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri)
            => inner.GetByteArrayAsync(requestUri);

        public Task<Stream> GetStreamAsync(string requestUri)
            => inner.GetStreamAsync(requestUri);
        public Task<Stream> GetStreamAsync(Uri requestUri)
            => inner.GetStreamAsync(requestUri);

        public Task<HttpResponseMessage> GetAsync(string requestUri)
            => inner.GetAsync(requestUri);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
            => inner.GetAsync(requestUri);
        public Task<HttpResponseMessage> GetAsync(
            string requestUri, HttpCompletionOption completionOption)
             => inner.GetAsync(requestUri, completionOption);
        public Task<HttpResponseMessage> GetAsync(
            Uri requestUri, HttpCompletionOption completionOption)
            => inner.GetAsync(requestUri, completionOption);

        public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
            => inner.GetAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
            => inner.GetAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(
            string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => inner.GetAsync(requestUri, completionOption, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(
            Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => inner.GetAsync(requestUri, completionOption, cancellationToken);

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
            => inner.PostAsync(requestUri, content);
        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
            => inner.PostAsync(requestUri, content);
        public Task<HttpResponseMessage> PostAsync(
            string requestUri, HttpContent content, CancellationToken cancellationToken)
            => inner.PostAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> PostAsync(
            Uri requestUri, HttpContent content, CancellationToken cancellationToken)
            => inner.PostAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
            => inner.PutAsync(requestUri, content);
        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
            => inner.PutAsync(requestUri, content);
        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
            => inner.PutAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
            => inner.PutAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> DeleteAsync(string requestUri)
            => inner.DeleteAsync(requestUri);
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
            => inner.DeleteAsync(requestUri);
        public Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
            => inner.DeleteAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
            => inner.DeleteAsync(requestUri, cancellationToken);

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
            => inner.SendAsync(request);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, HttpCompletionOption completionOption)
            => inner.SendAsync(request, completionOption);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
            => inner.SendAsync(request, cancellationToken);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => inner.SendAsync(request, completionOption, cancellationToken);
    }
}
