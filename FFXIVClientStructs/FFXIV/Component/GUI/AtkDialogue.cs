namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkDialogue
[GenerateInterop]
[Inherits<AtkEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AtkDialogue {
    [FieldOffset(0x08)] private AtkValue UnkAtkValue;
    [FieldOffset(0x18)] public AtkStage* AtkStage;
    [FieldOffset(0x20)] private AtkUnitBase* UnkAtkUnitBase;

    [FieldOffset(0x34)] private bool Unk34;
    [FieldOffset(0x35)] private bool Unk35;
}
