namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkAddonControl
//   Component::GUI::AtkEventTarget
//   Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe struct AtkAddonControl {
    [FieldOffset(0x00)] public AtkEventTarget EventTarget;
    [FieldOffset(0x08)] public AtkEventListener EventListener;
    [FieldOffset(0x10)] public StdList<Pointer<ChildAddonInfo>> ChildAddons;
    [FieldOffset(0x20)] public AtkEventManager EventManager;
    [FieldOffset(0x28)] public AtkUnitBase* ParentAddon;
    [FieldOffset(0x30)] public AtkStage* AtkStage;
    [FieldOffset(0x38)] public AtkCollisionNode* WindowHeaderCollisionNode;

    [FieldOffset(0x50)] public ChildAddonInfo* TempChildAddonInfoPtr; // used to send AtkEventType 48

    [FieldOffset(0x5C)] public bool IsParentAddonLinked; // set in AtkAddonControl_Initialize, ParentAddon != 0
    [FieldOffset(0x5D)] public bool IsChildSetupComplete; // set in a loop in AtkAddonControl_Update, false if processing child, true if loop completed

    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public unsafe struct ChildAddonInfo {
        [FieldOffset(0x00)] public byte* Unk0; // for example chat tab title
        [FieldOffset(0x08)] public AtkUnitBase* AtkUnitBase;

        [FieldOffset(0x20)] public AtkCollisionNode* CollisionNode;

        [FieldOffset(0x30)] public int TabIndex; // for example chat tab index

        [FieldOffset(0x3C)] public short PositionX; // multiplied with the addons Scale
        [FieldOffset(0x3E)] public short PositionY; // multiplied with the addons Scale
        [FieldOffset(0x40)] public byte Flags1;
        [FieldOffset(0x41)] public byte Flags2;
    }
}
