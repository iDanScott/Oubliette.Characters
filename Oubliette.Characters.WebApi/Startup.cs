using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Oubliette.Characters.Shared.Database;
using Oubliette.Characters.Shared.Repositories;
using Oubliette.Characters.Shared.Repositories.Interfaces;
using Oubliette.Characters.WebApi.Profiles;

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
