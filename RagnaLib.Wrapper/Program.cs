using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RagnaLib.Wrapper.CsvWrapper;
using RagnaLib.Wrapper.CsvWrapper.CsvModels;
using RagnaLib.Wrapper.Factory;
using RagnaLib.Wrapper.ModelsAPI;

namespace RagnaLib.Wrapper
{
    class Program
    {
        private static WriterCsv _writerCsv = new WriterCsv();
        private static ReadCsv _readCsv = new ReadCsv();
        private static ApiFactory _factory = new ApiFactory();

        public static async Task Main(string[] args)
        {
            // // var id = "1001";
            // // start 1001 -- end: 3508
            // foreach (var id in Enumerable.Range(1001, 3508))
            // {
            //     try
            //     {
            //         var ragnaApi = new RagnaplaceApi();
            //         var monst = ragnaApi.GetMonster(id.ToString());
            //         await WriteMonster(monst);
            //         await WriteDrop(monst);
            //         await WriteMaps(monst);
            //         Console.WriteLine($"ID: {id} --- Name: {monst.Name}");
            //     }
            //     catch (Exception)
            //     {
            //         await WriteError($"{id}");
            //     }
            //     finally
            //     {
            //         await WriteLog($"{id},OK");
            //
            //         Thread.Sleep(120);
            //     }
            // }
            var monsters = _readCsv.ReadDynamicClass<MonsterCsv>("monster.csv");

        }

        private static async Task WriteLog(string id)
        {
            await _writerCsv.AppendInFile("log", $"{id}");
        }


        private static async Task WriteError(string id)
        {
            await _writerCsv.AppendInFile("erro", $"{id}");
        }

        private static async Task WriteMaps(MonsterCollection monster)
        {
            var text = _factory.WriteMapList(monster.SpawnMaps?.ToList());
            if (string.IsNullOrEmpty(text)) return;

            await _writerCsv.AppendInFile("maps", text);
        }

        private static async Task WriteDrop(MonsterCollection monster)
        {
            var text = _factory.WriteItemList(monster.Drops?.ToList());
            if (string.IsNullOrEmpty(text)) return;

            await _writerCsv.AppendInFile("drop", text);
        }

        private static async Task WriteMonster(MonsterCollection monster)
        {
            var text = _factory.WriteMonster(monster);
            if (string.IsNullOrEmpty(text)) return;
            await _writerCsv.AppendInFile("monster", text);
        }
    }
}