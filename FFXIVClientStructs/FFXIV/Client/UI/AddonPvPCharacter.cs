using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonPvPCharacter
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("PvPCharacter")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 89 03 E8 ?? ?? ?? ?? 33 FF 48 89 BB", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0xD10)]
public unsafe partial struct AddonPvPCharacter {
    [FieldOffset(0x258), FixedSizeArray] internal FixedSizeArray21<ClassEntry> _classEntries;

    [FieldOffset(0xC50)] public PreviewController PreviewController;

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B B7 ?? ?? ?? ?? 49 8B 46 28")]
    public partial void UpdateClasses(NumberArrayData** numberArrayData, StringArrayData** stringArrayData);

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct ClassEntry {
        [FieldOffset(0x00)] public AtkComponentBase* Base;
        [FieldOffset(0x08)] public AtkTextNode* Name;
        [FieldOffset(0x10)] public AtkTextNode* Level;
        [FieldOffset(0x18)] public AtkImageNode* Icon;
        [FieldOffset(0x20)] public AtkImageNode* UnkImage;
    }
}
