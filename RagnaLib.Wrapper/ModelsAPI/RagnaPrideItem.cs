using System.Collections.Generic;

namespace RagnaLib.Wrapper.ModelsAPI
{

    // Root myDeserializedClass = JsonConvert.Deserializeobject?<RagnaPrideItem>(myJsonResponse); 
    public class Item
    {
        public int? itemId { get; set; }
        public string? name { get; set; }
    }

    public class Set
    {
        public string? name { get; set; }
        public List<Item>? items { get; set; }
    }

    public class Npc
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? mapname { get; set; }
        public int? job { get; set; }
        public int? x { get; set; }
        public int? y { get; set; }
        public string? type { get; set; }
    }

    public class SoldBy
    {
        public Npc npc { get; set; }
        public int? price { get; set; }
    }

    public class ItemSummonInfoContainedIn
    {
        public string? internalType { get; set; }
        public int? Type { get; set; }
        public int? sourceId { get; set; }
        public string? sourceName { get; set; }
        public int? targetId { get; set; }
        public string? targetName { get; set; }
        public int? count { get; set; }
        public int? totalOfSource { get; set; }
        public string? summonType { get; set; }
        public int? chance { get; set; }
    }

    public class ItemSummonInfoContain
    {
        public string? internalType { get; set; }
        public int? Type { get; set; }
        public int? sourceId { get; set; }
        public string? sourceName { get; set; }
        public int? targetId { get; set; }
        public string? targetName { get; set; }
        public int? count { get; set; }
        public int? totalOfSource { get; set; }
        public string? summonType { get; set; }
        public int? chance { get; set; }
    }

    public class ItemMoveInfo
    {
        public bool? drop { get; set; }
        public bool? trade { get; set; }
        public bool? store { get; set; }
        public bool? cart { get; set; }
        public bool? sell { get; set; }
        public bool? mail { get; set; }
        public bool? auction { get; set; }
        public bool? guildStore { get; set; }
    }

    public class Rewards
    {
        public List<object?> items { get; set; }
        public List<object?> efsts { get; set; }
        public List<object?> titles { get; set; }
    }

    public class RewardForAchievement
    {
        public int? id { get; set; }
        public string? title { get; set; }
        public object? summary { get; set; }
        public object? details { get; set; }
        public int? score { get; set; }
        public int? ui_type { get; set; }
        public string? group { get; set; }
        public int? major { get; set; }
        public int? minor { get; set; }
        public Rewards? rewards { get; set; }
        public List<object>? resources { get; set; }
    }

    public class EvolutionRecipe
    {
        public int? RecipeItemId { get; set; }
        public int? Amount { get; set; }
    }

    public class Pet
    {
        public int? monsterId { get; set; }
        public string? monsterName { get; set; }
        public int? chance { get; set; }
        public int? intimacy_fed { get; set; }
        public int? intimacy_overfed { get; set; }
        public int? intimacy_starve { get; set; }
        public int? intimacy_die { get; set; }
        public int? hunger_fed { get; set; }
        public int? hunger_interval { get; set; }
        public bool? performance { get; set; }
        public int? accessoryId { get; set; }
        public string? accessoryName { get; set; }
        public int? foodId { get; set; }
        public string? foodName { get; set; }
        public int? captureId { get; set; }
        public string? captureName { get; set; }
        public int? eggId { get; set; }
        public string? eggName { get; set; }
        public int? evolutionSourceItemId { get; set; }
        public string? evolutionSourceName { get; set; }
        public int? evolutionTargetItemId { get; set; }
        public string? evolutionTargetName { get; set; }
        public List<EvolutionRecipe>? evolutionRecipes { get; set; }
    }

    public class RagnaPrideItem
    {
        public int? classNum { get; set; }
        public List<Set>? sets { get; set; }
        public List<SoldBy>? soldBy { get; set; }
        public int? id { get; set; }
        public string? aegisName { get; set; }
        public string? name { get; set; }
        public string? unidName { get; set; }
        public string? resName { get; set; }
        public string? unidResName { get; set; }
        public string? description { get; set; }
        public string? unidDescription { get; set; }
        public int? slots { get; set; }
        public object? setname { get; set; }
        public int? itemTypeId { get; set; }
        public int? itemSubTypeId { get; set; }
        public List<ItemSummonInfoContainedIn>? itemSummonInfoContainedIn { get; set; }
        public List<ItemSummonInfoContain>? itemSummonInfoContains { get; set; }
        public int? attack { get; set; }
        public int? defense { get; set; }
        public double? weight { get; set; }
        public int? requiredLevel { get; set; }
        public int? limitLevel { get; set; }
        public int? itemLevel { get; set; }
        public int? job { get; set; }
        public int? compositionPos { get; set; }
        public int? attribute { get; set; }
        public object? location { get; set; }
        public int? locationId { get; set; }
        public object? accessory { get; set; }
        public int? price { get; set; }
        public int? range { get; set; }
        public bool? indestructible { get; set; }
        public int? matk { get; set; }
        public int? gender { get; set; }
        public bool? refinable { get; set; }
        public ItemMoveInfo? itemMoveInfo { get; set; }
        public List<RewardForAchievement>? rewardForAchievement { get; set; }
        public string? cardPrefix { get; set; }
        public List<Pet>? pets { get; set; }
        public bool? hasScript { get; set; }
    }


    
}