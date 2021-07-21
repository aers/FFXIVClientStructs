using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Group
{
    // This is a guess, need to find the ctor/dtor
    [StructLayout(LayoutKind.Explicit, Size = 0x4C8)]
    public unsafe struct TrustManager
    {
        [FieldOffset(0x0)] public fixed byte TrustMembers[0x198 * 3]; // TrustMember type
    }
}
