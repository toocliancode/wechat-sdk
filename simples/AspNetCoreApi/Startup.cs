using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WeChat;
using WeChat.Mp.Request;
using WeChat.Request;

namespace AspNetCoreApi
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
            services.AddMediator();

            services.AddWeChat()
                .WithMp()
                .WithApplet()
                .WithPay()
                .Configure(configure =>
                {
                    configure.Configurations["WeChatPay"] = new WeChatConfiguration("WeChatPay").Configure("appid", "secret");
                })
                .Configure(Configuration.GetSection("WeChat"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IOptions<WeChatOptions> options)
        {
            var _options = options.Value;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var request = new WeChatMpJsapiConfigRequest("");
            request.Configure("1", "2");
            request.Configure("12", "233");

            var a = new WeChatTicketRequest();
                a.Configure("1", "22");
        }
    }
}
