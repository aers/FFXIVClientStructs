using System.Runtime.InteropServices;
using FFXIVClientStructs.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent
{
    // Client::UI::Agent::AgentModule

    // size = 0xC10
    // ctor E8 ? ? ? ? 48 8B 85 ? ? ? ? 49 8B CF 48 89 87
    [StructLayout(LayoutKind.Explicit, Size = 0xC10)]
    public unsafe partial struct AgentModule
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x8)] public UIModule* UIModule;
        [FieldOffset(0x10)] public byte Initialized;
        [FieldOffset(0x11)] public byte Unk_11;
        [FieldOffset(0x14)] public uint FrameCounter;
        [FieldOffset(0x18)] public float FrameDelta;

        [FieldOffset(0x20)] public AgentInterface* AgentArray; // 380 pointers patch 5.50
        // why are those 2 here, included for completeness
        // [FieldOffset(0xC00)] public UIModule* UIModulePtr;
        // [FieldOffset(0xC08)] public AgentModule* AgentModulePtr;

        [MemberFunction("E8 ?? ?? ?? ?? 83 FF 0D")]
        public partial AgentInterface* GetAgentByInternalID(uint agentID);
    }
}