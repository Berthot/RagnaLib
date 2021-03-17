using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RagnaLib.Domain.Entities;
using RagnaLib.Infra.Data;
using RagnaLib.Wrapper.CsvWrapper;
using RagnaLib.Wrapper.CsvWrapper.CsvModels;
using RagnaLib.Wrapper.Factory;
using RagnaLib.Wrapper.ModelsAPI;
using Element = RagnaLib.Domain.Entities.Element;

namespace RagnaLib.Wrapper
{
    public class WrapperService
    {
        private readonly WrapperRepository _repo;
        private readonly WrapperFactory _factory;
        private static ApiFactory _apiFactory;
        private static WriterCsv _writerCsv;
        private readonly ReadCsv _readCsv;
        private readonly Context _context;

        public WrapperService(Context context)
        {
            _context = context;
            _repo = new WrapperRepository(context);
            _factory = new WrapperFactory();
            _apiFactory = new ApiFactory();
            _writerCsv = new WriterCsv();
            _readCsv = new ReadCsv();
        }

        public async Task GetDbByApi()
        {
            // var id = "1001";
            // start 1001 -- end: 3508
            foreach (var id in Enumerable.Range(1001, 3508))
            {
                try
                {
                    var ragnaApi = new RagnaplaceApi();
                    var monst = ragnaApi.GetMonster(id.ToString());
                    await WriteMonster(monst);
                    await WriteDrop(monst);
                    await WriteMaps(monst);
                    Console.WriteLine($"ID: {id} --- Name: {monst.Name}");
                }
                catch (Exception)
                {
                    await WriteError($"{id}");
                }
                finally
                {
                    await WriteLog($"{id},OK");

                    Thread.Sleep(120);
                }
            }
        }

        private static async Task WriteLog(string id, string fileName = "log")
        {
            await _writerCsv.AppendInFile(fileName, $"{id}");
        }
        
        private static async Task WriteError(string id)
        {
            await _writerCsv.AppendInFile("erro", $"{id}");
        }

        private static async Task WriteMaps(MonsterCollection monster)
        {
            var text = _apiFactory.WriteMapList(monster.SpawnMaps?.ToList());
            if (string.IsNullOrEmpty(text)) return;

            await _writerCsv.AppendInFile("maps", text);
        }

        private static async Task WriteDrop(MonsterCollection monster)
        {
            var text = _apiFactory.WriteItemList(monster.Drops?.ToList());
            if (string.IsNullOrEmpty(text)) return;

            await _writerCsv.AppendInFile("drop", text);
        }

        private static async Task WriteMonster(MonsterCollection monster)
        {
            var text = _apiFactory.WriteMonster(monster);
            if (string.IsNullOrEmpty(text)) return;
            await _writerCsv.AppendInFile("monster", text);
        }

        public void CreateLocationRange(List<Location> locations)
        {
            // using var transaction = _context.Database.BeginTransaction();
            try
            {
                _repo.CreateLocationRange(locations);
                _repo.SaveChanges();
                // transaction.Commit();

            }
            catch (Exception ex)
            {
                // transaction.Rollback();
                Console.WriteLine(ex);
                throw;
            }
        }
        
        public List<Location> CreateLocationsByCsv()
        {
            var csv = _readCsv.ReadDynamicClass<LocationCsv>("maps_ragnaplace.csv");
            return csv.Select(x => _factory.GetLocationEntity(x)).OrderBy(x=>x.Name).ToList();

        }

        public List<Element> CreateElementsByCsv()
        {
            var csv = _readCsv.ReadDynamicClass<ElementCsv>("elements_ragnarok.csv");
            return csv.Select(x => _factory.GetElementEntity(x)).OrderBy(x=>x.Name).ToList();

        }

        public void CreateElementRange(List<Element> elements)
        {
            // using var transaction = _context.Database.BeginTransaction();
            try
            {
                _repo.CreateElementRange(elements);
                _repo.SaveChanges();
                // transaction.Commit();

            }
            catch (Exception ex)
            {
                // transaction.Rollback();
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}