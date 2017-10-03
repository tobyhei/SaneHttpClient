using System;
using System.Net.Http;
using System.Net.Http.Headers;
using SaneHttpClient.Abstractions;

namespace SaneHttpClient
{
    public class HttpClientBuilder : IHttpClientBuilder, IDisposable
    {
        private HttpClient httpClient;
        private readonly object lockObject = new object();

        public HttpClientBuilder()
        {
            httpClient = new HttpClient();
        }

        public HttpClientBuilder(HttpMessageHandler handler, bool disposeHandler = true)
        {
            httpClient = new HttpClient(handler, disposeHandler);
        }

        public void Dispose() => httpClient?.Dispose();

        public IUniqueHttpClient Build()
        {
            // lock just to ensure no one grabs more than one instance of UniqueHttpClient
            // with the same http client
            lock (lockObject)
            {
                var builtClient = httpClient;
                httpClient = null;
                return new UniqueHttpClient(builtClient);
            }
        }

        public HttpRequestHeaders DefaultRequestHeaders => httpClient.DefaultRequestHeaders;

        public TimeSpan Timeout
        {
            get { return httpClient.Timeout; }
            set { httpClient.Timeout = value; }
        }

        public long MaxResponseContentBufferSize
        {
            get { return httpClient.MaxResponseContentBufferSize; }
            set { httpClient.MaxResponseContentBufferSize = value; }
        }

        public Uri BaseAddress
        {
            get { return httpClient.BaseAddress; }
            set { httpClient.BaseAddress = value; }
        }

        public IHttpClientBuilder SetTimeout(TimeSpan timeout)
        {
            Timeout = timeout;
            return this;
        }

        public IHttpClientBuilder SetMaxResponseContentBufferSize(long maxResponseContentBufferSize)
        {
            MaxResponseContentBufferSize = maxResponseContentBufferSize;
            return this;
        }

        public IHttpClientBuilder SetBaseAddress(Uri baseAddress)
        {
            BaseAddress = baseAddress;
            return this;
        }
    }
}
