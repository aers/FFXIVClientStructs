namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe struct EnvSpace {
    [FieldOffset(0x00)] public DrawObject DrawObject;
    [FieldOffset(0xB0)] public EnvLocation* EnvLocation;
}
