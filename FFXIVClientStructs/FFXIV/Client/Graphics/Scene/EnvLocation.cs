namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe struct EnvLocation {
    [FieldOffset(0x00)] public DrawObject DrawObject;
}
