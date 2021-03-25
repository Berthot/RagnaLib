using System;
using System.Collections.Generic;
using System.Linq;
using RagnaLib.Domain.Entities;
using RagnaLib.Domain.ValueObjects;
using RagnaLib.Wrapper.CsvWrapper.CsvModels;
using RagnaLib.Wrapper.ModelsAPI;
using Attack = RagnaLib.Domain.ValueObjects.Attack;
using Element = RagnaLib.Domain.Entities.Element;
using Item = RagnaLib.Domain.Entities.Item;

namespace RagnaLib.Wrapper
{
    public class WrapperFactory
    {
        
        
        public Location GetLocationEntity(LocationCsv csvModel)
        {
            return new Location()
            {
                NameId = csvModel.IdMap,
                Name = csvModel.DescName,
                MapUrl = $"https://www.divine-pride.net/img/map/original/{csvModel.IdMap}",
                MapCleanUrl = $"https://www.divine-pride.net/img/map/raw/{csvModel.IdMap}",
                Type = csvModel.TypeMap
            };
        }

        public Element GetElementEntity(ElementCsv csv)
        {
            return new Element()
            {
                Name = csv.Name.ToLower(),
                Tier = csv.Tier,
                Neutral = csv.Neutral,
                Water = csv.Water,
                Earth = csv.Earth,
                Fire = csv.Fire,
                Wind = csv.Wind,
                Poison = csv.Poison,
                Holy = csv.Holy,
                Dark = csv.Dark,
                Ghost = csv.Ghost,
                Undead = csv.Undead,
            };
        }

        public Item GetItemModel(RpItemCsv itemCsv)
        {
            return new Item()
            {
                Id = int.Parse(itemCsv.Id),
                Name = itemCsv.Name,
                Price = itemCsv.Price,
                SmallImageUrl = $"https://static.ragnaplace.com/bro/item/{itemCsv.Id}.png",
                ImageUrl = $"https://static.ragnaplace.com/bro/collection/{itemCsv.Id}.png",
                CardImageUrl = $"https://static.ragnaplace.com/bro/card/{itemCsv.Id}.png",
                Description = itemCsv.Description,
                // ItemTypeId = "", // set obj
                // SubTypeId = "", // set obj
                ItemEquipPositionMaps = new List<ItemEquipPositionMap>(), // set rule
                Refinable = TrueOrFalse(itemCsv.Refinable),
                Attack = StringToInteger(itemCsv.Attack),
                MagicAttack = StringToInteger(itemCsv.MagicAttack),
                RequiredLevel = StringToInteger(itemCsv.RequiredLevel),
                LimitLevel = StringToInteger(itemCsv.LimitLevel),
                ItemLevel = StringToInteger(itemCsv.ItemLevel),
                Weight = StringToFloat(itemCsv.Weight),
                Defense = StringToInteger(itemCsv.Defense),
                Slots = StringToInteger(itemCsv.Slots),
                UnidName = itemCsv.UnidName,
                CardPrefix = itemCsv.CardPrefix,

            };
        }
        
        

        private float StringToFloat(string str)
        {
            try
            {
                return string.IsNullOrEmpty(str) ? 0 : float.Parse(str);
            }
            catch (Exception e)
            {
                return float.Parse("0");
            }
        }

