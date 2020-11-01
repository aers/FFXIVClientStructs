using FFXIVClientStructs.Client.UI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    // probably belongs to something other than AtkStage 
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe struct TexHolder
    {
        [FieldOffset(0x0)] public uint TexPathHash; // crc32(full path)
        [FieldOffset(0x4)] public uint Unk_1; // defaults to 0xFFFFFFFF which is -1 so might be signed
        [FieldOffset(0x8)] public void* TexFileResourceHandle;
        [FieldOffset(0x10)] public void* Unk_2;
        [FieldOffset(0x18)] public ushort Unk_3;
        [FieldOffset(0x1A)] public ushort UseCount;
     }

    // Component::GUI::AtkStage
    //   Component::GUI::AtkEventTarget

    // size = 0x75DF8
    // ctor E8 ? ? ? ? 48 8B F8 48 89 BE ? ? ? ? 48 8B 43 10 
    [StructLayout(LayoutKind.Explicit, Size = 0x75DF8)]
    public unsafe struct AtkStage
    {
        [FieldOffset(0x0)] public AtkEventTarget AtkEventTarget;
        [FieldOffset(0x20)] public RaptureAtkUnitManager* RaptureAtkUnitManager;
    }
}
