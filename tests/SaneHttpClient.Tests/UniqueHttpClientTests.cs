using System.Net.Http;
using SaneHttpClient;
using System.Threading.Tasks;
using Xunit;

namespace SaneHttpClient.Tests
{
    public class UniqueHttpClientTests
    {
        [Fact]
        public async Task UniqueHttpClient_Get_ReturnsExpected()
        {
            var client = new UniqueHttpClient(new HttpClient());

            var result = await client.GetAsync("https://google.com.au");

            result.EnsureSuccessStatusCode();
        }
    }
}
