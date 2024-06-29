using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGatheringMasterpiece
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GatheringMasterpiece")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
public unsafe partial struct AddonGatheringMasterpiece {
    [FieldOffset(0x398)] public AtkComponentDragDrop* CollectDragDrop;
}
