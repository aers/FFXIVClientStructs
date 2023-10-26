using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct RaptureAtkHistory {
    // this stuff seems like some sort of cursed circular buffer kind of thing
    //[FieldOffset(0x08)] public void** Unk08; // points to a pointer to itself?
    // these names don't really fit, just didn't come up with better ones yet
    [FieldOffset(0x10)] public Utf8String** Entries;
    [FieldOffset(0x18)] public long Tail;
    [FieldOffset(0x20)] public long Head;
    [FieldOffset(0x28)] public long Length;
    [FieldOffset(0x30)] public int Current;

    // math from the GetCurrent funcs
    public int CurrentEntryIndex => Current < 0 ? -1 : (int)(Head + Current & (Tail - 1));

    [VirtualFunction(1)]
    public partial bool Previous();

    [VirtualFunction(2)]
    public partial bool Next();

    [VirtualFunction(3)]
    public partial void Reset();

    [VirtualFunction(4)]
    public partial Utf8String* GetCurrent(); // StringLength not set but trimmed to StringLength of the other entry

    [VirtualFunction(5)]
    public partial Utf8String* GetCurrent2(); // a copy of the other entry but with StringLength set and used
}
