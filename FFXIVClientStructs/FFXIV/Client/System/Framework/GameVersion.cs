namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

// Allocates a lot of space for inlined array, even though it only uses 5 strings.
[StructLayout(LayoutKind.Explicit, Size = 0x900)]
[GenerateInterop]
public unsafe partial struct GameVersion {
    [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _base;
    // Big unused gap between base and expansions

    [FieldOffset(0xE0), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _heavensward;
    [FieldOffset(0x100), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _stormblood;
    [FieldOffset(0x120), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _shadowbringers;
    [FieldOffset(0x140), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _endwalker;
    [FieldOffset(0x160), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _dawntrail;
}
