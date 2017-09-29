using System.Threading.Tasks;
using Xunit;

namespace SaneHttpClient.Tests
{
    public class SharedHttpClientTests
    {
        [Fact]
        public async Task SharedHttpClient_Get_ReturnsExpected()
        {
            var client = new SharedHttpClient();

            var result = await client.GetAsync("https://google.com.au");

            result.EnsureSuccessStatusCode();
        }
    }
}