        public int StringToInteger(string str)
        {
            try
            {
                return string.IsNullOrEmpty(str) ? 0 : int.Parse(str);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private bool TrueOrFalse(string text)
        {
            if (text.ToLower() == "true")
                return true;
            if (text.ToLower() == "false" || string.IsNullOrEmpty(text))
                return false;
            return false;
        }
        
        public RpMonsterCsv GetMonsterRpCsv(RagnarokPrideMonster monster)
        {
        return new RpMonsterCsv()
        {
        Id = monster.id,
        DbName = monster.dbname,
        Name = monster.name,
        AttackRange = monster.stats.attackRange,
        Level = monster.stats.level,
        Hp = monster.stats.health,
        Sp = monster.stats.sp,
        Str = monster.stats.str,
        IntStatus = monster.stats.@int,
        Vit = monster.stats.vit,
        Dex = monster.stats.dex,
        Agi = monster.stats.agi,
        Luk = monster.stats.luk,
        RechargeTime = monster.stats.rechargeTime,
        Atk1 = monster.stats.atk1,
        Atk2 = monster.stats.atk2,
        MinAtk = monster.stats.attack.minimum,
        MaxAtk = monster.stats.attack.maximum,
        MinAtkm = monster.stats.magicAttack.minimum,
        MaxAtkm = monster.stats.magicAttack.maximum,
        Defense = monster.stats.defense,
        BaseExperience = monster.stats.baseExperience,
        JobExperience = monster.stats.jobExperience,
        AggroRange = monster.stats.aggroRange,
        EscapeRange = monster.stats.escapeRange,
        MovementSpeed = (float) monster.stats.movementSpeed,
        AttackSpeed = (float) monster.stats.attackSpeed,
        AttackedSpeed = (float) monster.stats.attackedSpeed,
        ElementId = monster.stats.element,
        Scale = monster.stats.scale,
        Race = monster.stats.race,
        MagicDefense = monster.stats.magicDefense,
        Hit = monster.stats.hit,
        Flee = monster.stats.flee,
        Ai = monster.stats.ai,
        Mvp = monster.stats.mvp,
        Attr = monster.stats.attr,
        Slave = GetSlaves(monster),
        Metarmorphosis = GetMetarmorphosis(monster),
        Drop = GetDrop(monster),
        MvpDrop = GetMvpDrop(monster),
        Spawn = GetSpawnDrop(monster),
        };
        }

        private string GetSpawnDrop(RagnarokPrideMonster monster)
        {
                        
            if (monster.spawn.Count == 0)
                return "";
            
            // map;amount;respawnTime
            return monster.spawn
                .Aggregate("", (current, map) => 
                    $"{current}{map.mapname};{map.amount};{map.respawnTime}|"
                );
        }

        private string GetMvpDrop(RagnarokPrideMonster monster)
        {
            // itemID;chance;stealprotected;serverType
            
            if (monster.mvpdrops.Count == 0)
                return "";

            return monster.mvpdrops.Aggregate("", (current, drop) =>
                $"{current}{drop.itemId};{drop.chance};{drop.stealProtected}|");
        }

        private string GetDrop(RagnarokPrideMonster monster)
        {
            
            if (monster.drops.Count == 0)
                return "";
            
            var text = "";
            // itemID;chance;stealprotected;serverType
            foreach (var drop in monster.drops)
            {
                if(drop.serverTypeName.ToLower() != "Renewal".ToLower())
                    continue;
                text += 
                    $"{drop.itemId};{drop.chance};{drop.stealProtected}|";
            }

            return text;
        }

        private string GetMetarmorphosis(RagnarokPrideMonster monster)
        {
            //id;amount
            if (monster.metamorphosis.Count == 0)
                return "";

            return monster.metamorphosis
                .Aggregate("", (current, metamorph) => 
                    $"{current}{metamorph.id};{metamorph.amount}|"
                );
        }

        private string GetSlaves(RagnarokPrideMonster monster)
        {
            //id;idx;amount;
            if (monster.slaves.Count == 0)
                return "";

            return monster.slaves
                .Aggregate("", (current, slave) => 
                    $"{current}{slave.id};{slave.idx};{slave.amount}|"
                );
        }

        public Monster GetMonsterEntity(RpMonsterCsv csv)
        {
            return new Monster()
            {
                Id = csv.Id,
                Name = csv.Name,
                DbName = csv.DbName,
                Level = csv.Level,
                Health = csv.Hp,
                Size = csv.Scale,
                GifUrl = $"https://static.ragnaplace.com/db/npc/gif/{csv.Id}.gif",
                HasDrop = false,
                HasLocation = false,
                // RaceId = csv.IdRace,
                // ElementId = csv.IdElement,
                // ScaleId = csv.IdScale,
                IsMvp = csv.Mvp == 1,
                Defense = new Defense()
                {
                  MagicDefense  = csv.MagicDefense,
                  PhysicalDefense = csv.Defense
                },
                Experience = new Experience()
                {
                    Job  = csv.JobExperience,
                    Base = csv.BaseExperience
                },
                PhysicalAttack = new Attack() {
                    MinimalDamage = csv.MinAtk,
                    MaximumDamage = csv.MaxAtk,
                },
                MagicAttack = new Attack() {
                    MinimalDamage = csv.MinAtkm,
                    MaximumDamage = csv.MaxAtkm,
                },
                PrimaryAttribute = new PrimaryAttribute() {
                    Str = csv.Str,
                    Agi = csv.Agi,
                    Vit = csv.Vit,
                    Int = csv.IntStatus,
                    Dex = csv.Dex,
                    Luk = csv.Luk,
                },
                SecondaryAttribute = new SecondaryAttribute() {
                    Hp = csv.Hp,
                    Sp = csv.Sp,
                    Flee = csv.Flee,
                    Hit = csv.Hit,
                    AttackSpeed = csv.AttackSpeed,
                    AttackRange = csv.AttackRange
                },
            };
        }
    }
}
// "imgUrl": "https://static.ragnaplace.com/bro/item/4425.png",
// "collectionImgUrl": "https://static.ragnaplace.com/bro/collection/4425.png",
// "cardImgUrl": "https://static.ragnaplace.com/bro/card/4425.png",