using FFXIVClientStructs.FFXIV.Component.GUI;
using FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI;
// Client::UI::RaptureAtkUnitManager
//   Component::GUI::AtkUnitManager
//     Component::GUI::AtkEventListener

// ctor "40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 48 8D 8B"
[GenerateInterop, Inherits<AtkUnitManager>]
[VirtualTable("48 8D 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 05", 10)]
[StructLayout(LayoutKind.Explicit, Size = 0x9D18)]
public unsafe partial struct RaptureAtkUnitManager {
    public static RaptureAtkUnitManager* Instance() => &RaptureAtkModule.Instance()->RaptureAtkUnitManager;

    [FieldOffset(0x9C90)] public AtkEventInterface WindowContextMenuHandler;

    [FieldOffset(0x9D00)] public UIModule.UiFlags UiFlags;

    [FieldOffset(0x9D14)] public bool IsUiFading; // true whenever FadeMiddleBack is active

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 41 B0 01"), GenerateStringOverloads]
    public partial AtkUnitBase* GetAddonByName(byte* name, int index = 1);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 6B 20")]
    public partial AtkUnitBase* GetAddonById(ushort id);

    [VirtualFunction(8)]
    public partial bool ShowAddonById(ushort addonId, bool show); // True calls AtkUnitBase.Show, False calls AtkUnitBase.Hide

    [VirtualFunction(10)]
    public partial void RefreshAddon(AtkUnitBase* addon, uint numValues, AtkValue* values);

    [VirtualFunction(11)]
    public partial void UpdateAddonById(ushort addonId, NumberArrayData** numberArrayData, StringArrayData** stringArrayData, bool forced);
}
