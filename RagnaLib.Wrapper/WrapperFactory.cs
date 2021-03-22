using System;
using System.Collections.Generic;
using RagnaLib.Domain.Entities;
using RagnaLib.Wrapper.CsvWrapper.CsvModels;

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
    }
}
// "imgUrl": "https://static.ragnaplace.com/bro/item/4425.png",
// "collectionImgUrl": "https://static.ragnaplace.com/bro/collection/4425.png",
// "cardImgUrl": "https://static.ragnaplace.com/bro/card/4425.png",