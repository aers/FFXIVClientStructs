using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Group
{
    [StructLayout(LayoutKind.Explicit, Size = 0x198)]
    public unsafe struct TrustMember
    {
        [FieldOffset(0x0)] public uint ObjectID;
    }
}
