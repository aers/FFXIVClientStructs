using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGlassSelect
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GlassSelect")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x29A0)]
public unsafe partial struct AddonGlassSelect {
    [FieldOffset(0x270), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkComponentRadioButton>> _tabs;

    [FieldOffset(0x2D8)] public TabController TabController;

    [FieldOffset(0x398), FixedSizeArray] internal FixedSizeArray30<GlassesStyleEntry> _glassesStyles;
    [FieldOffset(0x1DD8)] public ushort NumVisibleGlassesStyles;

    [FieldOffset(0x1DE0), FixedSizeArray] internal FixedSizeArray30<Pointer<AtkComponentButton>> _glassesStyleButtons;
    [FieldOffset(0x1ED0)] public ushort SelectedGlassesStyleIndex;

    [FieldOffset(0x1EF0), FixedSizeArray] internal FixedSizeArray12<GlassesEntry> _glasses;
    [FieldOffset(0x2910)] public ushort NumVisibleGlasses;

    [FieldOffset(0x2918), FixedSizeArray] internal FixedSizeArray12<Pointer<AtkComponentDragDrop>> _glassesDragDrops;
    [FieldOffset(0x2978)] public ushort SelectedGlassesIndex;

    [StructLayout(LayoutKind.Explicit, Size = 0xE0)]
    public struct GlassesStyleEntry {
        [FieldOffset(0x00)] public ushort Id;
        [FieldOffset(0x04)] public uint IconId;
        [FieldOffset(0x08)] public Utf8String Name;
        [FieldOffset(0x70)] private Utf8String Unk70; // non-existing Description?
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xD8)]
    public struct GlassesEntry {
        [FieldOffset(0x00)] public ushort Id;
        [FieldOffset(0x04)] public uint IconId;
        [FieldOffset(0x08)] public Utf8String Name;
        [FieldOffset(0x70)] public Utf8String Description;
    }
}
