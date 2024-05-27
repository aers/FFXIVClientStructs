using System.Runtime.CompilerServices;
using FFXIVClientStructs.STD;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.StdContainerTester;

public static class MapTester {
    public static void Test() {
        using (var map = new StdMap<int, int>()) {
            for (var i = 1; i <= 16; i++)
                map[i] = i;
            map[1] = 3;
            map[2] = 4;
            map[1] = 5;
            map.Remove(5);
            Console.WriteLine(string.Join(", ", map.Select(x => x.ToString())));
        }

        using (var map = new StdMap<StdWString, StdWString>()) {
            using var key = new StdWString();
            using var value = new StdWString();
            key.AddString("k1");
            value.AddString("v1");
            map.TryAddValueKMoveVMove(ref Unsafe.AsRef(in key), ref Unsafe.AsRef(in value));

            key.AddString("k2");
            value.AddString("v2");
            map.TryAddValueKMoveVMove(ref Unsafe.AsRef(in key), ref Unsafe.AsRef(in value));

            key.AddString("k1");
            value.AddString("aaaaaaaaaaaaaaaa");
            StdOps<StdWString>.Swap(ref map[key], ref Unsafe.AsRef(in value));

            Console.WriteLine(string.Join(", ", map.Select(x => x.ToString())));
        }

        using (var map = new StdMap<StdWString, StdWString>()) {
            using var key = new StdWString();
            using var value = new StdWString();
            key.AddString("k1");
            value.AddString("v1");
            map.TryAddValueKMoveVMove(ref Unsafe.AsRef(in key), ref Unsafe.AsRef(in value));

            key.AddString("k2");
            value.AddString("v2");
            map.TryAddValueKMoveVMove(ref Unsafe.AsRef(in key), ref Unsafe.AsRef(in value));

            key.AddString("k1");
            value.AddString("aaaaaaaaaaaaaaaa");
            StdOps<StdWString>.Swap(ref map[key], ref Unsafe.AsRef(in value));

            Console.WriteLine(string.Join(", ", map.Select(x => x.ToString())));
        }
    }
}
