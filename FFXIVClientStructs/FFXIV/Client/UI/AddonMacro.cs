using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMacro
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Macro")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x30D0)]
public unsafe partial struct AddonMacro {
    [FieldOffset(0x2D0), FixedSizeArray] internal FixedSizeArray100<Pointer<AtkComponentDragDrop>> _dragDropComponent;

    /// <summary>
    /// Used when creating a new macro from a blank state.
    /// </summary>
    [FieldOffset(0x5F8)] public int DefaultIcon;


    /// <summary>
    /// Array of default icons, used when no macro icon command is used.
    /// </summary>
    [FieldOffset(0x604), FixedSizeArray] internal FixedSizeArray100<int> _macroSetIcon;

    [FieldOffset(0x798), FixedSizeArray] internal FixedSizeArray100<Utf8String> _macroName;

    [FieldOffset(0x3038), FixedSizeArray] internal FixedSizeArray100<bool> _macroCreated;

    /// <summary>
    /// Note: Value is only set when changing page.
    /// </summary>
    [FieldOffset(0x30BC)] public uint SelectedMacroIndex;
    [FieldOffset(0x30C0)] public uint SelectedPage;
}
