using System.Threading.Tasks;
using RagnaLib.Infra.Data;

namespace RagnaLib.Wrapper
{
    class Program
    {
        // private static ReadCsv _readCsv = new ReadCsv();
        private static readonly WrapperService Service = new WrapperService(new Context());

        public static async Task Main(string[] args)
        {
            // await GetDbByApi();
            // SetLocations();
            // var monsters = _readCsv.ReadDynamicClass<MonsterCsv>("monster.csv");
        }

        private static void SetLocations()
        {
            var locations = Service.CreateLocationsByCsv();
            Service.CreateLocationRange(locations);
        }

        private async Task GetDbByApi()
        {
            await Service.GetDbByApi();
        }

        
    }
}