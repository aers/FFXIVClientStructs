using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMacro
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Macro")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x30C0)]
public unsafe partial struct AddonMacro {
    [FieldOffset(0x2C8), FixedSizeArray] internal FixedSizeArray100<Pointer<AtkComponentDragDrop>> _dragDropComponent;

    /// <summary>
    /// Used when creating a new macro from a blank state.
    /// </summary>
    [FieldOffset(0x5F0)] public int DefaultIcon;


    /// <summary>
    /// Array of default icons, used when no macro icon command is used.
    /// </summary>
    [FieldOffset(0x5FC), FixedSizeArray] internal FixedSizeArray100<int> _macroSetIcon;

    [FieldOffset(0x790), FixedSizeArray] internal FixedSizeArray100<Utf8String> _macroName;

    [FieldOffset(0x3030), FixedSizeArray] internal FixedSizeArray100<bool> _macroCreated;

    /// <summary>
    /// Note: Value is only set when changing page.
    /// </summary>
    [FieldOffset(0x30B4)] public uint SelectedMacroIndex;
    [FieldOffset(0x30B8)] public uint SelectedPage;
}
