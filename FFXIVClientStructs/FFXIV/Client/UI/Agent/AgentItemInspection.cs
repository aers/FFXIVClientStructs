using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentItemInspection
//   Client::UI::Agent::AgentItemDetailBase
//     Client::UI::Agent::AgentInterface
//       Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ItemInspection)]
[GenerateInterop]
[Inherits<AgentItemDetailBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct AgentItemInspection {
    [FieldOffset(0x50)] public Data* InspectionData;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x668)]
    public partial struct Data {
        [FieldOffset(0x0)] public InventoryItem Item;
        [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray11<Utf8String> _unk50;
    }

    [MemberFunction("40 53 56 41 54 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B 01")]
    public partial void OpenResult(int a2, InventoryItem* item);
}
