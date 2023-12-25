using FFXIVClientStructs.STD;

namespace FFXIVClientStructs.StdContainerTester;

public static class VectorTester {
    private static readonly Random Rnd = new Random();

    public static void Test() {
        using (var testByteVector = new StdVector<byte>()) {
            for (var i = 0; i < 64; i++)
                testByteVector.Add((byte)i);
            testByteVector.Dump();
            foreach (ref var x in testByteVector)
                x ^= 0xFF;
            testByteVector.Dump();
            testByteVector.InsertRange(32, testByteVector);
            testByteVector.Dump();
            testByteVector.RemoveRange(64, 32);
            testByteVector.Dump();
            Console.WriteLine(testByteVector.Contains(16));
            Console.WriteLine(testByteVector.Contains(96));
            testByteVector.Reverse(4, testByteVector.LongCount - 4);
            testByteVector.Dump();
            testByteVector.Sort(4, testByteVector.LongCount - 4);
            testByteVector.Dump();
            using (var nrv = NewRandomVector(32, _ => (byte)Rnd.NextInt64()))
                testByteVector.AddRange(nrv);
            testByteVector.Dump();
            testByteVector.Clear();
            testByteVector.Resize(32);
            testByteVector.Resize(64, 0);
            testByteVector.Resize(96, 0xFF);
            testByteVector.Dump();

            try {
                _ = testByteVector[testByteVector.LongCount];
                Console.WriteLine("Fail");
            } catch {
                // ignored
            }
        }

        using var vecvec = new StdVector<StdVector<byte>>();
        vecvec.Add(NewRandomVector(64, _ => (byte)Rnd.NextInt64()));
        vecvec.Add(NewRandomVector(32, _ => (byte)Rnd.NextInt64()));
        vecvec[0].Sort();
        vecvec.AsSpan()[0].Dump();
        Console.WriteLine("index: " + vecvec[0].BinarySearch(127));
        Console.WriteLine("index: " + vecvec[0].AsSpan().BinarySearch((byte)127));
        Console.WriteLine("index: " + vecvec.AsSpan()[0].BinarySearch(127));
        vecvec.Dump();
    }
    
    public static StdVector<T> NewRandomVector<T>(long length, Func<long, T> valueGenerator)
        where T : unmanaged {
        var vec = new StdVector<T>();
        vec.EnsureCapacity(length);
        while (vec.LongCount < length)
            vec.Add(valueGenerator(vec.LongCount));
        return vec;
    }

    public static unsafe int Compare<T>(in StdVector<T> l, in StdVector<T> r) where T :unmanaged {
        var lv = l.First;
        var rv = r.First;
        while (lv < l.Last && rv < r.Last) {
            var cmp = Comparer<T>.Default.Compare(*lv, *rv);
            if (cmp != 0)
                return cmp;
        }

        return l.LongCount.CompareTo(r.LongCount);
    }

    public static void Dump<T>(in this StdVector<T> vec) where T : unmanaged {
        Console.Write($"Vector ({vec.LongCount:##,###}/{vec.LongCapacity:##,###})");
        var i = 0;
        foreach (ref var v in vec)
            Console.Write(i++ % 16 == 0 ? $"\n\t{v}, " : $"{v}, ");
        Console.WriteLine();
    }
}
