namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x188)]
public unsafe partial struct StatusManager
{
    // This field is often null and cannot be relied on to retrieve the owning Character object
    [FieldOffset(0x0)] public Character.Character* Owner;
    [FieldOffset(0x8)] public fixed byte Status[0xC * 30]; // Client::Game::Status array
    [FieldOffset(0x170)] public uint Unk_170;
    [FieldOffset(0x174)] public ushort Unk_174;
    [FieldOffset(0x178)] public long Unk_178;
    [FieldOffset(0x180)] public byte Unk_180;

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 74 B7")]
    public partial bool HasStatus(uint statusId, uint sourceId = 0xE0000000);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 79 ?? 48 8B 15")]
    public partial int GetStatusIndex(uint statusId, uint sourceId = 0xE0000000);

    [MemberFunction("83 FA 1E 72 04 0F 57 C0")]
    public partial float GetRemainingTime(int statusIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 3D ?? ?? ?? ?? 74 45")]
    public partial uint GetStatusId(int statusIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 3B 44 24 28")]
    public partial uint GetSourceId(int statusIndex);
}