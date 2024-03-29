using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Application.Factory;
using Application.Services;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace WebAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDbConnection(this IServiceCollection services, string connString){
        var contextOptions = new DbContextOptionsBuilder<Context>()
            .UseNpgsql(Environment.GetEnvironmentVariable(connString) ?? string.Empty)
            .Options;

        services.AddTransient(_ => new Context(contextOptions));
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