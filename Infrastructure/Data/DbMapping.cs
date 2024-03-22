using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data.Mappings;

namespace Infrastructure.Data;

public static class DbMapping
{
    public static void SetMapping(this ModelBuilder builder)
    {
        builder.Entity<Element>().MappingElement();
        builder.Entity<Item>().MappingItem();
        builder.Entity<ItemType>().MappingItemType();
        builder.Entity<Location>().MappingLocation();
        builder.Entity<Monster>().MappingMonster();
        builder.Entity<MonsterItemMap>().MappingMonsterItemMap();
        builder.Entity<MonsterPerLocationMap>().MappingMonsterPerLocationMap();
        builder.Entity<SubType>().MappingSubType();
        builder.Entity<EquipPosition>().MappingEquipPosition();
        builder.Entity<ItemEquipPositionMap>().MappingItemEquipPositionMap();
    }
        
}