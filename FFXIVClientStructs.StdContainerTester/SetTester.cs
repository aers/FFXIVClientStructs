using FFXIVClientStructs.STD;

namespace FFXIVClientStructs.StdContainerTester;

public static class SetTester {
    public static void Test() {
        using var set1 = new StdSet<int>();
        for (var i = 1; i <= 8; i++)
            set1.AddCopy(i);
        for (var i = 4; i <= 12; i++)
            set1.AddCopy(i);

        for (var i = 6; i <= 10; i++)
            set1.Remove(i);
        for (var i = 6; i <= 10; i++)
            set1.Remove(i);

        Console.WriteLine(string.Join(", ", set1.ToArrayReverse().Select(x => x.ToString())));

        using var set2 = new StdSet<int>();
        for (var i = 8; i < 16; i++)
            set2.AddCopy(i);

        Console.WriteLine("Set 1: " + string.Join(", ", set1.Select(x => x.ToString())));
        Console.WriteLine("Set 2: " + string.Join(", ", set2.Select(x => x.ToString())));

        using var set3 = new StdSet<int>();
        set3.UnionWith(set1);
        set3.UnionWith(set2);
        Console.WriteLine(string.Join(", ", set3.Select(x => x.ToString())));

        set3.Clear();
        set3.UnionWith(set1);
        set3.IntersectWith(set2);
        Console.WriteLine(string.Join(", ", set3.Select(x => x.ToString())));

        set3.Clear();
        set3.UnionWith(set1);
        set3.ExceptWith(set2);
        Console.WriteLine(string.Join(", ", set3.Select(x => x.ToString())));

        set3.Clear();
        set3.UnionWith(set1);
        set3.SymmetricExceptWith(set2);
        Console.WriteLine(string.Join(", ", set3.Select(x => x.ToString())));

        using var set4 = new StdSet<StdWString>();
        using var ts = new StdWString();
        ts.AddString("test1");
        set4.AddCopy(ts);
        ts.Clear();
        ts.AddString("test2");
        set4.AddCopy(ts);
        ts.Clear();
        ts.AddString("test1");
        Console.WriteLine(set4.Contains(ts));
        ts.AddString("aaa");
        Console.WriteLine(set4.Contains(ts));
        Console.WriteLine(string.Join(", ", set4.Select(x => x.ToString())));
    }
}
