namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public partial struct Hotbar
{
    [MemberFunction("48 83 EC 38 33 D2 C7 44 24 ?? ?? ?? ?? ?? 45 33 C9")]
    public partial void CancelCast();
}