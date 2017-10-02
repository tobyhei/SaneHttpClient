using System;
using System.Net.Http;
using Xunit;

namespace SaneHttpClient.Tests
{
    public class HttpClientPoolTests
    {
        [Fact]
        public void HttpClientPool_GetConsecutively_ReturnsDefaultSettings()
        {
            // Arrange
            var pool = new HttpClientPool();
            var uri = new Uri("http://notadefaultaddress.com");
            var bufferSize = 1234;
            var timeSpan = TimeSpan.FromSeconds(33);

            // Act
            var firstClient = pool.Get();
            firstClient.BaseAddress = uri;
            firstClient.MaxResponseContentBufferSize = bufferSize;
            firstClient.Timeout = timeSpan;
            firstClient.DefaultRequestHeaders.Clear();
            pool.Return(firstClient);
            var secondClient = pool.Get();

            // Assert
            Assert.Equal(0, pool.Count);
            Assert.Same(firstClient, secondClient);
            AssertDefault(secondClient);
            pool.Return(secondClient);
            Assert.Equal(1, pool.Count);
        }

        [Fact]
        public void HttpClientPool_GetConcurrently_ReturnsDifferentDefaultClient()
        {
            // Arrange
            var pool = new HttpClientPool();

            // Act
            using (var firstClient = pool.Get())
            using (var secondClient = pool.Get())
            {
                // Assert
                Assert.NotSame(firstClient, secondClient);
                AssertDefault(firstClient);
                AssertDefault(secondClient);
            }
        }

        private void AssertDefault(HttpClient actualClient)
        {
            var defaultClient = new HttpClient();
            Assert.Equal(defaultClient.Timeout, actualClient.Timeout);
            Assert.Equal(defaultClient.BaseAddress, actualClient.BaseAddress);
            Assert.Equal(defaultClient.MaxResponseContentBufferSize, actualClient.MaxResponseContentBufferSize);
            Assert.Equal(defaultClient.DefaultRequestHeaders, actualClient.DefaultRequestHeaders);
        }
    }
}
