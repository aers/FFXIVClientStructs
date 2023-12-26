using FFXIVClientStructs.STD;

namespace FFXIVClientStructs.StdContainerTester;

public static class StringTester {
    public static void Test() {
        using var test1 = new StdString();
        test1.AddString("12345");
        Console.WriteLine(test1);
        test1.AddSpanCopy("abcde"u8);
        Console.WriteLine(test1);
        test1.RemoveRange(3, 5);
        Console.WriteLine(test1);
        test1.AddString("long string asdfasdfasdfasdfasdfdsdfdsfsasdfsafdffds");
        Console.WriteLine(test1);
        test1.RemoveRange(5, 2);
        Console.WriteLine(test1);
        var off = test1.LongCount;
        while (true) {
            off = test1.LongLastIndexOf((byte)'s', off - 1);
            if (off == -1)
                break;
            test1[off] = (byte)'x';
        }
        test1.Remove((byte)'x');
        Console.WriteLine(test1);
        
        off = test1.LongCount;
        while (true) {
            off = test1.LongLastIndexOf((byte)'d', off - 1);
            if (off == -1)
                break;
            test1[off] = (byte)'y';
        }
        test1.Remove((byte)'y');
        Console.WriteLine(test1);
        
        test1.InsertString(3, "AAAAAAA");
        Console.WriteLine(test1);
        
        test1.RemoveAll(x => (char)x is 'x' or 'y');
        test1.AddCopy((byte)'_');
        Console.WriteLine(test1);

        test1.Clear();
        test1.AddString("テスト");
        Console.WriteLine(test1);
        
        test1.TrimExcess();
        test1.AddString("테스트");
        Console.WriteLine(test1);
        
        test1.AddString("氣気气");
        Console.WriteLine(test1);
        
        test1.InsertString(4, "test");
        test1.InsertString(test1.LongCount - 4, "test");
        Console.WriteLine(test1);
        Console.WriteLine(test1.ContainsString("스트"));
        Console.WriteLine(test1.IndexOfString("test"));
        Console.WriteLine(test1.LastIndexOfString("test"));
    }
}
