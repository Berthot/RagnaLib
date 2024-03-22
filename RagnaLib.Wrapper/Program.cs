using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Newtonsoft.Json;
using RagnaLib.Wrapper.Models;
using RagnaLib.Wrapper.Wrappers;

namespace RagnaLib.Wrapper;

class Program
{
    private static string BasePath => "/home/bertho/Documents/personal_projects/RagnaLib/RagnaLib.Wrapper/Files/";

    public static async Task Main(string[] args)
    {
        await ProcessItem();
        await ProcessMonster();

        Environment.Exit(666);

        new WrapperService().GetLocationByCsv();
        new WrapperService().GetElementsByCsv();
        new WrapperService().GetItemsByCsv();
        new WrapperService().CreateMonsterByCsv();
        new WrapperService().DownloadImages();
        var wrapper = new WrapperService();
        await wrapper.SendImages();
    }

    private static async Task ProcessItem()
    {
        var json = await System.IO.File.ReadAllTextAsync($@"{BasePath}/item_data.json");
        var items = JsonConvert.DeserializeObject<List<MonsterJson>>(json);
        Console.WriteLine($"item.len: {items.Count}");
    }

    private static async Task ProcessMonster()
    {
        var json = await System.IO.File.ReadAllTextAsync($@"{BasePath}/monster_data.json");
        var monsters = JsonConvert.DeserializeObject<List<MonsterJson>>(json);
        Console.WriteLine($"monster.len: {monsters.Count}");
    }

}