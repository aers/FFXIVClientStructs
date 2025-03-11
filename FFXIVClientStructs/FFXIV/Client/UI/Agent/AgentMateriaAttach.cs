namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMateriaAttach
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MateriaAttach)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct AgentMateriaAttach {
    [FieldOffset(0xD0)] public FilterItems* Context;
    [FieldOffset(0xDC)] public uint StateVar; // internal only
    [FieldOffset(0xE0)] public uint AddonIdAttachDialog;
    [FieldOffset(0xEC)] public FilterCategory ActiveFilter;
    [FieldOffset(0xF0)] public short ItemCount;
    [FieldOffset(0xF2)] public short MateriaCount;
    [FieldOffset(0xF4)] public short SelectedItem; // index
    [FieldOffset(0xF6)] public short SelectedMateria; // index
    [FieldOffset(0xF8)] public short HoveredItem; // index
    [FieldOffset(0xFA)] public short HoveredMateria; // index
    [FieldOffset(0x124)] public uint MeldCostGil;

    public enum FilterCategory : int {
        None = -1,
        Inventory = 0,
        ArmouryWeapon = 1,
        ArmouryHeadBodyHands = 2,
        ArmouryLegsFeet = 3,
        ArmouryNeckEars = 4,
        ArmouryWristRing = 5,
        Equipped = 6
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xB8)]
    public unsafe partial struct FilterItems {
        [FieldOffset(0x98)] public Game.InventoryItem*** Items; // length determined by ItemCount on parent
        [FieldOffset(0xA0)] public Game.InventoryItem*** Materia; // length determined by MateriaCount on parent
    }
}
