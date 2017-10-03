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
    }
}
