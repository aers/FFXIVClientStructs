using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentTryon
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "48 89 5C 24 ?? 57 48 83 EC 20 48 8B F9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 4F 28 48 89 07 E8 ?? ?? ?? ?? 48 C7 87"
[Agent(AgentId.Tryon)]
[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 8D 4F 28 48 89 07 E8 ?? ?? ?? ?? 48 C7 87", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x670)]
public unsafe partial struct AgentTryon {
    [FieldOffset(0)] public AgentInterface AgentInterface;

    // you can ignore the openerAddonId in the call and just set it to 0
    [MemberFunction("E8 ?? ?? ?? ?? EB 56 48 8B 49 10")]
    public static partial bool TryOn(uint openerAddonId, uint itemId, byte stainId, uint glamourItemId, byte glamourStainId);
}
