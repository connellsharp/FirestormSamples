using Firestorm.AspNetCore2;
using Firestorm.Extensions.AspNetCore;
using FirestormSample.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FirestormSample.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SampleDbContext>(o => o.UseInMemoryDatabase("Sample"));
            
            services.AddFirestorm()
                .AddStems()
                .AddEntityFramework<SampleDbContext>(o => o.EnsureCreatedOnRequest = true)
                .ConfigureEndpoints(config => config.ResponseConfiguration.ShowDeveloperErrors = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFirestorm();
        }
    }
}