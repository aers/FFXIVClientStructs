namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMinionMountBase
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop(isInherited: true)]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe partial struct AgentMinionMountBase {
    [FieldOffset(0x40)] public AddonMinionMountBase.ViewType ViewType;

    [FieldOffset(0x50)] public SelectionData FavoritesSelection;
    [FieldOffset(0x5C)] public SelectionData NormalSelection;
    [FieldOffset(0x68)] public SelectionData SearchSelection;

    [FieldOffset(0x78)] public SelectionData* CurrentSelection;

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct SelectionData {
        [FieldOffset(0x00)] public uint Id;
        [FieldOffset(0x04)] public uint Page;
        [FieldOffset(0x08)] public uint Index;
    }
}
