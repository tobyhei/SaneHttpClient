using System;
using System.Net.Http;

namespace SaneHttpClient.Extensions
{
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Resets all of the <see cref="HttpClient"/> state back to their default values
        /// </summary>
        /// <param name="client"></param>
        public static void Clear(this HttpClient client)
        {
            client.BaseAddress = null;
            client.DefaultRequestHeaders.Clear();
            client.MaxResponseContentBufferSize = 2147483647;
            client.Timeout = TimeSpan.FromSeconds(100);
        }
    }
}
