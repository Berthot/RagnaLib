using CsvHelper.Configuration.Attributes;

namespace RagnaLib.Wrapper.CsvWrapper.CsvModels
{
    public class RpItemCsv
    {
        [Name("id")] public string Id {get; set;}
        [Name("name")] public string Name {get; set;}
        [Name("aegisName")] public string AegisName { get; set; }
        [Name("price")] public string Price {get; set;}
        [Name("description")] public string Description {get; set;}
        [Name("equiplocation")] public string EquipLocation {get; set;}
        [Name("refinable")] public string Refinable {get; set;}
        [Name("ragnapriceitemtypeid")] public string RagnaPriceItemTypeId {get; set;}
        [Name("ragnapricesubitemtypeid")] public string RagnaPriceSubItemTypeId {get; set;}
        [Name("attack")] public string Attack {get; set;}
        [Name("magicattack")] public string MagicAttack {get; set;}
        [Name("requiredlevel")] public string RequiredLevel {get; set;}
        [Name("limitlevel")] public string LimitLevel {get; set;}
        [Name("itemlevel")] public string ItemLevel {get; set;}
        [Name("weight")] public string Weight {get; set;}
        [Name("defense")] public string Defense {get; set;}
        [Name("cardprefix")] public string CardPrefix {get; set;}
        [Name("slots")] public string Slots {get; set;}
        [Name("unidname")] public string UnidName {get; set;}
        [Name("itemMoveInfo")] public string ItemMoveInfo { get; set; }
        [Name("hasSet")] public string HasSet { get; set; }
        [Name("hasSoldBy")] public string HasSoldBy { get; set; }
        [Name("range")] public string Range { get; set; }
        [Name("indestructible")] public string Indestructible { get; set; }
        [Name("attribute")] public string Attribute { get; set; }
        [Name("locationId")] public string LocationId { get; set; }
        [Name("acessory")] public string Acessory { get; set; }
        [Name("compound_on")]public string CompoundOn { get; set; }
    }
}