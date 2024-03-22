using Domain.Entities;
using WrapperDivinePride.CsvWrapper;

namespace WrapperDivinePride.Wrappers;

public static class ResourcesRepository
{
    private static readonly ReadJson JsonReader = new ReadJson();

    public static List<Element> GetElements()
    {
        return JsonReader.ReadDynamicClass<Element>("ragnarok_public_Element");
    }

    public static List<ItemType> GetItemTypes()
    {
        return JsonReader.ReadDynamicClass<ItemType>("ragnarok_public_ItemType");
    }

    public static List<Race> GetRaces()
    {
        return JsonReader.ReadDynamicClass<Race>("ragnarok_public_Race");
    }

    public static List<SubType> GetSubTypes()
    {
        return JsonReader.ReadDynamicClass<SubType>("ragnarok_public_SubType");
    }

    public static List<EquipPosition> GetEquipPositions()
    {
        return JsonReader.ReadDynamicClass<EquipPosition>("ragnarok_public_EquipPosition");
    }

    public static List<Location> GetLocations()
    {
        return JsonReader.ReadDynamicClass<Location>("ragnarok_public_Location");
    }

    public static List<Scale> GetScales()
    {
        return JsonReader.ReadDynamicClass<Scale>("ragnarok_public_Scales");
    }

}