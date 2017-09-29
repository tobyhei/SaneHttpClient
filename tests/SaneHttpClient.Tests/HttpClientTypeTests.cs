using SaneHttpClient.Abstractions;
using System;
using System.Net.Http;
using Xunit;

namespace SaneHttpClient.Tests
{
    public class HttpClientTypeTests
    {
        [Fact]
        public void UniqueHttpClient_DoesNotImplement_ISharedHttpClient()
        {
            Assert.False(typeof(ISharedHttpClient).IsAssignableFrom(typeof(UniqueHttpClient)));
        }

        [Fact]
        public void UniqueHttpClient_DoesNotImplement_SharedHttpClient()
        {
            Assert.False(typeof(SharedHttpClient).IsAssignableFrom(typeof(UniqueHttpClient)));
        }

        [Fact]
        public void SharedHttpClient_DoesNotImplement_IUniqueHttpClient()
        {
            Assert.False(typeof(IUniqueHttpClient).IsAssignableFrom(typeof(SharedHttpClient)));
        }

        [Fact]
        public void UniqueHttpClient_DoesNotImplement_UniqueHttpClientt()
        {
            Assert.False(typeof(UniqueHttpClient).IsAssignableFrom(typeof(SharedHttpClient)));
        }

        [Fact]
        public void UniqueHttpClient_Implements_HttpClient()
        {
            Assert.True(typeof(HttpClient).IsAssignableFrom(typeof(UniqueHttpClient)));
        }

        [Fact]
        public void SharedHttpClient_DoesNotImplement_HttpClient()
        {
            Assert.False(typeof(HttpClient).IsAssignableFrom(typeof(SharedHttpClient)));
        }

        [Fact]
        public void UniqueHttpClient_Implements_IDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(UniqueHttpClient)));
        }

        [Fact]
        public void SharedHttpClient_Implements_IDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(SharedHttpClient)));
        }

        [Fact]
        public void IUniqueHttpClient_DoesNotImplement_IDisposable()
        {
            Assert.False(typeof(IDisposable).IsAssignableFrom(typeof(IUniqueHttpClient)));
        }

        [Fact]
        public void ISharedHttpClient_DoesNotImplement_IDisposable()
        {
            Assert.False(typeof(IDisposable).IsAssignableFrom(typeof(ISharedHttpClient)));
        }
    }
}
