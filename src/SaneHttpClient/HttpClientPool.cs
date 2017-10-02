using SaneHttpClient.Extensions;
using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SaneHttpClient.Tests")]

namespace SaneHttpClient
{
    /// <summary>
    /// Pools instances of <see cref="HttpClient"/>
    /// 
    /// Should be consumed as a singleton/long living object
    /// </summary>
    public class HttpClientPool : IDisposable
    {
        private ConcurrentBag<HttpClient> pool = new ConcurrentBag<HttpClient>();
        private readonly Func<HttpClient> clientFactory;

        public HttpClientPool()
        {
            clientFactory = () => new HttpClient();
        }

        public HttpClientPool(HttpMessageHandler handler)
        {
            clientFactory = () => new HttpClient(handler);
        }

        public HttpClientPool(HttpMessageHandler handler, bool disposeHandler)
        {
            clientFactory = () => new HttpClient(handler, disposeHandler);
        }

        internal HttpClient Get()
        {
            if (pool == null) throw new ObjectDisposedException(nameof(HttpClientPool));

            return pool.TryTake(out var result) ? result : clientFactory();
        }

        internal void Return(HttpClient innerClient)
        {
            if (pool == null)
            {
                innerClient.Dispose();
                return;
            }

            // set defaults before returning to pool
            innerClient.Clear();    //TODO ensure clearing a disposed innerClient throws
            pool.Add(innerClient);
        }

        public int Count => pool.Count;

        public void Dispose()
        {
            var finalPool = pool;
            pool = null;
            if (finalPool == null) return;
            foreach (var pooled in finalPool)
            {
                pooled.Dispose();
            }
        }
    }
}
