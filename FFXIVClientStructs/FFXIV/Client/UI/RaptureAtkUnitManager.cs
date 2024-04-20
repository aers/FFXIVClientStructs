using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;
// Client::UI::RaptureAtkUnitManager
//   Component::GUI::AtkUnitManager
//     Component::GUI::AtkEventListener

// ctor "40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 48 8D 8B"
[VTableAddress("48 8D 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 05", 10)]
[StructLayout(LayoutKind.Explicit, Size = 0x9D18)]
public unsafe partial struct RaptureAtkUnitManager {
    public static RaptureAtkUnitManager* Instance() => &RaptureAtkModule.Instance()->RaptureAtkUnitManager;

    [FieldOffset(0x0)] public AtkUnitManager AtkUnitManager;

    [FieldOffset(0x9C88), Obsolete("Use AtkUnitManager.Flags instead")] public RaptureAtkModuleFlags Flags;
    [FieldOffset(0x9C90), Obsolete("Renamed to WindowContextMenuHandler")] public AtkEventInterface AtkEventInterface;
    [FieldOffset(0x9C90)] public AtkEventInterface WindowContextMenuHandler;

    [FieldOffset(0x9D00)] public UIModule.UiFlags UiFlags;

    [FieldOffset(0x9D14)] public bool IsUiFading; // true whenever FadeMiddleBack is active

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 41 B0 01")]
    [GenerateCStrOverloads]
    public partial AtkUnitBase* GetAddonByName(byte* name, int index = 1);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 6B 20")]
    public partial AtkUnitBase* GetAddonById(ushort id);

    [VirtualFunction(8)]
    public partial bool ShowAddonByID(ushort addonId, bool show); // True calls AtkUnitBase.Show, False calls AtkUnitBase.Hide

    [VirtualFunction(11)]
    public partial void UpdateAddonByID(ushort addonId, NumberArrayData** numberArrayData, StringArrayData** stringArrayData, bool forced);
}
