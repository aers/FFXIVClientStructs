namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[StructLayout(LayoutKind.Explicit, Size = 0x790)]
public unsafe partial struct EnvScene {
    [FieldOffset(0x2C), FixedSizeArray<byte>(32)] public fixed byte WeatherIds[32];

    [FieldOffset(0xB0), FixedSizeArray<EnvSpace>(8)] public fixed byte EnvSpaces[8 * 0xD0];
}
