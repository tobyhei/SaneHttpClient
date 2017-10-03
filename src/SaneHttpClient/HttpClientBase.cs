using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SaneHttpClient
{
    /// <summary>
    /// Base functionality shared by <see cref="SingleHttpClient"/>> and <see cref="UniqueHttpClient"/>
    /// which does not expose it's internal <see cref="System.Net.Http.HttpClient"/> or any of it's stateful methods
    /// 
    /// Not intended to be used externally, just for code reuse within the library
    /// </summary>
    public abstract class HttpClientBase
    {
        protected readonly HttpClient HttpClient;

        protected HttpClientBase(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public Task<string> GetStringAsync(string requestUri)
            => HttpClient.GetStringAsync(requestUri);
        public Task<string> GetStringAsync(Uri requestUri)
            => HttpClient.GetStringAsync(requestUri);

        public Task<byte[]> GetByteArrayAsync(string requestUri)
            => HttpClient.GetByteArrayAsync(requestUri);
        public Task<byte[]> GetByteArrayAsync(Uri requestUri)
            => HttpClient.GetByteArrayAsync(requestUri);

        public Task<Stream> GetStreamAsync(string requestUri)
            => HttpClient.GetStreamAsync(requestUri);
        public Task<Stream> GetStreamAsync(Uri requestUri)
            => HttpClient.GetStreamAsync(requestUri);

        public Task<HttpResponseMessage> GetAsync(string requestUri)
            => HttpClient.GetAsync(requestUri);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
            => HttpClient.GetAsync(requestUri);
        public Task<HttpResponseMessage> GetAsync(
            string requestUri, HttpCompletionOption completionOption)
             => HttpClient.GetAsync(requestUri, completionOption);
        public Task<HttpResponseMessage> GetAsync(
            Uri requestUri, HttpCompletionOption completionOption)
            => HttpClient.GetAsync(requestUri, completionOption);

        public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
            => HttpClient.GetAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
            => HttpClient.GetAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(
            string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => HttpClient.GetAsync(requestUri, completionOption, cancellationToken);
        public Task<HttpResponseMessage> GetAsync(
            Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => HttpClient.GetAsync(requestUri, completionOption, cancellationToken);

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
            => HttpClient.PostAsync(requestUri, content);
        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
            => HttpClient.PostAsync(requestUri, content);
        public Task<HttpResponseMessage> PostAsync(
            string requestUri, HttpContent content, CancellationToken cancellationToken)
            => HttpClient.PostAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> PostAsync(
            Uri requestUri, HttpContent content, CancellationToken cancellationToken)
            => HttpClient.PostAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
            => HttpClient.PutAsync(requestUri, content);
        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
            => HttpClient.PutAsync(requestUri, content);
        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
            => HttpClient.PutAsync(requestUri, content, cancellationToken);
        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
            => HttpClient.PutAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> DeleteAsync(string requestUri)
            => HttpClient.DeleteAsync(requestUri);
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
            => HttpClient.DeleteAsync(requestUri);
        public Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
            => HttpClient.DeleteAsync(requestUri, cancellationToken);
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
            => HttpClient.DeleteAsync(requestUri, cancellationToken);

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
            => HttpClient.SendAsync(request);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, HttpCompletionOption completionOption)
            => HttpClient.SendAsync(request, completionOption);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
            => HttpClient.SendAsync(request, cancellationToken);
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
            => HttpClient.SendAsync(request, completionOption, cancellationToken);
    }
}
