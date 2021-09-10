using System.Runtime.InteropServices;
using FFXIVClientStructs.Common;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Client.UI.Shell;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::UIModule
    //   Client::UI::UIModuleInterface
    [StructLayout(LayoutKind.Explicit, Size = 0xE2070)]
    public unsafe partial struct UIModule
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x0)] public void** vfunc;
        [FieldOffset(0x8)] public Unk1 UnkObj1;
        [FieldOffset(0x10)] public Unk2 UnkObj2;
        [FieldOffset(0x18)] public Unk3 UnkObj3;
        [FieldOffset(0x20)] public void* unk;
        [FieldOffset(0x28)] public void* SystemConfig;

        [FieldOffset(0xB7FC0)] public RaptureAtkModule RaptureAtkModule; // note: NOT a pointer, the module's a member

        /*
            dq 0                                    ; +0x30
            dq 23000000000h                         ; +0x38
            dq 0                                    ; +0x40
            dq 23000000000h                         ; +0x48
            dq 0                                    ; +0x50
            and so on...
         */

        [VirtualFunction(6)]
        public partial RaptureTextModule* GetRaptureTextModule();

        [VirtualFunction(7)]
        public partial RaptureAtkModule* GetRaptureAtkModule();
        
        [VirtualFunction(9)]
        public partial RaptureShellModule* GetRaptureShellModule();

        [VirtualFunction(10)]
        public partial PronounModule* GetPronounModule();

        [VirtualFunction(11)]
        public partial RaptureLogModule* GetRaptureLogModule();

        [VirtualFunction(12)]
        public partial RaptureMacroModule* GetRaptureMacroModule();

        [VirtualFunction(18)]
        public partial ConfigModule* GetConfigModule();

        [VirtualFunction(34)]
        public partial AgentModule* GetAgentModule();

        [VirtualFunction(36)]
        public partial UI3DModule* GetUI3DModule();
        
        [StructLayout(LayoutKind.Explicit, Size = 0x8)]
        public struct Unk1
        {
            [FieldOffset(0x0)] public void* vtbl;
            [FieldOffset(0x0)] public void** vfunc;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x8)]
        public struct Unk2
        {
            [FieldOffset(0x0)] public void* vtbl;
            [FieldOffset(0x0)] public void** vfunc;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x8)] // size?
        public struct Unk3
        {
            [FieldOffset(0x0)] public void* vtbl;
            [FieldOffset(0x0)] public void** vfunc;
        }
    }
}
