namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
[GenerateInterop]
[Inherits<DrawObject>]
public unsafe partial struct EnvSpace {
    [FieldOffset(0xB0)] public EnvLocation* EnvLocation;
}
