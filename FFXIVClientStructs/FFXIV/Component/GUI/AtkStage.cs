using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkStage
//   Component::GUI::AtkEventTarget
[GenerateInterop]
[Inherits<AtkEventTarget>]
[StructLayout(LayoutKind.Explicit, Size = 0x75EA8)]
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
    [FieldOffset(0x360)] public DialogueStruct Dialogue;
    [FieldOffset(0x3A0)] public FilterStruct Filter;
    [FieldOffset(0x3B0)] public OperationGuideStruct OperationGuide;
    [FieldOffset(0x3E0)] public AtkCursor AtkCursor;
    [FieldOffset(0x400), FixedSizeArray] internal FixedSizeArray32<AtkEventDispatcher> _atkEventDispatcher;
    [FieldOffset(0x900)] public uint NextEventDispatcherIndex;
    [FieldOffset(0x904)] public bool CanDispatchEvents;
    [FieldOffset(0x908)] public Size ScreenSize;
    [FieldOffset(0x910)] public float ScreenSizeScale;
    [FieldOffset(0x914)] public bool IsScreenSizeScaled;
    [FieldOffset(0x918)] public AtkEventManager ViewportEventManager; // more like GlobalEventManager
    [FieldOffset(0x920), FixedSizeArray] internal FixedSizeArray10000<AtkEvent> _atkEventPool;
    [FieldOffset(0x75C20)] public AtkEvent* NextEvent;
    [FieldOffset(0x75C28)] public StdDeque<TextParameter> FormatTextParameters;
    [FieldOffset(0x75C50)] public Utf8String FormatOutput;
    [FieldOffset(0x75CB8), FixedSizeArray(isString: true)] internal FixedSizeArray384<byte> _formatCStringBuffer;
    [FieldOffset(0x75E38)] public AtkTimer ButtonClickTimer; // for example, used in NumericInput when clicking +/- buttons
    [FieldOffset(0x75E68)] public AtkTimer ButtonClickRepeatTimer; // for example, used in NumericInput when holding down +/- buttons
    [FieldOffset(0x75E98)] public AtkTimer* TimerArray; // only 1 right now
    [FieldOffset(0x75EA0)] public int TimerCount;

    [MemberFunction("48 8B 51 ?? 48 0F BF 82")]
    public partial AtkResNode* GetFocus();

    [MemberFunction("48 8B 49 ?? 45 33 C9 45 33 C0 33 D2 E9")]
    public partial void ClearFocus();

    [MemberFunction("81 62 ?? ?? ?? ?? ?? 45 33 C0")]
    public partial void ReturnAtkEventToPool(AtkEvent* evt);

    [MemberFunction("E8 ?? ?? ?? ?? 6B 94")]
    public partial NumberArrayData** GetNumberArrayData();

    public NumberArrayData* GetNumberArrayData(NumberArrayType type)
        => GetNumberArrayData()[(int)type];

    [MemberFunction("E8 ?? ?? ?? ?? 42 8D 1C AD")]
    public partial StringArrayData** GetStringArrayData();

    public StringArrayData* GetStringArrayData(StringArrayType type)
        => GetStringArrayData()[(int)type];

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 48 ?? 48 89 4D")]
    public partial ExtendArrayData** GetExtendArrayData();

    public ExtendArrayData* GetExtendArrayData(ExtendArrayType type)
        => GetExtendArrayData()[(int)type];

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public struct DialogueStruct {
        [FieldOffset(0x0)] public AtkStage* AtkStage;
        [FieldOffset(0x8)] public AtkDialogue AtkDialogue;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe partial struct FilterStruct {
        [FieldOffset(0x00)] public AtkStage* AtkStage;
        /// <summary>
        /// Number of active users of <see cref="AtkUnitManager.AddonFilterSystem"/>.
        /// </summary>
        [FieldOffset(0x08)] public short NumActiveSystemFilters;
        /// <summary>
        /// Number of active users of <see cref="AtkUnitManager.AddonFilter"/>.
        /// </summary>
        [FieldOffset(0x0A)] public short NumActiveFilters;
        /// <summary>
        /// Number of active users of <see cref="AtkUnitManager.ManagedScreenFrame"/>.
        /// </summary>
        [FieldOffset(0x0C)] public short NumActiveScreenFrames;
        /// <summary>
        /// An additional addon included in modal-filter draw-order checks.
        /// A non-zero ID also enables input-filter checks during addon collision testing.
        /// </summary>
        [FieldOffset(0x0E)] public ushort AdditionalFilterAddonId;

        /// <summary>
        /// Activates <see cref="AtkUnitManager.AddonFilter"/> for the specified addon.
        /// </summary>
        [MemberFunction("E8 ?? ?? ?? ?? EB ?? E8 ?? ?? ?? ?? 48 8B D3 48 8D 88")]
        public partial void AcquireFilter(AtkUnitBase* addon);

        /// <summary>
        /// Deactivates <see cref="AtkUnitManager.AddonFilter"/> for the specified addon.
        /// </summary>
        [MemberFunction("E8 ?? ?? ?? ?? 0F BA E5 ?? 48 8B 6C 24 ?? 73 ?? 48 8D 4F")]
        public partial void ReleaseFilter(AtkUnitBase* addon);

        /// <summary>
        /// Activates <see cref="AtkUnitManager.AddonFilterSystem"/>.
        /// </summary>
        [MemberFunction("E8 ?? ?? ?? ?? 40 84 ED 79 ?? 48 8B CF")]
        public partial void AcquireSystemFilter();

        /// <summary>
        /// Deactivates <see cref="AtkUnitManager.AddonFilterSystem"/>.
        /// </summary>
        [MemberFunction("E8 ?? ?? ?? ?? 0F BA E5 ?? 73 ?? 48 8B 8F ?? ?? ?? ?? 33 D2")]
        public partial void ReleaseSystemFilter();

        /// <summary>
        /// Activates <see cref="AtkUnitManager.ManagedScreenFrame"/>.
        /// </summary>
        [MemberFunction("48 8B 01 48 85 C0 74 ?? 48 8B 40 ?? 4C 8B 90 ?? ?? ?? ?? 4D 85 D2 74 ?? 66 FF 41 ?? 45 33 C9")]
        public partial void AcquireScreenFrame();

        /// <summary>
        /// Deactivates <see cref="AtkUnitManager.ManagedScreenFrame"/>.
        /// </summary>
        [MemberFunction("48 8B 01 48 85 C0 74 ?? 48 8B 40 ?? 4C 8B 90 ?? ?? ?? ?? 4D 85 D2 74 ?? 66 FF 49 ?? 66 83 79 ?? 00")]
        public partial void ReleaseScreenFrame();

        /// <summary>
        /// Returns whether the specified addon can receive input while filters are active.
        /// </summary>
        [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 41 81 8E")]
        public partial bool CanAddonReceiveInput(AtkUnitBase* addon);

        /// <summary>
        /// Sets the additional addon used in input-filter draw-order checks and enables filtering during addon collision testing.
        /// </summary>
        [MemberFunction("48 85 D2 74 ?? 0F B7 82 ?? ?? ?? ?? 66 89 41")]
        public partial void SetAdditionalFilterAddon(AtkUnitBase* addon);

        /// <summary>
        /// Clears the additional addon if it matches the specified addon.
        /// </summary>
        [MemberFunction("48 85 D2 74 ?? 0F B7 82 ?? ?? ?? ?? 66 39 41")]
        public partial void ClearAdditionalFilterAddon(AtkUnitBase* addon);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct OperationGuideStruct {
        [FieldOffset(0x00)] public AtkStage* AtkStage;
        [FieldOffset(0x08), Obsolete("Renamed to FocusedAddon")] public AtkUnitBase* AttachedToAddon;
        /// <summary>
        /// The currently focused addon from which operation-guide resolution begins.
        /// </summary>
        [FieldOffset(0x08)] public AtkUnitBase* FocusedAddon;
        [FieldOffset(0x10), Obsolete("Renamed to GuideSourceAddon")] public AtkUnitBase* AttachedToAddon2;
        /// <summary>
        /// The addon supplying the operation-guide entries.
        /// </summary>
        [FieldOffset(0x10)] public AtkUnitBase* GuideSourceAddon;
        /// <summary>
        /// Whether operation-guide contents are currently displayed.
        /// </summary>
        [FieldOffset(0x18)] public bool IsActive;
        /// <summary>
        /// True if the OperationsGuide should refresh.
        /// </summary>
        [FieldOffset(0x19)] public bool RequestRefresh;
        /// <summary>
        /// Show the operation guide even when gamepad mode is disabled.
        /// </summary>
        [FieldOffset(0x1A)] public bool ShowInMouseMode;
        // 0x1B is padding
        [FieldOffset(0x1C)] private short X;
        [FieldOffset(0x1E)] private short Y;
        [FieldOffset(0x20)] private short Width;
        [FieldOffset(0x22)] private short Height;
        [FieldOffset(0x24)] private float ScaleX; // result of ScaleX / Scale
        [FieldOffset(0x28)] private float Scale;
    }
}
