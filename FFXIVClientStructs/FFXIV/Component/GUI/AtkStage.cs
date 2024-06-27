using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkStage
//   Component::GUI::AtkEventTarget
// ctor "E8 ?? ?? ?? ?? 48 8B F8 48 89 BE ?? ?? ?? ?? 48 8B 43 10"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x75E00)]
public unsafe partial struct AtkStage {
    [FieldOffset(0x0)] public AtkEventTarget AtkEventTarget;
    [FieldOffset(0x18)] public AtkTextureResourceManager* AtkTextureResourceManager;
    [FieldOffset(0x20)] public RaptureAtkUnitManager* RaptureAtkUnitManager;
    [FieldOffset(0x28)] public AtkInputManager* AtkInputManager;
    [FieldOffset(0x30)] public AtkCollisionManager* AtkCollisionManager;
    [FieldOffset(0x38)] public AtkArrayDataHolder* AtkArrayDataHolder;
    [FieldOffset(0x40)] public AtkTimerHolder* AtkTimerHolder;
    [FieldOffset(0x48)] public AtkSimpleTweenHolder* AtkSimpleTweenHolder;
    [FieldOffset(0x50)] public AtkCrestManager* AtkCrestManager;
    [FieldOffset(0x58)] public AtkUIColorHolder* AtkUIColorHolder;
    [FieldOffset(0x60)] public RaptureTextModule* RaptureTextModule;
    [FieldOffset(0x68)] public SoftKeyboardDeviceInterface* SoftKeyboardDevice;
    [FieldOffset(0x70)] public AtkExternalInterface* AtkExternalInterface;
    [FieldOffset(0x78)] public AtkDragDropManager DragDropManager;
    [FieldOffset(0x140)] public AtkGroupManager AtkGroupManager;
    [FieldOffset(0x168)] public AtkTooltipManager TooltipManager;
    [FieldOffset(0x2C0)] public AtkDialogue AtkDialogue;
    [FieldOffset(0x338)] public AtkCursor AtkCursor;
    [FieldOffset(0x358), FixedSizeArray] internal FixedSizeArray32<AtkEventDispatcher> _atkEventDispatcher;
    [FieldOffset(0x858)] public uint NextEventDispatcherIndex;
    //[FieldOffset(0x85C)] public bool DispatchEvents;
    [FieldOffset(0x878), FixedSizeArray] internal FixedSizeArray10000<AtkEvent> _registeredEvents;

    [MemberFunction("E8 ?? ?? ?? ?? 3B 98")]
    public static partial AtkStage* Instance();

    [MemberFunction("48 8B 51 ?? 48 0F BF 82")]
    public partial AtkResNode* GetFocus();

    [MemberFunction("48 8B 49 ?? 45 33 C9 45 33 C0 33 D2 E9")]
    public partial void ClearFocus();

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 F6 48 85 C0 74 06")]
    public partial NumberArrayData** GetNumberArrayData();

    // Top 5 Signatures out of 215 xrefs for 14062B5F0:
    // XREF Signature #1 @ 14122E36C: E8 ?? ?? ?? ?? 41 6B CE
    // XREF Signature #2 @ 1410EC295: E8 ?? ?? ?? ?? 42 8D 1C AD
    // XREF Signature #3 @ 1410DDD25: E8 ?? ?? ?? ?? 43 8D 0C 3F
    // XREF Signature #4 @ 1414A7A09: E8 ?? ?? ?? ?? 47 8D 34 3F
    // XREF Signature #5 @ 1410AA69A: E8 ?? ?? ?? ?? 43 8D 0C FE
    [MemberFunction("E8 ?? ?? ?? ?? 42 8D 1C AD")]
    public partial StringArrayData** GetStringArrayData();

    [MemberFunction("48 8B 41 38 48 8B 40 48")]
    public partial ExtendArrayData** GetExtendArrayData();
}
