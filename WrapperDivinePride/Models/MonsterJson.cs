namespace WrapperDivinePride.Models;

public class MonsterJson
{
    public int? Id { get; set; }
    public string? Dbname { get; set; }
    public string? Name { get; set; }
    public Stats Stats { get; set; }
    public List<Slave> Slaves { get; set; }
    public List<Drop> Drops { get; set; }
    public List<Mvpdrop> Mvpdrops { get; set; }
    public List<Spawn> Spawn { get; set; }
    public List<Skill> Skill { get; set; }
    public PropertyTable PropertyTable { get; set; }
}

public class Stats
{
    public int? AttackRange { get; set; }
    public int? Level { get; set; }
    public int? Health { get; set; }
    public int? Sp { get; set; }
    public int? Str { get; set; }
    public int? Int { get; set; }
    public int? Vit { get; set; }
    public int? Dex { get; set; }
    public int? Agi { get; set; }
    public int? Luk { get; set; }
    public int? RechargeTime { get; set; }
    public int? Atk1 { get; set; }
    public int? Atk2 { get; set; }
    public Attack Attack { get; set; }
    public MagicAttack MagicAttack { get; set; }
    public int? Defense { get; set; }
    public int? BaseExperience { get; set; }
    public int? JobExperience { get; set; }
    public int? AggroRange { get; set; }
    public int? EscapeRange { get; set; }
    public double? MovementSpeed { get; set; }
    public float? AttackSpeed { get; set; }
    public float? AttackedSpeed { get; set; }
    public int? Element { get; set; }
    public int? Scale { get; set; }
    public int? Race { get; set; }
    public int? MagicDefense { get; set; }
    public int? Hit { get; set; }
    public int? Flee { get; set; }
    public string? Ai { get; set; }
    public int? Mvp { get; set; }
    public int? Class { get; set; }
    public int? Attr { get; set; }
    public int? Res { get; set; }
    public int? Mres { get; set; }
}

public class Attack
{
    public int? Minimum { get; set; }
    public int? Maximum { get; set; }
}

public class MagicAttack
{
    public int? Minimum { get; set; }
    public int? Maximum { get; set; }
}

public class Slave
{
    public int? Id { get; set; }
    public int? Idx { get; set; }
    public int? Amount { get; set; }
}

public class Drop
{
    public int? ItemId { get; set; }
    public int? Chance { get; set; }
    public bool StealProtected { get; set; }
}

public class Mvpdrop
{
    public int? ItemId { get; set; }
    public int? Chance { get; set; }
    public bool StealProtected { get; set; }
}

public class Spawn
{
    public string? Mapname { get; set; }
    public int? Amount { get; set; }
    public int? RespawnTime { get; set; }
}

public class Skill
{
    public int? SkillId { get; set; }
}

public class PropertyTable
{
    public int? _0 { get; set; }
    public int? _1 { get; set; }
    public int? _2 { get; set; }
    public int? _3 { get; set; }
    public int? _4 { get; set; }
    public int? _5 { get; set; }
    public int? _6 { get; set; }
    public int? _7 { get; set; }
    public int? _8 { get; set; }
    public int? _9 { get; set; }
}