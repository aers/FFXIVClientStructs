using FFXIVClientStructs.STD;

namespace FFXIVClientStructs.StdContainerTester;

public static class ListTester {
    public static unsafe void Test() {
        using (var list = new StdList<int>()) {
            for (var i = 0; i < 8; i++)
                list.AddLastCopy(i);
            for (var i = 16; i < 24; i++)
                list.AddFirstCopy(i);
            Console.WriteLine(string.Join(", ", list.ToArray().Select(x => x.ToString())));
            list.RemoveFirst();
            Console.WriteLine(string.Join(", ", list.ToArray().Select(x => x.ToString())));
            list.RemoveLast();
            Console.WriteLine(string.Join(", ", list.ToArray().Select(x => x.ToString())));
            list.Clear();
            Console.WriteLine(string.Join(", ", list.ToArray().Select(x => x.ToString())));
        }

        using (var list = new StdList<StdWString>()) {
            for (var i = 0; i < 16; i++) {
                ref var node = ref list.AddFirstDefault().Value->Value;
                node.AddString("Test");
                node.AddString(" ");
                node.AddString(i.ToString());
            }

            list.AddLastCopy(list.First.Value->Value);
            list.AddLastMove(ref list.First.Value->Next->Value);
            
            Console.WriteLine(string.Join(", ", list.ToArray().Select(x => x.ToString())));
        }
    }
}
