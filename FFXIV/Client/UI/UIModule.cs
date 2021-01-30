using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::UIModule
    //   Client::UI::UIModuleInterface
    [StructLayout(LayoutKind.Explicit, Size = 0xDE750)]
    public unsafe struct UIModule
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x0)] public void** vfunc;
        [FieldOffset(0x8)] public Unk1 UnkObj1;
        [FieldOffset(0x10)] public Unk2 UnkObj2;
        [FieldOffset(0x18)] public Unk3 UnkObj3;
        [FieldOffset(0x20)] public void* unk;
        [FieldOffset(0x28)] public void* SystemConfig;

        [FieldOffset(0xB47D0)] public RaptureAtkModule RaptureAtkModule; // note: NOT a pointer, the module's a member

        /*
            dq 0                                    ; +0x30
            dq 23000000000h                         ; +0x38
            dq 0                                    ; +0x40
            dq 23000000000h                         ; +0x48
            dq 0                                    ; +0x50
            and so on...
         */

        [StructLayout(LayoutKind.Explicit, Size = 0x8)]
        public unsafe struct Unk1
        {
            [FieldOffset(0x0)] public void* vtbl;
            [FieldOffset(0x0)] public void** vfunc;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x8)]
        public unsafe struct Unk2
        {
            [FieldOffset(0x0)] public void* vtbl;
            [FieldOffset(0x0)] public void** vfunc;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x8)]  // size?
        public unsafe struct Unk3
        {
            [FieldOffset(0x0)] public void* vtbl;
            [FieldOffset(0x0)] public void** vfunc;
        }
    }
}
