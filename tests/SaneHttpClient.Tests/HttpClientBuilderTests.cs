using System;
using Xunit;

namespace SaneHttpClient.Tests
{
    public class HttpClientBuilderTests
    {
        [Fact]
        public void HttpClientBuilder_Builder_ReturnsExpectedClient()
        {
            // Arrange
            var testTimeout = TimeSpan.FromSeconds(3);
            var testUri = new Uri("http://google.com");
            var testBufferSize = 2 * 1024;

            // Act
            var builder = new HttpClientBuilder();
            builder.Timeout = testTimeout;
            builder.BaseAddress = testUri;
            builder.MaxResponseContentBufferSize = testBufferSize;
            //builder.DefaultRequestHeaders

            var client = builder.Build();

            // Assert
            Assert.Equal(testTimeout, client.Timeout);
            Assert.Equal(testUri, client.BaseAddress);
            Assert.Equal(testBufferSize, client.MaxResponseContentBufferSize);
            //builder.DefaultRequestHeaders
        }

        [Fact]
        public void HttpClientBuilder_FluentBuilder_ReturnsExpectedClient()
        {
            // Arrange
            var testTimeout = TimeSpan.FromSeconds(3);
            var testUri = new Uri("http://google.com");
            var testBufferSize = 2 * 1024;

            // Act
            var builder = new HttpClientBuilder()
                .SetTimeout(testTimeout)
                .SetBaseAddress(testUri)
                .SetMaxResponseContentBufferSize(testBufferSize);
            //builder.DefaultRequestHeaders

            var client = builder.Build();

            // Assert
            Assert.Equal(testTimeout, client.Timeout);
            Assert.Equal(testUri, client.BaseAddress);
            Assert.Equal(testBufferSize, client.MaxResponseContentBufferSize);
            //builder.DefaultRequestHeaders
        }
    }
}
