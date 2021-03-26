using System;
using System.Collections.Generic;
using System.Linq;
using RagnaLib.Domain.Entities;
using RagnaLib.Infra.Data;
using RagnaLib.Wrapper.CsvWrapper;
using RagnaLib.Wrapper.CsvWrapper.CsvModels;

namespace RagnaLib.Wrapper
{
    public class WrapperService
    {
        private WrapperFactory _factory = new WrapperFactory();
        private readonly ReadCsv _readCsv = new ReadCsv();
        private WrapperRepository _repo = new WrapperRepository(new Context());

        public void GetElementsByCsv()
        {
            var csv = _readCsv.ReadDynamicClass<CsvElement>("ragnarok_public_Element.csv");
            var elementModels = csv.Select(x => _factory.GetElementModel(x)).ToList();
            _repo.CreateElementRange(elementModels);
            _repo.SaveChanges();

            Console.WriteLine("elements criados com sucesso");
        }

        public void GetLocationByCsv()
        {
            var csv = _readCsv.ReadDynamicClass<CsvLocation>("ragnarok_public_Location.csv");
            var locationModels = csv.Select(x => _factory.GetLocationModel(x)).ToList();
            _repo.CreateLocationRange(locationModels);
            _repo.SaveChanges();

            Console.WriteLine("locations criados com sucesso");
        }

        public void GetItemsByCsv()
        {
            var csv = _readCsv.ReadDynamicClass<CsvItem>("ragnarok_public_Item.csv");
            var csvItemEquipPositionMap =
                _readCsv.ReadDynamicClass<CsvItemEquipPositionMap>("ragnarok_public_ItemEquipPositionMap.csv");
            var itemModels = csv.Select(x => _factory.GetItemModel(x)).ToList();
            var subTypes = _repo.GetSubTypes();
            var itemTypes = _repo.GetItemTypes();
            var equipPositions = _repo.GetEquipPosition();
            foreach (var itemModel in itemModels)
            {
                itemModel.SubType = subTypes.FirstOrDefault(x => x.Id == itemModel.SubTypeId);
                itemModel.ItemType = itemTypes.FirstOrDefault(x => x.Id == itemModel.ItemTypeId);
                itemModel.ItemEquipPositionMaps =
                    GetItemEquipPosition(itemModel.Id, equipPositions, csvItemEquipPositionMap);
            }

            _repo.CreateItemRange(itemModels);
            _repo.SaveChanges();
            Console.WriteLine("items criados com sucesso");
        }

        private IEnumerable<ItemEquipPositionMap> GetItemEquipPosition(int itemModelId,
            IReadOnlyCollection<EquipPosition> equipPositions,
            IEnumerable<CsvItemEquipPositionMap> csvItemEquipPositionMaps)
        {
            return csvItemEquipPositionMaps
                .Where(x => x.ItemId == itemModelId)
                .Select(positionMap => new ItemEquipPositionMap()
                {
                    EquipPosition = equipPositions
                        .FirstOrDefault(x => x.Id == positionMap.EquipPositionId)
                }).ToList();
        }

        public void CreateMonsterByCsv()
        {
            var csvMonsters = _readCsv.ReadDynamicClass<CsvMonster>("ragnarok_public_Monster.csv");
            var csvMonsterItemMaps = _readCsv.ReadDynamicClass<CsvMonsterItemMap>("ragnarok_public_MonsterItemMap.csv");
            var csvMonsterMvpDropMaps =
                _readCsv.ReadDynamicClass<CsvMonsterMvpDropMaps>("ragnarok_public_MonsterMvpDropMaps.csv");
            var csvMonsterPerLocationMaps =
                _readCsv.ReadDynamicClass<CsvMonsterPerLocationMap>("ragnarok_public_MonsterPerLocationMap.csv");
            var monsterModels = csvMonsters.Select(x => _factory.GetMonsterModel(x)).ToList();
            var races = _repo.GetRaces();
            var scales = _repo.GetScales();
            var elements = _repo.GetElements();
            var items = _repo.GetItems();
            var locates = _repo.GetLocations();

            foreach (var monsterModel in monsterModels)
            {
                monsterModel.Element = elements.FirstOrDefault(x => x.Id == monsterModel.ElementId);
                monsterModel.Race = races.FirstOrDefault(x => x.Id == monsterModel.RaceId);
                monsterModel.Scale = scales.FirstOrDefault(x => x.Id == monsterModel.ScaleId);

                monsterModel.MonsterItemMaps = GetMonsterItemMaps(monsterModel.Id, csvMonsterItemMaps, items);
                monsterModel.MonsterMvpDropMaps = GetMvpDropMaps(monsterModel.Id, csvMonsterMvpDropMaps, items);
                monsterModel.MonsterPerLocationMaps =
                    GetMonsterPerLocationMaps(monsterModel.Id, csvMonsterPerLocationMaps, locates);
            }

            _repo.CreateMonsterRange(monsterModels);
            _repo.SaveChanges();
            Console.WriteLine("Monsters criados com sucesso");
        }

        private IEnumerable<MonsterPerLocationMap> GetMonsterPerLocationMaps(int monsterId,
            List<CsvMonsterPerLocationMap> csvMonsterPerLocationMaps, List<Location> locates)
        {
            var lista = new List<MonsterPerLocationMap>();

            foreach (var csvMonsterMvpDropMap in csvMonsterPerLocationMaps.Where(x => x.MonsterId == monsterId))
            {
                lista.Add(new MonsterPerLocationMap()
                {
                    Location = locates.FirstOrDefault(x => x.Id == csvMonsterMvpDropMap.LocationId),
                    Quantity = csvMonsterMvpDropMap.Quantity,
                    RespawnTime = csvMonsterMvpDropMap.RespawnTime
                });
            }

            return lista;
        }

        private List<MonsterMvpDropMap> GetMvpDropMaps(int monsterId,
            List<CsvMonsterMvpDropMaps> csvMonsterMvpDropMaps, List<Item> items)
        {
            var lista = new List<MonsterMvpDropMap>();

            foreach (var csvMonsterMvpDropMap in csvMonsterMvpDropMaps.Where(x => x.MonsterId == monsterId))
            {
                lista.Add(new MonsterMvpDropMap()
                {
                    DropRate = csvMonsterMvpDropMap.DropRate,
                    Item = items.FirstOrDefault(x => x.Id == csvMonsterMvpDropMap.ItemId),
                    Stealable = csvMonsterMvpDropMap.Stealable
                });
            }

            return lista;
        }

        private IEnumerable<MonsterItemMap> GetMonsterItemMaps(int monsterId,
            List<CsvMonsterItemMap> csvMonsterItemMaps, List<Item> items)
        {
            var lista = new List<MonsterItemMap>();

            foreach (var csvMonsterItemMap in csvMonsterItemMaps.Where(x => x.MonsterId == monsterId))
            {
                lista.Add(new MonsterItemMap()
                {
                    DropRate = csvMonsterItemMap.DropRate,
                    Item = items.FirstOrDefault(x => x.Id == csvMonsterItemMap.ItemId),
                    Stealable = csvMonsterItemMap.Stealable
                });
            }

            return lista;
        }
    }
}