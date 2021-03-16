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
                MapCleanUrl = $"https://www.divine-pride.net/img/map/raw/{csvModel.IdMap}"
            };
        }
    }
}