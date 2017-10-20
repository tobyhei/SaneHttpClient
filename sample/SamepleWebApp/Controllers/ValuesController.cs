using System;
using System.Net.Http;
using SaneHttpClient.Abstractions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleWebApp.Models;

namespace SampleWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ISharedHttpClient sharedClient;
        private readonly IUniqueHttpClient uniqueHttpClient;
        private readonly IUniqueHttpClient configuredUniqueHttpClient;
        private readonly VisitorCounter visitorCounter;

        public ValuesController(ISharedHttpClient sharedClient, IUniqueHttpClient uniqueHttpClient, IHttpClientBuilder builder, VisitorCounter visitorCounter)
        {
            this.sharedClient = sharedClient;
            this.uniqueHttpClient = uniqueHttpClient;

            builder.SetBaseAddress(new Uri("https://api.duckduckgo.com"));
            builder.SetTimeout(TimeSpan.FromSeconds(10));
            this.configuredUniqueHttpClient = builder.Build();

            this.visitorCounter = visitorCounter;
        }

        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            var currentCount = visitorCounter.Increment();

            HttpResponseMessage message;
            switch (currentCount % 3)
            {
                case 0:
                    message = await sharedClient.GetAsync("https://api.duckduckgo.com/?q=f+sharp&format=json&pretty=1");
                    break;
                case 1:
                    message = await uniqueHttpClient.GetAsync("https://api.duckduckgo.com/?q=c+plus+plus&format=json&pretty=1");
                    break;
                default:
                    message = await configuredUniqueHttpClient.GetAsync("?q=c+sharp&format=json&pretty=1");
                    break;
            }

            return await message.Content.ReadAsStringAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
