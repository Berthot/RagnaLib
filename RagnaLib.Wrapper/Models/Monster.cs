using System.Collections.Generic;

namespace RagnaLib.Wrapper.Models;

public class MonsterJson
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string DbName { get; set; }
    public List<DropJson>? Drops { get; set; }
    public List<DropJson>? MvpDrops { get; set; }
    public Dictionary<string, int>? PropertyTable { get; set; }
    public List<SkillJson>? Skills { get; set; }
    public List<SlaveJson>? Slaves { get; set; }
    public List<SpawnJson>? Spawns { get; set; }
    public StatsJson? Stats { get; set; }
}

public class DropJson
{
    public string ItemId { get; set; }
    public string Chance { get; set; }
    public bool StealProtected { get; set; }
    public string ServerTypeName { get; set; }
    public string OptionGroup { get; set; }
}



public class SkillJson
{
    public string Idx { get; set; }
    public string SkillId { get; set; }
    public string Status { get; set; }
    public string Level { get; set; }
    public string Chance { get; set; }
    public string CastTime { get; set; }
    public string Delay { get; set; }
    public bool Interruptable { get; set; }
    public string ChangeTo { get; set; }
    public string Condition { get; set; }
    public string ConditionValue { get; set; }
    public string SendType { get; set; }
    public string SendValue { get; set; }
}

public class SlaveJson
{
    public string Id { get; set; }
    public string Idx { get; set; }
    public string Amount { get; set; }
}

public class SpawnJson
{
    public string MapName { get; set; }
    public string Amount { get; set; }
    public string RespawnTime { get; set; }
}

public class StatsJson
{
    public string AttackRange { get; set; }
    public string Level { get; set; }
    public string Health { get; set; }
    public string Sp { get; set; }
    public string Str { get; set; }
    public string Int { get; set; }
    public string Vit { get; set; }
    public string Dex { get; set; }
    public string Agi { get; set; }
    public string Luk { get; set; }
    public string RechargeTime { get; set; }
    public string Atk1 { get; set; }
    public string Atk2 { get; set; }
    public AttackJson Attack { get; set; }
    public AttackJson MagicAttack { get; set; }
    public string Defense { get; set; }
    public string BaseExperience { get; set; }
    public string JobExperience { get; set; }
    public string AggroRange { get; set; }
    public string EscapeRange { get; set; }
    public string MovementSpeed { get; set; }
    public string AttackSpeed { get; set; }
    public string AttackedSpeed { get; set; }
    public string Element { get; set; }
    public string Scale { get; set; }
    public string Race { get; set; }
    public string MagicDefense { get; set; }
    public string Hit { get; set; }
    public string Flee { get; set; }
    public string Ai { get; set; }
    public string Mvp { get; set; }
    public string Class { get; set; }
    public string Attr { get; set; }
    public string Res { get; set; }
    public string Mres { get; set; }
}

public class AttackJson
{
    public string Minimum { get; set; }
    public string Maximum { get; set; }
}