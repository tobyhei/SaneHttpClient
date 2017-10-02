using SaneHttpClient;
using SaneHttpClient.Abstractions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ISharedHttpClient sharedClient;
        private readonly IUniqueHttpClient uniqueHttpClient;

        public ValuesController(ISharedHttpClient sharedClient, IUniqueHttpClient uniqueHttpClient)
        {
            this.sharedClient = sharedClient;
            this.uniqueHttpClient = uniqueHttpClient;
        }

        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            var one = await sharedClient.GetAsync("https://www.google.com");
            var two = await uniqueHttpClient.GetAsync("https://bing.com.au");
            return  await one.Content.ReadAsStringAsync() + await two.Content.ReadAsStringAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
