using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::CharaView
[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
public unsafe partial struct CharaView
{
    [FieldOffset(0x0)] public void** VTable;


    [FieldOffset(0x008)] public uint Unk8;
    [FieldOffset(0x00C)] public uint CutsceneActorIndex; // 40 to 47
    [FieldOffset(0x010)] public uint ScreenActorIndex;   // 0 to 7, not 240 to 247
    [FieldOffset(0x014)] public uint Unk14;
    [FieldOffset(0x020)] public void* Unk20;
    [FieldOffset(0x028)] public Camera* Camera;

    [FieldOffset(0x0C0)] public uint UnkC0;
    [FieldOffset(0x030)] public ulong Unk30;
    [FieldOffset(0x038)] public ulong Unk38;

    [FieldOffset(0x0D0)] public UnkStruct UnkD0;
    [FieldOffset(0x0E0), Obsolete("Not valid", true)] public UnkStruct UnkE0;
    [FieldOffset(0x0F0)] public UnkStruct UnkF0;
    [FieldOffset(0x100), Obsolete("Not valid", true)] public UnkStruct Unk100;
    [FieldOffset(0x110)] public UnkStruct Unk110;
    [FieldOffset(0x120), Obsolete("Not valid", true)] public UnkStruct Unk120;
    [FieldOffset(0x130)] public UnkStruct Unk130;
    [FieldOffset(0x140), Obsolete("Not valid", true)] public UnkStruct Unk140;
    [FieldOffset(0x150)] public UnkStruct Unk150;
    [FieldOffset(0x160), Obsolete("Not valid", true)] public UnkStruct Unk160;
    [FieldOffset(0x170)] public UnkStruct Unk170;
    [FieldOffset(0x180), Obsolete("Not valid", true)] public UnkStruct Unk180;
    [FieldOffset(0x190)] public UnkStruct Unk190;
    [FieldOffset(0x1A0), Obsolete("Not valid", true)] public UnkStruct Unk1A0;

    [FieldOffset(0x2B8)] public ushort Unk2B8;
    [FieldOffset(0x290)] public ulong Unk290;
    [FieldOffset(0x298)] public ulong Unk298;
    [FieldOffset(0x2A0)] public ulong Unk2A0;
    [FieldOffset(0x2A8)] public ulong Unk2A8;
    [FieldOffset(0x2B0)] public ulong Unk2B0;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct UnkStruct // related to equipped/glamoured items
    {
        [FieldOffset(0x00)] public ushort Unk0;
        [FieldOffset(0x03)] public byte Unk1;
        [FieldOffset(0x04)] public byte Unk2;
        [FieldOffset(0x08)] public ulong Unk3; // ItemID
        [FieldOffset(0x10)] public ulong Unk4;
        [FieldOffset(0x18)] public ulong Unk5;
    }
}
