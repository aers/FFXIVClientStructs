using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent
{
    // Client::UI::Agent::AgentHUD
    //   Client::UI::Agent::AgentInterface
    //     Component::GUI::AtkModuleInterface::AtkEventInterface

    // size = 0x43A0
    // ctor E8 ? ? ? ? EB 03 49 8B C4 45 33 C9 48 89 46 40 
    [StructLayout(LayoutKind.Explicit, Size = 0x43A0)]
    public unsafe partial struct AgentHUD
    {
        [FieldOffset(0x0)] public AgentInterface AgentInterface;
        [FieldOffset(0x70)] public bool NeedToSave;

        [MemberFunction("48 85 D2 74 7F 48 89 5C 24")]
        public partial void OpenContextMenuFromTarget(GameObject* gameObject);
    }
}
