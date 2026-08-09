using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonPvPCharacter
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("PvPCharacter")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? BE ?? ?? ?? ?? 48 89 BB", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0xD40)]
public unsafe partial struct AddonPvPCharacter {
    [FieldOffset(0x258), FixedSizeArray] internal FixedSizeArray21<ClassEntry> _classEntries;

    [FieldOffset(0x940), FixedSizeArray] internal FixedSizeArray21<ClassDataEntry> _classData;

    [FieldOffset(0xC80)] public PreviewController PreviewController;

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B B7 ?? ?? ?? ?? 49 8B 46 28")]
    public partial void UpdateClasses(NumberArrayData** numberArrayData, StringArrayData** stringArrayData);

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct ClassEntry {
        [FieldOffset(0x00)] public AtkComponentBase* Base;
        [FieldOffset(0x08)] public AtkTextNode* Name;
        [FieldOffset(0x10)] public AtkTextNode* Level;
        [FieldOffset(0x18)] public AtkImageNode* Icon;
        [FieldOffset(0x20)] private AtkImageNode* UnkImage;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct ClassDataEntry {
        [FieldOffset(0x00)] public int Level;
        [FieldOffset(0x04)] public int CurrentXP;
        [FieldOffset(0x08)] public int NeededXP;
        [FieldOffset(0x0C)] public bool IsMaxLevel;
        [FieldOffset(0x10)] public CStringPointer TooltipText;
    }
}
