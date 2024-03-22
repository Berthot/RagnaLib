namespace WrapperDivinePride.Dicts;

public class RaceDict
{
    public static Dictionary<int, int> Get()
    {
        var ints = new Dictionary<int, int>();
        ints.Add(0, 1);
        ints.Add(1, 0);
        ints.Add(2, 1);
        ints.Add(3, 2);
        ints.Add(4, 3);
        ints.Add(5, 4);
        ints.Add(6, 5);
        ints.Add(7, 6);
        ints.Add(8, 7);
        ints.Add(9, 8);
        ints.Add(10, 9);
        return ints;
    }
}