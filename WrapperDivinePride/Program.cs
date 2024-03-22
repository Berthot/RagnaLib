using Infrastructure.Data;
using WrapperDivinePride.CsvWrapper;
using WrapperDivinePride.Extensions;
using WrapperDivinePride.Mapper;
using WrapperDivinePride.Models;
using WrapperDivinePride.Wrappers;

var repo = new WrapperRepository(new Context());
var divinePride = new DivinePrideRepository();
var jsonWrapper = new JsonWrapperRepository();
var jsonReader = new ReadJson();

// repo.CreateInitialTables();
var data = await jsonWrapper.GetJsonList<MonsterJson>(ESearchType.Monster);
// var data = await jsonWrapper.GetJsonList<ItemJson>(ESearchType.Item);


foreach (var obj in data)
{
    // Console.WriteLine(monster!.Name);
    try
    {
        if (obj.Id == 46)
        {
            Console.WriteLine("batata");
        }
        Console.WriteLine(obj.Map().Name);
    }
    catch (Exception e)
    {
        // Console.WriteLine(obj.Id);
        // Console.WriteLine(obj.ToJson());
        // throw;
    }
}

// foreach (var x in ResourcesRepository.GetRaces().OrderBy(x=>x.Id))
// {
    // Console.WriteLine(x.Id + "---" + x.Name);
// }