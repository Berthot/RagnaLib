using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Storage;
using Google.Api.Gax.ResourceNames;
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


        public void DownloadImages()
        {
            // DownloadMonsterGif();
            // DownloadMonsterSmall();
            // DownloadItemImage();
            // DownloadItemSmallImage();
            // DownloadItemCardImage();

            // CardPrefix
            // CardImageUrl
            // ImageUrl
            // CardImageUrl
            // SmallImageUrl
        }

        private void DownloadItemImage()
        {
            var idMonsters = _repo.GetItemWithoutCardIds();
            const string urlPath = @"bro/collection/";
            const string outPath = "item-image";
            Download(idMonsters, outPath, urlPath, "png");
        }

        private void DownloadItemSmallImage()
        {
            var idMonsters = _repo.GetItemWithoutCardIds();
            const string urlPath = @"bro/item/";
            const string outPath = "item-small";
            Download(idMonsters, outPath, urlPath, "png");
        }

        private void DownloadItemCardImage()
        {
            var idMonsters = _repo.GetItemCardIds();
            const string urlPath = @"bro/card/";
            const string outPath = "item-card";
            Download(idMonsters, outPath, urlPath, "png");
        }

        private void DownloadMonsterGif()
        {
            var idMonsters = _repo.GetMonstersIds();
            const string urlPath = @"db/npc/gif/";
            const string outPath = "monster-gif";
            Download(idMonsters, outPath, urlPath, "gif");
        }

        private void DownloadMonsterSmall()
        {
            var idMonsters = _repo.GetMonstersIds();
            const string urlPath = @"db/npc/small/";
            const string outPath = "monster-small";
            Download(idMonsters, outPath, urlPath, "png");
        }

        private static async void Download(IEnumerable<int> ids, string folderName, string urlPath, string extension)
        {
            using var webClient = new WebClient();
            var basePath = @$"https://static.ragnaplace.com/{urlPath}/";
            var outPath = @$"/home/bertho/Pictures/ragnaLib/{folderName}/";
            var count = ids.Count();
            foreach (var id in ids.OrderBy(i => i))
            {
                if (count % 100 == 0)
                    Console.WriteLine($"COUNT         : {count}");
                count--;
                await DownloadFile(basePath, outPath, id.ToString(), extension, webClient, folderName);
            }
        }

        private static async Task DownloadFile(string basePath, string outPath, string id, string extension,
            WebClient webClient, string alias)
        {
            try
            {
                var dataArr = webClient.DownloadData($"{basePath}{id}.{extension}");
                File.WriteAllBytes(@$"{outPath}{id}.{extension}", dataArr);
                // Console.WriteLine($"DOWNLOAD OK   : {id}");
            }
            catch (Exception)
            {
                Console.WriteLine($"DOWNLOAD ERROR: {id}");
                await WriterCsv.AppendInLogFile($"{alias.Split("-")[0]}", $"{alias},{id},notFound");
            }
        }

        public async Task SendImages()
        {
            // await SendImagesToFireBase("monster-gif");
            // await SendImagesToFireBase("monster-small");
            // await SendImagesToFireBase("item-card");
            // await SendImagesToFireBase("item-small");
            // await SendImagesToFireBase("item-image");
        }

        private static async Task SendImagesToFireBase(string folderName)
        {
            // var files = Directory.GetFiles("/home/bertho/Pictures/ragnaLib/item-image");
            var files = Directory.GetFiles($"/home/bertho/Pictures/ragnaLib/{folderName}");
            var count = files.Length;
            Console.WriteLine($"Total: {count.ToString()}");
            foreach (var file in files)
            {
                var fileName = file.Split("/").Last();
                var stream = File.Open(file, FileMode.Open);
                await UploadFilesToFirebase(stream, folderName, fileName);
                
                if (count % 100 == 0)
                    Console.WriteLine($"COUNT-{folderName} : {count}");
                count--;
            }
        }

        private static async Task UploadFilesToFirebase(Stream stream, string fireBaseFolder, string fileName)
        {
            try
            {
                const string token ="token from firebase";
                var task = new FirebaseStorage("name.appspot.com",
                        new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(token),
                            ThrowOnCancel = true,
                        })
                    .Child($"{fireBaseFolder}/{fileName}")
                    .PutAsync(stream);
                // task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
                await task;
                // Console.WriteLine($"OK     :{fileName}");
                // Console.WriteLine(downloadUrl);
            }
            catch (Exception)
            {
                Console.WriteLine($"ERRO   :{fileName}");
                await WriterCsv.AppendInLogFile($"monster", $"{fireBaseFolder},{fileName},notFound");
            }
        }
    }
}