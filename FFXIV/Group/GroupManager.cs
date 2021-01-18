using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Group
{

    // there are actually two copies of this back to back in the exe
    // maybe for 48 man raid support since the group manager can only hold 1 alliance worth of party members
    [StructLayout(LayoutKind.Explicit, Size = 0x3D70)]
    public unsafe struct GroupManager
    {
        [FieldOffset(0x0)] public fixed byte PartyMembers[0x230 * 8]; // PartyMember type
        // for some reason the alliance array is size 20. it used to be 16 in old versions.
        [FieldOffset(0x1180)] public fixed byte AllianceMembers[0x230 * 20]; // PartyMember type
        [FieldOffset(0x3D40)] public uint Unk_3D40;
        [FieldOffset(0x3D44)] public ushort Unk_3D44;
        [FieldOffset(0x3D48)] public long Unk_3D48;
        [FieldOffset(0x3D50)] public long Unk_3D50;
        [FieldOffset(0x3D58)] public uint PartyLeaderIndex; // index of party leader in array
        [FieldOffset(0x3D5C)] public byte MemberCount;
        [FieldOffset(0x3D5D)] public byte Unk_3D5D;
        [FieldOffset(0x3D5E)] public bool IsAlliance;
        [FieldOffset(0x3D5F)] public byte Unk_3D5F; // some sort of count
        [FieldOffset(0x3D60)] public byte Unk_3D60;
    }
}
