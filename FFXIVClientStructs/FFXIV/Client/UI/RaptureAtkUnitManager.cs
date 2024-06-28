using FFXIVClientStructs.FFXIV.Component.GUI;
using AtkEventInterface = FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface.AtkEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::RaptureAtkUnitManager
//   Component::GUI::AtkUnitManager
//     Component::GUI::AtkEventListener
// ctor "40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 48 8D 8B"
[GenerateInterop]
[Inherits<AtkUnitManager>]
[VirtualTable("C6 83 ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 C7 83", 10)]
[StructLayout(LayoutKind.Explicit, Size = 0x9D18)]
public unsafe partial struct RaptureAtkUnitManager {
    public static RaptureAtkUnitManager* Instance() => &RaptureAtkModule.Instance()->RaptureAtkUnitManager;

    [FieldOffset(0x9C90)] public AtkEventInterface WindowContextMenuHandler;

    [FieldOffset(0x9D00)] public UIModule.UiFlags UiFlags;

    [FieldOffset(0x9D14)] public bool IsUiFading; // true whenever FadeMiddleBack is active

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 30 49 8B F0 48 8B FA 4C 8B F1 48 85 D2"), GenerateStringOverloads]
    public partial ushort InitializeAddon(AtkUnitBase* addon, byte* addonName); // 7.0: no xrefs/inlined, but callable
}
