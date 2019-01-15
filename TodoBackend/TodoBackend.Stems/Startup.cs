using Firestorm.AspNetCore2;
using Firestorm.Data;
using Firestorm.Endpoints;
using Firestorm.Endpoints.Strategies;
using Firestorm.Engine.Defaults;
using Firestorm.Stems;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace TodoBackend.Stems
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            
            services.AddFirestorm()
                .AddEndpoints(o =>
                {
                    o.CommandStrategies.ForCollections[UnsafeMethod.Delete] = new ClearCollectionStrategy();
                    o.Response.ShowDeveloperErrors = true;
                    o.Response.ResourceOnSuccessfulCommand = true;
                })
                .AddStems()
                .AddDataSource(new MemoryDataSource());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseFirestorm();
        }
    }
}