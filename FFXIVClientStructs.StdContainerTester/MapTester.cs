using FFXIVClientStructs.STD;

namespace FFXIVClientStructs.StdContainerTester;

public static class MapTester {
    public static void Test() {
        var map = new StdMap<int, int>();
        try {
            map[1] = 3;
            map[2] = 4;
            map[1] = 5;
            var test = map.ToArray();
        } finally {
            map.Dispose();
        }
    }
}
