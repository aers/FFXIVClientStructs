using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkStage
//   Component::GUI::AtkEventTarget
[GenerateInterop]
[Inherits<AtkEventTarget>]
[StructLayout(LayoutKind.Explicit, Size = 0x75E00)]
public unsafe partial struct AtkStage {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 4C 8B 40 18 45 8B 40 18", 3, isPointer: true)]
    public static partial AtkStage* Instance();

    [FieldOffset(0x10)] public AtkFontManager* AtkFontManager;
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
    [FieldOffset(0x2B8)] public DialogueStruct Dialogue;
    [FieldOffset(0x2C0), Obsolete("Use Dialogue.AtkDialogue", true)] public AtkDialogue AtkDialogue;
    [FieldOffset(0x2F8)] public FilterStruct Filter;
    [FieldOffset(0x308)] public OperationGuideStruct OperationGuide;
    [FieldOffset(0x338)] public AtkCursor AtkCursor;
    [FieldOffset(0x358), FixedSizeArray] internal FixedSizeArray32<AtkEventDispatcher> _atkEventDispatcher;
    [FieldOffset(0x858)] public uint NextEventDispatcherIndex;
    //[FieldOffset(0x85C)] public bool DispatchEvents;
    [FieldOffset(0x878), FixedSizeArray] internal FixedSizeArray10000<AtkEvent> _registeredEvents;

    [MemberFunction("48 8B 51 ?? 48 0F BF 82")]
    public partial AtkResNode* GetFocus();

    [MemberFunction("48 8B 49 ?? 45 33 C9 45 33 C0 33 D2 E9")]
    public partial void ClearFocus();

    [MemberFunction("48 8B 41 38 48 8B 40 18")]
    public partial NumberArrayData** GetNumberArrayData();

    public NumberArrayData* GetNumberArrayData(NumberArrayType type)
        => GetNumberArrayData()[(int)type];

    // Top 5 Signatures out of 215 xrefs for 14062B5F0:
    // XREF Signature #1 @ 14122E36C: E8 ?? ?? ?? ?? 41 6B CE
    // XREF Signature #2 @ 1410EC295: E8 ?? ?? ?? ?? 42 8D 1C AD
    // XREF Signature #3 @ 1410DDD25: E8 ?? ?? ?? ?? 43 8D 0C 3F
    // XREF Signature #4 @ 1414A7A09: E8 ?? ?? ?? ?? 47 8D 34 3F
    // XREF Signature #5 @ 1410AA69A: E8 ?? ?? ?? ?? 43 8D 0C FE
    [MemberFunction("E8 ?? ?? ?? ?? 42 8D 1C AD")]
    public partial StringArrayData** GetStringArrayData();

    public StringArrayData* GetStringArrayData(StringArrayType type)
        => GetStringArrayData()[(int)type];

    [MemberFunction("48 8B 41 38 48 8B 40 48")]
    public partial ExtendArrayData** GetExtendArrayData();

    public ExtendArrayData* GetExtendArrayData(ExtendArrayType type)
        => GetExtendArrayData()[(int)type];

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public struct DialogueStruct {
        [FieldOffset(0x0)] public AtkStage* AtkStage;
        [FieldOffset(0x8)] public AtkDialogue AtkDialogue;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct FilterStruct {
        [FieldOffset(0x00)] public AtkStage* AtkStage;
        [FieldOffset(0x08)] public short NumActiveSystemFilters;
        [FieldOffset(0x0A)] public short NumActiveFilters;
        [FieldOffset(0x0C)] private short SomeOtherNum;
        [FieldOffset(0x0E)] private short SomeAddonId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct OperationGuideStruct {
        [FieldOffset(0x00)] public AtkStage* AtkStage;
        [FieldOffset(0x08)] private AtkUnitBase* UnkUnitBase1;
        [FieldOffset(0x10)] private AtkUnitBase* UnkUnitBase2;
        [FieldOffset(0x18)] private byte Unk18;
        [FieldOffset(0x19)] private byte Unk19;
        [FieldOffset(0x1A)] private byte Unk1A;
        [FieldOffset(0x1B)] private byte Unk1B;
        [FieldOffset(0x1C)] private short X;
        [FieldOffset(0x1E)] private short Y;
        [FieldOffset(0x20)] private short Width;
        [FieldOffset(0x22)] private short Height;
        [FieldOffset(0x24)] private float ScaleX; // result of ScaleX / Scale
        [FieldOffset(0x28)] private float Scale;
    }
}
