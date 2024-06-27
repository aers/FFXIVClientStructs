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

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 1D 48 8B 0B"), GenerateStringOverloads]
    public partial ushort InitializeAddon(AtkUnitBase* addon, byte* addonName);
}
