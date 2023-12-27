using FFXIVClientStructs.Interop;
using FFXIVClientStructs.STD;
using FFXIVClientStructs.STD.StdHelpers;

namespace FFXIVClientStructs.StdContainerTester;

public static unsafe class SetTester {
    public static void Test() {
        using var set1 = new StdSet<int, DefaultStaticMemorySpace>();
        for (var i = 1; i <= 8; i++)
            set1.AddCopy(i);
        for (var i = 4; i <= 12; i++)
            set1.AddCopy(i);

        for (var i = 6; i <= 10; i++)
            set1.Remove(i);
        for (var i = 6; i <= 10; i++)
            set1.Remove(i);

        DumpNodes(set1.Tree.Head);
        Console.WriteLine(string.Join(", ", set1.ToArrayReverse().Select(x => x.ToString())));

        using var set2 = new StdSet<int, DefaultStaticMemorySpace>();
        for (var i = 8; i < 16; i++)
            set2.AddCopy(i);
        
        Console.WriteLine("Set 1: " + string.Join(", ", set1.Select(x => x.ToString())));
        Console.WriteLine("Set 2: " + string.Join(", ", set2.Select(x => x.ToString())));

        using var set3 = new StdSet<int, DefaultStaticMemorySpace>();
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
    }

    private static void DumpNodes(Pointer<RedBlackTree<int, DefaultStaticMemorySpace>.Node> x) {
        var nodeNames = new Dictionary<Pointer<RedBlackTree<int, DefaultStaticMemorySpace>.Node>, int>();
        var q = new Queue<Pointer<RedBlackTree<int, DefaultStaticMemorySpace>.Node>>();
        q.Enqueue(x);
        while (q.TryDequeue(out x)) {
            if (!nodeNames.TryAdd(x, x.Value->_Myval))
                continue;
            if (!nodeNames.ContainsKey(x.Value->_Left))
                q.Enqueue(x.Value->_Left);
            if (!nodeNames.ContainsKey(x.Value->_Right))
                q.Enqueue(x.Value->_Right);
            if (!nodeNames.ContainsKey(x.Value->_Parent))
                q.Enqueue(x.Value->_Parent);
        }
        foreach (var (node, name) in nodeNames) {
            Console.WriteLine($"#{name}: {node.Value->_Myval} Nil={node.Value->_Isnil} Left={nodeNames[node.Value->_Left]} Right={nodeNames[node.Value->_Right]} Parent={nodeNames[node.Value->_Parent]}");
        }
    }
}
