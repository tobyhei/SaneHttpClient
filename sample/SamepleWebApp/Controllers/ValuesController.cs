using SaneHttpClient;
using SaneHttpClient.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUniqueHttpClient uniqueClient;
        private readonly ISharedHttpClient sharedClient;

        public ValuesController(IUniqueHttpClient uniqueClient, ISharedHttpClient sharedClient)
        {
            this.uniqueClient = uniqueClient;
            this.sharedClient = sharedClient;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var one = await uniqueClient.GetAsync("https://www.bing.com");
            var two = await sharedClient.GetAsync("https://www.google.com");
            return new string[] { await one.Content.ReadAsStringAsync(), await two.Content.ReadAsStringAsync() };
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
