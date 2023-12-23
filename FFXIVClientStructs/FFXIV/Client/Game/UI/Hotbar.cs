namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 8B D9 48 89 01 48 81 C1 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? C6 83", 3)]
public unsafe partial struct Hotbar {
    [FieldOffset(0x0)] public void* vtbl;

    [MemberFunction("48 83 EC 38 33 D2 C7 44 24 ?? ?? ?? ?? ?? 45 33 C9")]
    public partial void CancelCast();
}
