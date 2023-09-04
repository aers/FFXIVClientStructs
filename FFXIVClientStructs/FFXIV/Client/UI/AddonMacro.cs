using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// ctor
// 48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 89 03 E8 ?? ?? ?? ?? 45 33 F6 48 8D B3 ?? ?? ?? ?? BD
// size 0x30B0

[Addon("Macro")]
[StructLayout(LayoutKind.Explicit, Size = 0x30B0)]
public unsafe partial struct AddonMacro {
    [FieldOffset(0x0000)] public AtkUnitBase AtkUnitBase;

    [FixedSizeArray<Pointer<AtkComponentDragDrop>>(100)]
    [FieldOffset(0x2B8)] public fixed byte DragDropComponent[100 * 8];

    /// <summary>
    /// Used when creating a new macro from a blank state.
    /// </summary>
    [FieldOffset(0x5E0)] public int DefaultIcon;


    /// <summary>
    /// Array of default icons, used when no macro icon command is used.
    /// </summary>
    [FieldOffset(0x5EC)] public fixed int MacroSetIcon[100];

    [FixedSizeArray<Utf8String>(100)]
    [FieldOffset(0x780)] public fixed byte MacroName[0x68 * 100];

    [FieldOffset(0x3020)] public fixed bool MacroCreated[100];

    /// <summary>
    /// Note: Value is only set when changing page.
    /// </summary>
    [FieldOffset(0x30A4)] public uint SelectedMacroIndex;
    [FieldOffset(0x30A8)] public uint SelectedPage;
}
