namespace FFXIVClientStructs.FFXIV.Component.GUI;

// ctor E8 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 48 89 BE ?? ?? ?? ?? 48 8B C7 
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe struct AtkArrayDataHolder
{
    [FieldOffset(0x0)]
    public short NumberArrayCount; // these are total counts - some of the slots can be (and are) empty

    [FieldOffset(0x2)] public short StringArrayCount;
    [FieldOffset(0x4)] public short ExtendArrayCount;

    [FieldOffset(0x8)] public short*
        NumberArrayKeys; // this is an array counting up from 0 that seems to indicate which array data is in use, its 0xFFFF if they are empty

    [FieldOffset(0x10)]
    public NumberArrayData** _NumberArrays; // this array contains identical data to the one below(?)

    [FieldOffset(0x18)] public NumberArrayData** NumberArrays; // this array is whats actually passed to addons
    [FieldOffset(0x20)] public short* StringArrayKeys;
    [FieldOffset(0x28)] public StringArrayData** _StringArrays;
    [FieldOffset(0x30)] public StringArrayData** StringArrays;
    [FieldOffset(0x38)] public short* ExtendArrayKeys;
    [FieldOffset(0x40)] public ExtendArrayData** _ExtendArrays;
    [FieldOffset(0x48)] public ExtendArrayData** ExtendArrays;
}