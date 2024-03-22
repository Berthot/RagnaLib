namespace RagnaLib.Wrapper.Models;

using System;
using System.Collections.Generic;

public class ItemJson
{
    public string ClassNum { get; set; }
    public List<SetJson> Sets { get; set; }
    public List<SoldByJson> SoldBy { get; set; }
    public string Id { get; set; }
    public string AegisName { get; set; }
    public string FlavorText { get; set; }
    public string Name { get; set; }
    public string UnidName { get; set; }
    public string ResName { get; set; }
    public string UnidResName { get; set; }
    public string Description { get; set; }
    public string UnidDescription { get; set; }
    public string Slots { get; set; }
    public string Setname { get; set; }
    public string ItemTypeId { get; set; }
    public string ItemSubTypeId { get; set; }
    public List<ItemSummonInfoContainedInJson> ItemSummonInfoContainedIn { get; set; }
    // public List<string> ItemSummonInfoContains { get; set; }
    public string? Attack { get; set; }
    public string? Defense { get; set; }
    public string Weight { get; set; }
    public string? RequiredLevel { get; set; }
    public string? LimitLevel { get; set; }
    public string? ItemLevel { get; set; }
    public string? Job { get; set; }
    public string CompositionPos { get; set; }
    public string Attribute { get; set; }
    public string Location { get; set; }
    public string LocationId { get; set; }
    public string Accessory { get; set; }
    public string Price { get; set; }
    public string? Range { get; set; }
    public string? Matk { get; set; }
    public string? Gender { get; set; }
    public bool? Refinable { get; set; }
    public bool? Indestructible { get; set; }
    public ItemMoveInfoJson ItemMoveInfo { get; set; }
    // public List<string> RewardForAchievement { get; set; }
    public string CardPrefix { get; set; }
    // public List<string?>? Pets { get; set; }
    public bool? HasScript { get; set; }
}

public class SetJson
{
    public string Name { get; set; }
    public List<ItemJson> Items { get; set; }
}

public class SoldByJson
{
}

public class ItemSummonInfoContainedInJson
{
    public string stringernalType { get; set; }
    public string Type { get; set; }
    public string SourceId { get; set; }
    public string SourceName { get; set; }
    public string TargetId { get; set; }
    public string TargetName { get; set; }
    public string Count { get; set; }
    public string TotalOfSource { get; set; }
    public string SummonType { get; set; }
    public string Chance { get; set; }
}

public class ItemMoveInfoJson
{
    public bool Drop { get; set; }
    public bool Trade { get; set; }
    public bool Store { get; set; }
    public bool Cart { get; set; }
    public bool Sell { get; set; }
    public bool Mail { get; set; }
    public bool Auction { get; set; }
    public bool GuildStore { get; set; }
}
