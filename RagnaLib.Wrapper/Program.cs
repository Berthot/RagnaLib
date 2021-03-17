using System.Threading.Tasks;
using RagnaLib.Infra.Data;
using RagnaLib.Wrapper.CsvWrapper;
using RagnaLib.Wrapper.CsvWrapper.CsvModels;

namespace RagnaLib.Wrapper
{
    class Program
    {
        // private static ReadCsv _readCsv = new ReadCsv();
        private static readonly WrapperService Service = new WrapperService(new Context());

        public static async Task Main(string[] args)
        {
            SetLocations();
            SetElements();
            // var monsters = new ReadCsv()
                // .ReadDynamicClass<ElementCsv>("elements_ragnarok.csv");
        }

        private static void SetElements()
        {
            var elements = Service.CreateElementsByCsv();
            Service.CreateElementRange(elements);
        }

        private static void SetLocations()
        {
            var locations = Service.CreateLocationsByCsv(); // TODO enable transaction
            Service.CreateLocationRange(locations);
        }

        private async Task GetDbByApi()
        {
            await Service.GetDbByApi();
        }

        
    }
}