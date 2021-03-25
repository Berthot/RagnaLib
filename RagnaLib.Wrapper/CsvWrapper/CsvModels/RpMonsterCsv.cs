using CsvHelper.Configuration.Attributes;

namespace RagnaLib.Wrapper.CsvWrapper.CsvModels
{
    public class RpMonsterCsv
    {
        [Name("id")] public int Id { get; set; }
        [Name("id_element"), Optional] public int IdElement { get; set; }
        [Name("id_race"), Optional] public int IdRace { get; set; }
        [Name("id_scale"), Optional] public int IdScale { get; set; }
        [Name("dbname")] public string DbName { get; set; }
        [Name("name")] public string Name { get; set; }
        [Name("attackrange")] public int AttackRange { get; set; }
        [Name("level")] public int Level { get; set; }
        [Name("hp")] public int Hp { get; set; }
        [Name("sp")] public int Sp { get; set; }
        [Name("str")] public int Str { get; set; }
        [Name("int")] public int IntStatus { get; set; }
        [Name("vit")] public int Vit { get; set; }
        [Name("dex")] public int Dex { get; set; }
        [Name("agi")] public int Agi { get; set; }
        [Name("luk")] public int Luk { get; set; }
        [Name("rechargetime")] public int RechargeTime { get; set; }
        [Name("atk1")] public int Atk1 { get; set; }
        [Name("atk2")] public int Atk2 { get; set; }
        [Name("min_atk")] public int MinAtk { get; set; }
        [Name("max_atk")] public int MaxAtk { get; set; }
        [Name("min_atkm")] public int MinAtkm { get; set; }
        [Name("max_atkm")] public int MaxAtkm { get; set; }
        [Name("defense")] public int Defense { get; set; }
        [Name("baseexperience")] public int BaseExperience { get; set; }
        [Name("jobexperience")] public int JobExperience { get; set; }
        [Name("aggrorange")] public int AggroRange { get; set; }
        [Name("escaperange")] public int EscapeRange { get; set; }
        [Name("movementspeed")] public float MovementSpeed { get; set; }
        [Name("attackspeed")] public float AttackSpeed { get; set; }
        [Name("attackedspeed")] public float AttackedSpeed { get; set; }
        [Name("elementid")] public int ElementId { get; set; }
        [Name("scale")] public int Scale { get; set; }
        [Name("race")] public int Race { get; set; }
        [Name("magicdefense")] public int MagicDefense { get; set; }
        [Name("hit")] public int Hit { get; set; }
        [Name("flee")] public int Flee { get; set; }
        [Name("ai")] public string Ai { get; set; }
        [Name("mvp")] public int Mvp { get; set; }
        [Name("attr")] public int Attr { get; set; }
        [Name("slave")] public string Slave { get; set; }
        [Name("metarmorphosis")] public string Metarmorphosis { get; set; }
        [Name("drop")] public string Drop { get; set; }
        [Name("mvpdrop")] public string MvpDrop { get; set; }
        [Name("spawn")] public string Spawn { get; set; }
    }
}