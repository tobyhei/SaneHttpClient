using System.Threading.Tasks;
using Xunit;

namespace SaneHttpClient.Tests
{
    public class SingleHttpClientTests
    {
        [Fact]
        public async Task SingleHttpClient_Get_ReturnsExpected()
        {
            var client = new SingleHttpClient();

            var result = await client.GetAsync("https://google.com.au");

            result.EnsureSuccessStatusCode();
        }
    }
}
