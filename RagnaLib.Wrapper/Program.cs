using System;
using System.Linq;
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
            // SetLocations();
            // SetElements();
            SetItems();
            // var ids = new ReadCsv().ReadDynamicClass<Identity>("item_id.csv");
            // GetItemsFromRagnaPride();
        }

        private static void SetItems()
        {
            var itemsRagnaPride = Service.GetItemsByCsv().ToList();
            var itemModels = Service.ItemRagnaPrideToModel(itemsRagnaPride);
            Service.SetItemSubType(itemModels, itemsRagnaPride);
            Console.WriteLine("Set item SubType - OK");
            Service.SetItemType(itemModels, itemsRagnaPride);
            Console.WriteLine("Set item Type - OK");
            Service.SetItemEquipPosition(itemModels, itemsRagnaPride);
            Console.WriteLine("Set item position - OK");
            Service.CreateItemRange(itemModels);

        }

        private static void GetItemsFromRagnaPride()
        {
            // Console.WriteLine(ids.Count); -- 16.329
            // 8
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(0, 16320), "TOTAL");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(0, 1000), "0");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(1001, 2000), "1");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(2001, 3000), "2");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(3001, 4000), "3");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(4001, 5000), "4");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(5001, 6000), "5");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(6001, 7000), "6");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(7001, 8000), "7");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(8001, 9000), "8");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(9001, 10000), "9");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(10001, 11000), "10");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(11001, 12000), "11");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(12001, 13000), "12");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(13001, 14000), "13");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(14001, 15000), "14");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(15001, 16000), "15");
            // Service.GetItemsFromRagnaPride(Service.GetIdsRange(16001, 16328), "16");
            
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