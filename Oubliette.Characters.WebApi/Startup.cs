using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oubliette.Characters.Core.Database;
using Oubliette.Characters.Core.Repositories;
using Oubliette.Characters.Core.Repositories.Interfaces;
using Oubliette.Characters.WebApi.Profiles;
using System.Reflection;

namespace Oubliette.Characters.WebApi
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
            services
                .AddControllers();

            services.AddAutoMapper(opts =>
            {
                opts.AddProfile<CharacterProfile>();
            });

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddDbContext<OublietteCharacterContext>(opts =>
            {

            });

            services.AddSingleton<IOublietteCharacterRepository, OublietteCharacterRepository>();
            services.AddTransient<OublietteCharacterContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
