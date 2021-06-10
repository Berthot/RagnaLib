using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RagnaLib.Application.Factory;
using RagnaLib.Application.Services;
using RagnaLib.Domain.Repositories;
using RagnaLib.Domain.Services;
using RagnaLib.Infra.Data;
using RagnaLib.Infra.Repositories;

namespace RagnaLib.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbConnection(this IServiceCollection services, string connString){
            // services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddDbContext<Context>(options => 
                options.UseNpgsql(Environment.GetEnvironmentVariable(connString) ?? string.Empty)
            );
        }
        
        public static void AddRepositories(this IServiceCollection services){
            // services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddTransient<IMonsterRepository, MonsterRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
        }
        
        public static void AddServices(this IServiceCollection services){
            // services.AddScoped<IMessageService, MessageService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IMonsterService, MonsterService>();
        }
        
        public static void AddFactory(this IServiceCollection services){
            // services.AddScoped<IMessageFactory, MessageFactory>();
            services.AddTransient<MonsterFactory>();
            services.AddTransient<ItemFactory>();
        }
    }
}