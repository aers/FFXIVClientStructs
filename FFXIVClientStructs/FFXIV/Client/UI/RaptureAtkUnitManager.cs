using FFXIVClientStructs.FFXIV.Component.GUI;
using AtkEventInterface = FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface.AtkEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::RaptureAtkUnitManager
//   Component::GUI::AtkUnitManager
//     Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkUnitManager>]
[VirtualTable("C6 83 ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 C7 83", 10, 43)]
[StructLayout(LayoutKind.Explicit, Size = 0x9D30)]
public unsafe partial struct RaptureAtkUnitManager {
    public static RaptureAtkUnitManager* Instance() {
        var raptureAtkModule = RaptureAtkModule.Instance();
        return raptureAtkModule == null ? null : &raptureAtkModule->RaptureAtkUnitManager;
    }

    [FieldOffset(0x9CA0)] public AtkEventInterface WindowContextMenuHandler;

    [FieldOffset(0x9D10)] public UiFlags UiFlags;

    [FieldOffset(0x9D21)] public bool IsEditingHudLayout;

    [FieldOffset(0x9D24)] public bool IsUiFading; // true whenever FadeMiddleBack is active

    /// <summary>
    /// This function initializes an addon after its allocation and constructor.<br/>
    /// It sets its initial AtkValues, name, optionally updates the <see cref="HudAnchoringTable"/>, and besides some other things it calls <see cref="AtkUnitBase.Initialize"/>.
    /// </summary>
    /// <param name="addon">A pointer to the variable that holds a pointer to an AtkUnitBase.</param>
    /// <param name="addonName">Name of the Addon.</param>
    /// <param name="valueCount">Number of initial AtkValues.</param>
    /// <param name="values">The initial AtkValues.</param>
    /// <returns><see langword="true"/> if initialized with non-zero AtkUnitBase id, <see langword="false"/> otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 45 9F 48 8D 7D 17")]
    public partial bool InitializeAddon(AtkUnitBase** addon, CStringPointer addonName, uint valueCount, AtkValue* values);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 75 ?? 8B D3")]
    public partial AtkUnitBase* GetAddonByNameHash(uint addonNameHash);
}
