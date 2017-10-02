using System;
using System.Net.Http;
using System.Net.Http.Headers;
using SaneHttpClient.Abstractions;

namespace SaneHttpClient
{
    public class UniqueHttpClientBuilder : IUniqueHttpClientBuilder, IDisposable
    {
        private HttpClient httpClient;

        public UniqueHttpClientBuilder()
        {
            this.httpClient = new HttpClient();
        }

        public UniqueHttpClientBuilder(HttpMessageHandler handler, bool disposeHandler)
        {
            this.httpClient = new HttpClient(handler, disposeHandler);
        }

        public void Dispose() => httpClient?.Dispose();

        public IUniqueHttpClient Build()
        {
            var builtClient = httpClient;
            httpClient = null;
            return new UniqueHttpClient(builtClient);
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
    }
}
