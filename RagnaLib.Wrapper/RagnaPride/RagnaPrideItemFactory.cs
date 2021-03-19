using System.Collections.Generic;
using RagnaLib.Wrapper.CsvWrapper.CsvModels;
using RagnaLib.Wrapper.ModelsAPI;

namespace RagnaLib.Wrapper.RagnaPride
{
    public class RagnaPrideItemFactory
    {
        public RpItemCsv GetMainItem(RagnaPrideItem item)
        {
            return new RpItemCsv()
            {
                Id = item.id.ToString(),
                Name = item.name,
                Price = item.price.ToString(),
                Description = item.description?.Replace("\n","@"),
                EquipLocation = item.location?.ToString(),
                Refinable = item.refinable.ToString(),
                RagnaPriceItemTypeId = item.itemTypeId.ToString(),
                RagnaPriceSubItemTypeId = item.itemSubTypeId.ToString(),
                Attack = item.attack.ToString(),
                MagicAttack = item.matk.ToString(),
                RequiredLevel = item.requiredLevel.ToString(),
                LimitLevel = item.limitLevel.ToString(),
                ItemLevel = item.itemLevel.ToString(),
                Weight = item.weight.ToString(),
                Defense = item.defense.ToString(),
                CardPrefix = item.cardPrefix?.ToString(),
                Slots = item.slots.ToString(),
                UnidName = item.unidName?.ToString(),
                ItemMoveInfo = GetItemMoveInfo(item),
                HasSet = HasSet(item),
                HasSoldBy = HasSoldBy(item),
                Range = item.range.ToString(),
                Indestructible = item.indestructible.ToString(),
                Attribute = item.attribute.ToString(),
                AegisName = item.aegisName?.ToString(),
                LocationId = item.locationId?.ToString(),
                Acessory = item.accessory?.ToString()
            };
        }

        private static string HasSoldBy(RagnaPrideItem item)
        {
            if (item.soldBy == null)
                return "false";
            return item.soldBy.Count == 0 ? "false" : "true";
        }

        private static string HasSet(RagnaPrideItem item)
        {
            if (item.sets == null)
                return "false";
            return item.sets.Count == 0 ? "false" : "true";
        }


        private string GetItemMoveInfo(RagnaPrideItem item)
        {
            var info = item.itemMoveInfo;
            if (info == null)
                return "";
            return $"{info.auction}|" +
                           $"{info.cart}|" +
                           $"{info.drop}|" +
                           $"{info.mail}|" +
                           $"{info.sell}|" +
                           $"{info.store}|" +
                           $"{info.trade}|" +
                           $"{info.guildStore}";
        }
    }
}