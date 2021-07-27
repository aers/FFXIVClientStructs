using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info
{
    [StructLayout(LayoutKind.Explicit, Size = 0x12D8)]
    public unsafe struct InfoProxyCrossRealm
    {
        [FieldOffset(0x0)] public void* Vtbl;

          // memset((void *)(a1 + 0x30),  0, 0x358ui64);
          // memset((void *)(a1 + 0x3A0), 0, 0xF30ui64);

        [FieldOffset(0x390)] public byte Unk390;
        [FieldOffset(0x391)] public byte Unk391;
        [FieldOffset(0x392)] public byte Unk392;
        [FieldOffset(0x393)] public byte Unk393;
    }
}
