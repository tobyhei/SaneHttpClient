using SaneHttpClient;
using SaneHttpClient.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleWebApp.Controllers;
using SampleWebApp.Models;

namespace SampleWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<ISharedHttpClient, DefaultHttpClient>();
            services.AddTransient<IHttpClientBuilder>(s => new HttpClientBuilder());
            services.AddTransient<IUniqueHttpClient>(s => s.GetRequiredService<IHttpClientBuilder>().Build());
            services.AddSingleton<VisitorCounter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
