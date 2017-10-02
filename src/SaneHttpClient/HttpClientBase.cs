using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SaneHttpClient
{
    /// <summary>
    /// Base functionality shared by <see cref="SharedHttpClient"/>> and <see cref="UniqueHttpClient"/>
    /// which does not expose it's internal <see cref="HttpClient"/> or any of it's stateful methods
    /// 
    /// Not intended to be used externally, just for code reuse within the library
    /// </summary>
    public class HttpClientBase : IDisposable
    {
        protected static readonly Lazy<HttpClientPool> DefaultPool = new Lazy<HttpClientPool>(() => new HttpClientPool());
        protected HttpClient Inner;
        protected readonly HttpClientPool ReturnPool;
        protected bool Disposed;

        public HttpClientBase() : this(DefaultPool.Value)
        {
            Inner = new HttpClient();
        }

        /// <summary>
        /// Creates an instance of <see cref="UniqueHttpClient"/> using the provided <see cref="ReturnPool"/>
        /// </summary>
        /// <param name="returnPool"></param>
        public HttpClientBase(HttpClientPool returnPool)
        {
            this.Inner = returnPool.Get();
            this.ReturnPool = returnPool;
        }

        /// <summary>
        /// This returns the underlying HttpClient back to the pool, it does not dispose of it
        /// The pool takes responsibility for disposing of the underlying HttpClient
        /// </summary>
        public void Dispose()
        {
            //TODO should this be made thread safe?
            if (Disposed) return;
            Disposed = true;

            var final = Inner;
            Inner = null;

            ReturnPool.Return(final);
        }

        public Task<string> GetStringAsync(string requestUri)
            => Inner.GetStringAsync(requestUri);
        public Task<string> GetStringAsync(Uri requestUri)
            => Inner.GetStringAsync(requestUri);

        public Task<byte[]> GetByteArrayAsync(string requestUri)
            => Inner.GetByteArrayAsync(requestUri);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri)
            => Inner.GetByteArrayAsync(requestUri);

        public Task<Stream> GetStreamAsync(string requestUri)
            => Inner.GetStreamAsync(requestUri);
        public Task<Stream> GetStreamAsync(Uri requestUri)
            => Inner.GetStreamAsync(requestUri);

        public Task<HttpResponseMessage> GetAsync(string requestUri)
            => Inner.GetAsync(requestUri);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
            => Inner.GetAsync(requestUri);
        public Task<HttpResponseMessage> GetAsync(
            string requestUri, HttpCompletionOption completionOption)
             => Inner.GetAsync(requestUri, completionOption);
        public Task<HttpResponseMessage> GetAsync(
            Uri requestUri, HttpCompletionOption completionOption)
            => Inner.GetAsync(requestUri, completionOption);

        public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
            => Inner.GetAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
            => Inner.GetAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(
            string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => Inner.GetAsync(requestUri, completionOption, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(
            Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => Inner.GetAsync(requestUri, completionOption, cancellationToken);

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
            => Inner.PostAsync(requestUri, content);
        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
            => Inner.PostAsync(requestUri, content);
        public Task<HttpResponseMessage> PostAsync(
            string requestUri, HttpContent content, CancellationToken cancellationToken)
            => Inner.PostAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> PostAsync(
            Uri requestUri, HttpContent content, CancellationToken cancellationToken)
            => Inner.PostAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
            => Inner.PutAsync(requestUri, content);
        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
            => Inner.PutAsync(requestUri, content);
        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
            => Inner.PutAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
            => Inner.PutAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> DeleteAsync(string requestUri)
            => Inner.DeleteAsync(requestUri);
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
            => Inner.DeleteAsync(requestUri);
        public Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
            => Inner.DeleteAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
            => Inner.DeleteAsync(requestUri, cancellationToken);

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
            => Inner.SendAsync(request);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, HttpCompletionOption completionOption)
            => Inner.SendAsync(request, completionOption);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
            => Inner.SendAsync(request, cancellationToken);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => Inner.SendAsync(request, completionOption, cancellationToken);
    }
}
