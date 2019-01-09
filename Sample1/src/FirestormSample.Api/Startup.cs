using Firestorm.AspNetCore2;
using Firestorm.Endpoints;
using Firestorm.EntityFrameworkCore2;
using Firestorm.Stems;
using FirestormSample.Domain.Messages;
using FirestormSample.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FirestormSample.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SampleDbContext>(o => o.UseInMemoryDatabase("Sample"));

            services.AddSingleton<IMessagePublisher, ConsoleMessagePublisher>();

            services.AddFirestorm()
                .AddEndpoints(config => config.ResponseConfiguration.ShowDeveloperErrors = true)
                .AddStems()
                .AddEntityFramework<SampleDbContext>(o => o.EnsureCreatedOnRequest = true)
                ;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseFirestorm();
        }
    }
}