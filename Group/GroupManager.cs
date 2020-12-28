using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Group
{

    // there are actually two copies of this back to back in the exe
    // maybe for 48 man raid support since the group manager can only hold 1 alliance worth of party members
    [StructLayout(LayoutKind.Explicit, Size = 0x3D70)]
    public unsafe struct GroupManager
    {
        [FieldOffset(0x0)] public fixed byte PartyMembers[0x230 * 8]; // PartyMember type
    }
}
