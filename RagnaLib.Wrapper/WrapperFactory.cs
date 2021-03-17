using System;
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
    }
}