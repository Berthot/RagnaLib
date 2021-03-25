using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RagnaLib.Domain.Entities;
using RagnaLib.Domain.ValueObjects;
using RagnaLib.Infra.Data;
using RagnaLib.Wrapper.CsvWrapper;
using RagnaLib.Wrapper.CsvWrapper.CsvModels;
using RagnaLib.Wrapper.Factory;
using RagnaLib.Wrapper.ModelsAPI;
using RagnaLib.Wrapper.RagnaPride;
using Element = RagnaLib.Domain.Entities.Element;
using Item = RagnaLib.Domain.Entities.Item;

namespace RagnaLib.Wrapper
{
    public class WrapperService
    {
        private readonly WrapperRepository _repo;
        private readonly WrapperFactory _factory;
        private static ApiFactory _apiFactory;
        private static RagnaPrideItemFactory _itemRpFactory;
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
            _itemRpFactory = new RagnaPrideItemFactory();
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
            return csv.Select(x => _factory.GetLocationEntity(x)).OrderBy(x => x.Name).ToList();
        }

        public List<Element> CreateElementsByCsv()
        {
            var csv = _readCsv.ReadDynamicClass<ElementCsv>("elements_ragnarok.csv");
            return csv.Select(x => _factory.GetElementEntity(x)).OrderBy(x => x.Name).ToList();
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

        public List<Identity> GetIdsRange(int start, int end)
        {
            var ids = new ReadCsv().ReadDynamicClass<Identity>("item_id.csv");

            return ids.GetRange(start, end - start);
        }

        public void GetItemsFromRagnaPride(List<Identity> ids, string idName)
        {
            var api = new RagnaPrideApi();
            var acc = 0;
            var lista = new List<RpItemCsv>();
            foreach (var id in ids.Select(identity => identity.Id))
            {
                acc++;
                var item = api.GetItem(id);
                // var print = $"{item.id} - {item.name}";
                // Console.WriteLine(print);
                var rpItemCsv = _itemRpFactory.GetMainItem(item);
                lista.Add(rpItemCsv);
                if (acc % 1 == 0)
                    Console.WriteLine(
                        $"ID: {idName} - COUNT {acc} ---------------------------------------------------------------------------");
            }

            _writerCsv.WriteDynamicCsvByClass($"ragnaPrideItems/ragnaplace_item_{idName}", lista);
        }

        public IEnumerable<RpItemCsv> GetItemsByCsv()
        {
            var csv = _readCsv.ReadDynamicClass<RpItemCsv>(
                "/home/bertho/Documents/Git/RagnaLib/RagnaLib.Wrapper/Resources/ItemsRangPride.csv");
            return csv;
        }

        public List<Item> ItemRagnaPrideToModel(IEnumerable<RpItemCsv> itemsRagnaPride)
        {
            var lista = new List<Item>();
            var ids = new List<string>();

            foreach (var itemCsv in itemsRagnaPride)
            {
                if (ids.Contains(itemCsv.Id))
                    continue;
                ids.Add(itemCsv.Id);
                lista.Add(_factory.GetItemModel(itemCsv));
            }

            return lista;
        }

        public void SetItemSubType(List<Item> itemModels, List<RpItemCsv> rpItems)
        {
            var subTypeDb = _context.SubTypes.ToList();
            foreach (var item in itemModels)
            {
                // if 517 set 22 and 23
                var rpItem = rpItems.First(x => x.Id == item.Id.ToString());
                var subTypeRpId = _factory.StringToInteger(rpItem?.RagnaPriceSubItemTypeId);
                var dbSubTypeId = SubTypeDic()[subTypeRpId];
                var subtypeModel = subTypeDb.FirstOrDefault(x => x.Id == dbSubTypeId);
                item.SubType = subtypeModel;
            }
        }

        public Dictionary<int, int> SubTypeDic()
        {
            return new Dictionary<int, int>()
            {
                [-1] = -1,
                [256] = 1,
                [257] = 2,
                [258] = 3,
                [259] = 4,
                [260] = 5,
                [261] = 6,
                [262] = 7,
                [263] = 8,
                [265] = 9,
                [266] = 10,
                [267] = 11,
                [268] = 12,
                [269] = 13,
                [270] = 14,
                [271] = 15,
                [272] = 16,
                [275] = 17,
                [276] = 18,
                [277] = 19,
                [278] = 20,
                [517] = 21,
                [510] = 22,
                [511] = 23,
                [512] = 24,
                [513] = 25,
                [515] = 26,
                [516] = 27,
                [518] = 28,
                [768] = 29,
                [769] = 30,
                [1028] = 31,
                [1024] = 32,
                [1025] = 33,
                [1026] = 34,
                [1027] = 35,
                [0] = 36,
                [273] = 37,
                [274] = 38,
                [514] = 39,
                [522] = 40,
                [280] = 41,
                [526] = 42,
                [527] = 43,
                [528] = 44,
                [529] = 45,
                [530] = 46,
                [519] = 47,
            };
        }

        public Dictionary<int, int> EquipLocationDic()
        {
            return new Dictionary<int, int>()
            {
                [-1] = -1,
                [0] = -1,
                [136] = 1,
                [128] = 2,
                [8] = 3,
                [16] = 4,
                [34] = 5,
                [4] = 6,
                [32] = 7,
                [64] = 8,
                [2] = 9,
                [131072] = 10,
                [1048576] = 11,
                [65536] = 12,
                [262144] = 13,
                [524288] = 14,
                [2097152] = 15,
                [4096] = 16,
                [2048] = 17,
                [1024] = 18,
                [6144] = 19,
                [5120] = 20,
                [3072] = 21,
                [7168] = 22,
                [8192] = 23,
                [1] = 24,
                [512] = 25,
                [256] = 26,
                [769] = 27,
                [768] = 28,
                [257] = 29,
                [513] = 30,
            };
        }

        public void SetItemType(List<Item> itemModels, List<RpItemCsv> rpItems)
        {
            var typeDb = _context.ItemTypes.ToList();

            foreach (var item in itemModels)
            {
                // if 517 set 22 and 23
                var rpItem = rpItems.First(x => x.Id == item.Id.ToString());
                var typeRpId = _factory.StringToInteger(rpItem?.RagnaPriceItemTypeId);
                var dbTypeId = TypeDic()[typeRpId];
                if (dbTypeId == 22 || dbTypeId == 23)
                    dbTypeId = 21;
                var typeModel = typeDb.FirstOrDefault(x => x.Id == dbTypeId);
                item.ItemType = typeModel;
            }
        }

        public Dictionary<int, int> TypeDic()
        {
            return new Dictionary<int, int>()
            {
                [-1] = -1,
                [0] = -1,
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
                [5] = 5,
                [6] = 9,
                [7] = 6,
                [9] = 7,
                [10] = 8,
            };
        }

        public void SetItemEquipPosition(List<Item> itemModels, List<RpItemCsv> rpItemCsv)
        {
            var positions = _context.EquipPositions.ToList();

            var dic = EquipLocationDic();

            var csv = _readCsv.ReadDynamicClass<CardPosition>(
                "/home/bertho/Documents/Git/RagnaLib/RagnaLib.Wrapper/Resources/CardLocation.csv");

            foreach (var item in itemModels)
            {
                var rpItem = rpItemCsv.First(x => x.Id == item.Id.ToString());

                var locationId = _factory.StringToInteger(rpItem?.LocationId);
                if (!dic.ContainsKey(locationId))
                    locationId = -1;
                if (item.ItemType.Id == 9)
                {
                    var test = csv.FirstOrDefault(x => x.Id == item.Id.ToString());
                    if (test != default)
                    {
                        locationId =
                            int.Parse(csv.FirstOrDefault(x => x.Id == item.Id.ToString()).LocationId.ToString());
                        item.ItemEquipPositionMaps = new List<ItemEquipPositionMap>()
                        {
                            new ItemEquipPositionMap()
                            {
                                EquipPosition = positions.FirstOrDefault(x => x.Id == locationId)
                            }
                        };
                        continue;
                    }
                }

                item.ItemEquipPositionMaps = new List<ItemEquipPositionMap>()
                {
                    new ItemEquipPositionMap()
                    {
                        EquipPosition = positions.FirstOrDefault(x => x.Id == EquipLocationDic()[locationId])
                    }
                };
            }
        }

        public void CreateItemRange(List<Item> itemModels)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _repo.CreateItemRange(itemModels);
                _repo.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex);
                throw;
            }
        }


        public void GetMonsterByApi()
        {
            // // RpMonsterCsv
            // var api = new RagnaPrideApi();
            // var acc = 0;
            // var lista = new List<RpMonsterCsv>();
            // // var ids = Enumerable.Range(1001, 1004 - 1001);
            // var ids = Enumerable.Range(1001, 3509 - 1001);
            // // foreach (var id in Enumerable.Range(1001, 3508))
            // foreach (var id in ids)
            // {
            //     try
            //     {
            //         acc++;
            //         var item = api.GetMonster(id);
            //         // var print = $"{item.id} - {item.name}";
            //         // Console.WriteLine(print);
            //         var rpItemCsv = _factory.GetMonsterRpCsv(item);
            //         lista.Add(rpItemCsv);
            //         Console.WriteLine($"{id} - {rpItemCsv.Name}");
            //     }
            //     catch (Exception e)
            //     {
            //         Console.WriteLine($"{id} - ERROR");
            //     }
            // }
            //
            // _writerCsv.WriteDynamicCsvByClass($"/home/bertho/Documents/Git/RagnaLib/RagnaLib.Wrapper/Resources/RagnaPrideMonsters/" +
            //                                   $"ragnaplace_monsters", lista);
        }

        public List<RpMonsterCsv> GetMonsterByCsv()
        {
            var monster = new ReadCsv().ReadDynamicClass<RpMonsterCsv>(
                "/home/bertho/Documents/Git/RagnaLib/RagnaLib.Wrapper/Resources/RagnaPrideMonsters/ragnaPride_monsters_test.csv");
            return monster;
        }


        public List<Monster> GetMonsterModel(List<RpMonsterCsv> monsterCsv)
        {
            var monsters = monsterCsv
                .Select(x => _factory.GetMonsterEntity(x)).ToList();

            var items = _repo.GetItems();
            var locations = _repo.GetLocations();
            var scales = _repo.GetScales();
            var races = _repo.GetRaces();
            var elements = _repo.GetElements();

            foreach (var monster in monsters)
            {
                var monsterCsvv = monsterCsv.FirstOrDefault(x => x.Id == monster.Id);
                var drop = monsterCsvv.Drop;
                var spawns = monsterCsvv.Spawn;
                monster.MonsterItemMaps = GetItemFromCsv(monster.Id, drop, items);
                monster.MonsterPerLocationMaps = GetMonsterPerMap(monster.Id, spawns, locations);
                if (elements.FirstOrDefault(x => x.Id == monsterCsvv.IdElement) == default)
                {
                    var x = 1 + 1;
                }
                monster.Element = elements.FirstOrDefault(x => x.Id == monsterCsvv.IdElement);
                monster.Scale = scales.FirstOrDefault(x => x.Id == monsterCsvv.IdScale);
                monster.Race = races.FirstOrDefault(x => x.Id == monsterCsvv.IdRace);
                if (monster.IsMvp)
                    monster.MonsterMvpDropMaps = GetMonsterMvpDrop(monster.Id, drop, items);
            }


            return monsters;
        }

        private List<MonsterMvpDropMap> GetMonsterMvpDrop(int monsterId, string dropStr, List<Item> items)
        {
            // itemID;chance;stealprotected;serverType
            var drop = dropStr
                .Split("|")
                .Where(x => x != "")
                .ToList();

            var lista = new List<MonsterMvpDropMap>();
            foreach (var d in drop)
            {
                var l = d.Split(";");

                var item = items.FirstOrDefault(x => x.Id == int.Parse(l[0].ToString()));
                if (item == default)
                {
                    Console.WriteLine($"NOT FOUND MVPDROP || ,{monsterId},{l[0]},{l[1]},{l[2]}");
                    continue;
                }

                var chance = l[1];
                var steal = bool.Parse(l[2].ToLower());
                lista.Add(new MonsterMvpDropMap()
                {
                    Item = item,
                    DropRate = Convert.ToInt32(chance),
                    Stealable = steal
                });
            }

            return lista;
        }

        private IEnumerable<MonsterPerLocationMap> GetMonsterPerMap(int monsterId, string spawnsString, List<Location> locations)
        {
            var spawnsList = spawnsString
                .Split("|")
                .Where(x => x != "")
                .ToList();
            var lista = new List<MonsterPerLocationMap>();
            foreach (var spn in spawnsList)
            {
                // map;amount;respawnTime
                var l = spn.Split(";");
                var location = locations.FirstOrDefault(x => x.NameId == l[0]);
                var amount = int.Parse(l[1]);
                var time = int.Parse(l[2]);
                if (location == default)
                {
                    Console.WriteLine($"NOT FOUND SPAWN || ,{monsterId},{l[0]},{l[1]},{l[2]}");
                    continue;
                }

                lista.Add(
                    new MonsterPerLocationMap() {Location = location, Quantity = amount, RespawnTime = time}
                );
            }

            return lista;
        }

        private IEnumerable<MonsterItemMap> GetItemFromCsv(int idMonster, string dropString, List<Item> items)
        {
            // itemID;chance;stealprotected;serverType
            var drop = dropString
                .Split("|")
                .Where(x => x != "")
                .ToList();

            var lista = new List<MonsterItemMap>();
            foreach (var d in drop)
            {
                var l = d.Split(";");

                var item = items.FirstOrDefault(x => x.Id == int.Parse(l[0].ToString()));
                if (item == default)
                {
                    Console.WriteLine($"NOT FOUND || ,{idMonster},{l[0]},{l[1]},{l[2]}");
                    continue;
                }

                var chance = l[1];
                var steal = bool.Parse(l[2].ToLower());
                lista.Add(new MonsterItemMap()
                {
                    Item = item,
                    DropRate = Convert.ToInt32(chance),
                    Stealable = steal
                });
            }

            return lista;
        }

        public void CreateMonsterRange(List<Monster> monsterModel)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _repo.CreateMonsterRange(monsterModel);
                _repo.SaveChanges();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}