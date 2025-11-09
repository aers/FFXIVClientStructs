using FFXIVClientStructs.FFXIV.Client.UI;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x18A0)]
public unsafe partial struct AtkInputManager {
    [FieldOffset(0)] public AtkTextInput* TextInput;

    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray2<Pointer<AtkCollisionNode>> _savedMouseClicksCollisionNodes; // maybe more?

    [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray2<SavedMouseClick> _savedMouseClicks; // maybe more?

    [FieldOffset(0x80), FixedSizeArray] internal FixedSizeArray256<FocusEntry> _focusList;

    [FieldOffset(0x1880)] public AtkResNode* FocusedNode;

    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 48 89 86 ?? ?? ?? ?? 88 86 ?? ?? ?? ?? 38 86")]
    public partial void HandleInput(AtkUnitManager* unitManager, AtkCollisionManager* collisionManager);

    // null is valid when setting focus, this will result in all focus being cleared
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 84 FF ?? ?? ?? ??")]
    public partial bool SetFocus(AtkResNode* node, AtkUnitBase* addon, int focusParam);

    [MemberFunction("E8 ?? ?? ?? ?? 66 89 BE ?? ?? ?? ??")]
    public partial bool HandleFocus(RaptureAtkUnitManager* unitManager, FocusEntry* focusEntry, AtkEventDispatcher.Event* eventData);

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct FocusEntry {
        [FieldOffset(0x0)] public AtkEventListener* AtkEventListener;
        [FieldOffset(0x8)] public AtkEventTarget* AtkEventTarget;
        [FieldOffset(0x10)] public int FocusParam;
        [FieldOffset(0x10), Obsolete("Renamed to FocusParam")] public int Unk10;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct SavedMouseClick {
        [FieldOffset(0x0)] public int Timestamp;
        [FieldOffset(0x4)] public short X;
        [FieldOffset(0x6)] public short Y;
    }
}
