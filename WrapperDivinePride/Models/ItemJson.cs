namespace WrapperDivinePride.Models;

public class ItemSet
{
    public int? ItemId { get; set; }
    public string Name { get; set; }
}

public class Set
{
    public string Name { get; set; }
    public List<ItemSet> Items { get; set; }
}

public class ItemSummonInfoContainedIn // examplo de velho album de cartas
{
    public int? SourceId { get; set; }
    public int? Chance { get; set; }
}

public class ItemMoveInfo
{
    public bool? Drop { get; set; }
    public bool? Trade { get; set; }
    public bool? Store { get; set; }
    public bool? Cart { get; set; }
    public bool? Sell { get; set; }
    public bool? Mail { get; set; }
    public bool? Auction { get; set; }
    public bool? GuildStore { get; set; }
}

public class ItemJson
{
    public int? ClassNum { get; set; }
    public List<Set> Sets { get; set; }
    public List<object?> SoldBy { get; set; }
    public int? Id { get; set; }
    public string AegisName { get; set; }
    public string FlavorText { get; set; }
    public string Name { get; set; }
    public string UnidName { get; set; }
    // public string ResName { get; set; }
    public string UnidResName { get; set; }
    public string Description { get; set; }
    public string UnidDescription { get; set; }
    public int? Slots { get; set; }
    public string Setname { get; set; }
    public int? ItemTypeId { get; set; }
    public int? ItemSubTypeId { get; set; }
    public List<ItemSummonInfoContainedIn> ItemSummonInfoContainedIn { get; set; }
    public List<ItemSummonInfoContainedIn> ItemSummonInfoContains { get; set; }
    public int? Attack { get; set; }
    public int? Defense { get; set; }
    public double? Weight { get; set; }
    public int? RequiredLevel { get; set; }
    public int? LimitLevel { get; set; }
    public int? ItemLevel { get; set; }
    public int? Job { get; set; }
    public object? CompositionPos { get; set; }
    public int? Attribute { get; set; }
    public object? Location { get; set; }
    public int? LocationId { get; set; }
    public int? Accessory { get; set; }
    public int? Price { get; set; }
    public int? Range { get; set; }
    public int? Matk { get; set; }
    public int? Gender { get; set; }
    public bool? Refinable { get; set; }
    public bool? Indestructible { get; set; }
    public ItemMoveInfo ItemMoveInfo { get; set; }
    public List<object?>? RewardForAchievement { get; set; }
    public string CardPrefix { get; set; }
    public List<object?>? Pets { get; set; }
    public bool? HasScript { get; set; }
}