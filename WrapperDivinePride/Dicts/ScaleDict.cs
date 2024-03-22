namespace WrapperDivinePride.Dicts;

public class ScaleDict
{
    public static Dictionary<int, int> Get()
    {
        return new Dictionary<int, int>()
        {
            { 0, 0 },
            { 1, 0 },
            { 2, 1 },
            { 3, 2 },
        };
    }
}