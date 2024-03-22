using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.AutoMapper;

namespace WebAPI.Extensions;

public static class AutoMapperExtensions
{
    public static void AddAutoMapper(this IServiceCollection services){
            
        var autoMapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AllowNullCollections = true;
            cfg.AddProfile(new AutoMapperMonster());
        });

        var mapper = autoMapperConfig.CreateMapper();
            
        services.AddSingleton(mapper);
    }
}