using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.Interop;

public unsafe ref struct RentedAtkValues : IDisposable {
    public AtkValue* Pointer;
    public Span<AtkValue> Span;

    public RentedAtkValues(int count) {
        Pointer = (AtkValue*)MemoryPool.Alloc((ulong)(sizeof(AtkValue) * count));
        Span = new Span<AtkValue>(Pointer, count);
        Span.Clear();
    }

    public void Dispose() {
        if (Pointer == null) return;

        foreach (var value in Span)
            value.Dtor();

        MemoryPool.Free(Pointer);
        Pointer = null;
        Span = [];
    }

    public ref AtkValue this[int index] => ref Span[index];

    public static implicit operator AtkValue*(RentedAtkValues rented) => rented.Pointer;
}
