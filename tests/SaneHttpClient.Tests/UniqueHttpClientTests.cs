using System;
using System.Threading.Tasks;
using Xunit;

namespace SaneHttpClient.Tests
{
    public class UniqueHttpClientTests
    {
        [Fact]
        public async Task UniqueHttpClient_Get_ReturnsExpected()
        {
            var client = new UniqueHttpClient();

            var result = await client.GetAsync("https://google.com.au");

            result.EnsureSuccessStatusCode();
        }

        [Fact]
        public void UniqueHttpClient_SetBaseAddress_ReturnsExpected()
        {
            var expectedUrl = new Uri("https://expected.address.com");

            var client = new UniqueHttpClient();

            client.BaseAddress = expectedUrl;

            var actualUrl = client.BaseAddress;

            Assert.Equal(expectedUrl, actualUrl);
        }

        [Fact]
        public void UniqueHttpClient_SetMaxResponseContentBufferSize_ReturnsExpected()
        {
            var expectedLength = 8192;

            var client = new UniqueHttpClient();

            client.MaxResponseContentBufferSize = expectedLength;

            var actualLength = client.MaxResponseContentBufferSize;

            Assert.Equal(expectedLength, actualLength);
        }

        [Fact]
        public void UniqueHttpClient_SetTimeout_ReturnsExpected()
        {
            var expectedTimeout = TimeSpan.FromSeconds(3);

            var client = new UniqueHttpClient();

            client.Timeout = expectedTimeout;

            var actualTimeout = client.Timeout;

            Assert.Equal(expectedTimeout, actualTimeout);
        }
    }
}
