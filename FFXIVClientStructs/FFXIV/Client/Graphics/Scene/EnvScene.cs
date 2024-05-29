namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[StructLayout(LayoutKind.Explicit, Size = 0x790)]
[GenerateInterop]
public unsafe partial struct EnvScene {
    [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray32<byte> _weatherIds;

    [FieldOffset(0xB0), FixedSizeArray] internal FixedSizeArray8<EnvSpace> _envSpaces;
}
