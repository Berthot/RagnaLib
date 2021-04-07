using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RagnaLib.Application.Services;
using RagnaLib.Domain.Bases.Interfaces;
using RagnaLib.Domain.Repositories;
using RagnaLib.Domain.Services;
using RagnaLib.Infra.Data;
using RagnaLib.Infra.Repositories;

namespace RagnaLib.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "RagnaLibAPI", Version = "v1"});
            });
            services.AddDbContext<Context>(options => 
                options.UseNpgsql(Environment.GetEnvironmentVariable("HEROKU_RAG") ?? string.Empty)
                );
            
            services.AddTransient<IMonsterRepository, MonsterRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IMonsterService, MonsterService>();
            
            
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RagnaLib.API v1"));
            }
            // app.UseStaticFiles(); // imagens
            
            app.UseHttpsRedirection();

            app.UseRouting();
            
            
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthorization();
            // app.UseAuthentication();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}