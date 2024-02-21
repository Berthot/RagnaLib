using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RagnaLib.Domain.Dto;
using RagnaLib.Domain.Dto.Monster;
using RagnaLib.Domain.Entities;
using RagnaLib.Domain.ValueObjects;

namespace RagnaLib.API.AutoMapper;

public class AutoMapperMonster : Profile
{
    public AutoMapperMonster()
    {
        CreateMap<Element, ElementDto>()
            .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => Captalize(src.Name)));
        CreateMap<Experience, ExperienceDto>()
            .ForMember(dest => dest.Mvp, opt =>
                opt.MapFrom(x => x.Job - x.Job));
        CreateMap<PrimaryAttribute, PrimaryStatsDto>();
        CreateMap<SecondaryAttribute, SecondaryStatsDto>();
        CreateMap<MonsterMvpDropMap, MonsterDropsDto>()
            .ForMember(dest => dest.ImageUrl, opt =>
                opt.MapFrom(src => src.Item.ImageUrl))
            .ForMember(dest => dest.SmallImageUrl, opt =>
                opt.MapFrom(src => src.Item.SmallImageUrl))
            .ForMember(dest => dest.CardImageUrl, opt =>
                opt.MapFrom(src => src.Item.CardImageUrl))
            .ForMember(dest => dest.ItemType, opt =>
                opt.MapFrom(src => src.Item.ItemType.Name))
            .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => src.Item.Name));


        CreateMap<MonsterItemMap, MonsterDropsDto>()
            .ForMember(dest => dest.ImageUrl, opt =>
                opt.MapFrom(src => src.Item.ImageUrl))
            .ForMember(dest => dest.SmallImageUrl, opt =>
                opt.MapFrom(src => src.Item.SmallImageUrl))
            .ForMember(dest => dest.CardImageUrl, opt =>
                opt.MapFrom(src => src.Item.CardImageUrl))
            .ForMember(dest => dest.ItemType, opt =>
                opt.MapFrom(src => src.Item.ItemType.Name))
            .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => src.Item.Name));
        CreateMap<MonsterPerLocationMap, MonsterLocationsDto>()
            .ForMember(dest => dest.Type, opt =>
                opt.MapFrom(src => src.Location.Type))
            .ForMember(dest => dest.LocationName, opt =>
                opt.MapFrom(src => src.Location.Name))
            .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => src.Location.NameId))
            .ForMember(dest => dest.MapUrl, opt =>
                opt.MapFrom(src => src.Location.MapUrl))
            .ForMember(dest => dest.MapCleanUrl, opt =>
                opt.MapFrom(src => src.Location.MapCleanUrl));

        CreateMap<Monster, MonsterDto>()
            .ForMember(dest => dest.PhysicalAttack, opt =>
                opt.MapFrom(src =>
                    $"{src.PhysicalAttack.MinimalDamage.ToString()}-{src.PhysicalAttack.MaximumDamage.ToString()}"))
            .ForMember(dest => dest.MagicAttack, opt =>
                opt.MapFrom(src =>
                    $"{src.MagicAttack.MinimalDamage.ToString()}-{src.MagicAttack.MaximumDamage.ToString()}"))
            .ForMember(dest => dest.PhysicalDefense, opt =>
                opt.MapFrom(src => src.Defense.PhysicalDefense))
            .ForMember(dest => dest.MagicDefense, opt =>
                opt.MapFrom(src => src.Defense.MagicDefense))
            .ForMember(dest => dest.Race, opt =>
                opt.MapFrom(src => Captalize(src.Race.Name)))
            .ForMember(dest => dest.Scale, opt =>
                opt.MapFrom(src => src.Scale.Name))
            .ForMember(dest => dest.Element, opt =>
                opt.MapFrom(src => src.Element))
            .ForMember(dest => dest.Experience, opt =>
                opt.MapFrom(src => src.Experience))
            .ForMember(dest => dest.Locations, opt =>
                opt.MapFrom(src => src.MonsterPerLocationMaps))
            .ForMember(dest => dest.MonsterDrops, opt =>
                opt.MapFrom(src => src.MonsterItemMaps))
            .ForMember(dest => dest.MonsterMvpDrops, opt =>
                opt.MapFrom(src => src.MonsterMvpDropMaps))
            .ForMember(dest => dest.PrimaryStats, opt =>
                opt.MapFrom(src => src.PrimaryAttribute))
            .ForMember(dest => dest.SecondaryStats, opt =>
                opt.MapFrom(src => src.SecondaryAttribute))
            .ForMember(dest => dest.Size, opt =>
                opt.MapFrom(src => GetSizeName(src.Size)))
            ;
    }

    private static string Captalize(string text)
    {
        return $"{text[..1].ToUpper()}{text[1..]}";
    }

    private static string GetSizeName(int value)
    {
        try
        {
            var sizes = new List<string>() {"Small", "Medium", "Large"};
            return sizes[value];
        }
        catch (Exception)
        {
            return "ERROR";
        }
    }
}