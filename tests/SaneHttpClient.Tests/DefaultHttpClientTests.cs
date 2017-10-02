using System.Threading.Tasks;
using Xunit;

namespace SaneHttpClient.Tests
{
    public class DefaultHttpClientTests
    {
        [Fact]
        public async Task DefaultHttpClient_Get_ReturnsExpected()
        {
            var client = new DefaultHttpClient();

            var result = await client.GetAsync("https://google.com.au");

            result.EnsureSuccessStatusCode();
        }
    }
}
