namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

[StructLayout(LayoutKind.Explicit, Size = 2)]
public struct ForayInfo {
    [FieldOffset(0x00)] public byte Level;
    [FieldOffset(0x01)] public byte Element;
}
