using System;
using System.Collections.Generic;
using System.Linq;
using RagnaLib.Wrapper.ModelsAPI;

namespace RagnaLib.Wrapper.Factory
{
    public class ApiFactory
    {
        private List<string> _inMemory = new List<string>();


        public string WriteMonster(MonsterCollection monster)
        {
            var itemsString = GetItemsStringList(monster);
            var mapsString = GetMapStringList(monster);
            var text = GetMonsterString(monster, itemsString, mapsString);
            
            return text.Substring(0, text.Length - 2);

        }

        private static string GetMonsterString(MonsterCollection monster, string itemsString, string mapsString)
        {
            try
            {
                var text =
                    $"\"{monster.Id}\"," +
                    $"\"{monster.Name}\"," +
                    // $"\"{monster.Stats.Hp}\"," +
                    // $"\"{monster.Stats.Level}\"," +
                    // $"\"{monster.Stats.Race}\"," +
                    // $"\"{monster.Stats.Size}\"," +
                    $"\"{monster.GifUrl}\"," +
                    $"\"{itemsString}\"," +
                    $"\"{mapsString}\"," +
                    $"\n";
                return text;
            }
            catch (Exception)
            {
                return "";
            }

        }

        private static string GetMapStringList(MonsterCollection monster)
        {
            try
            {
                // var mapsString =
                //     monster.SpawnMaps.Select(x => x.MapId)
                //         .Aggregate("", (current, id) =>
                //             $"{current}{id.ToString()}|");
                // return mapsString;
                return null;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private static string GetItemsStringList(MonsterCollection monster)
        {
            try
            {
                var itemsString =
                    monster.Drops.Select(x => x.Id)
                        .Aggregate("", (current, id) =>
                            $"{current}{id.ToString()}|");
                return itemsString;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string WriteItemList(List<ItemCollection> items)
        {
            try
            {
                var text = items.Aggregate("", (current, item) => $"{current}{WriteItem(item)}");

                return text.Substring(0, text.Length - 2);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        
        private string WriteItem(ItemCollection item)
        {
            try
            {
                var text =
                    $"\"{item.Id}\"," +
                    $"\"{item.Name}\"," +
                    $"\"{item.ImgUrl}\"," +
                    $"\"{item.CollectionImgUrl}\"," +
                    $"\"{item.CardImgUrl}\"," +
                    $"\" \"," +
                    $"\n";
                if (_inMemory.Contains(text))
                    return "";
                _inMemory.Add(text);
                    
                return text;
            }
            catch (Exception)
            {
                return "";
            }

        }

        public string WriteMapList(List<Spawn> maps)
        {
            try
            {
                var text = maps.Aggregate("", (current, item) => $"{current}{WriteMap(item)}");

                return text.Substring(0, text.Length - 2);
                
            }
            catch (Exception)
            {
                return "";
            }


        }
        
        public string WriteMap(Spawn mSpawn)
        {
            try
            {
                return null;
                // var text =
                //     $"\"{mSpawn.MapId}\"," +
                //     $"\"{mSpawn.MapName}\"," +
                //     $"\n";
                // if (_inMemory.Contains(text))
                //     return "";
                // _inMemory.Add(text);
                // return text;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}