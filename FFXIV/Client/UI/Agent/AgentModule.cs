using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent {
    // Client::UI::Agent::AgentModule

    // size = 0xC08
    // ctor E8 ? ? ? ? 48 8B 85 ? ? ? ? 49 8B CF 48 89 87
    [StructLayout(LayoutKind.Explicit, Size = 0xC08)]
    public unsafe struct AgentModule 
    {
        [FieldOffset(0x0)] public void** vtbl;
        [FieldOffset(0x8)] public UIModule* UIModule;
        [FieldOffset(0x10)] public byte Initialized;
        [FieldOffset(0x11)] public byte UnkByte11;
        [FieldOffset(0x14)] public uint FrameCounter;
        [FieldOffset(0x18)] public float FrameDelta;
        [FieldOffset(0x20)] public AgentInterface* AgentArray; // 379 elements, patch 5.45
        // those 2 seem redundant
        // [FieldOffset(0xBF8)] public UIModule* UIModulePtr;
        // [FieldOffset(0xC00)] public AgentModule* AgentModulePtr;
    }
}