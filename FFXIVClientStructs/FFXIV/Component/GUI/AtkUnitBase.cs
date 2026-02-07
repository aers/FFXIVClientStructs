using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkUnitBase
//   Component::GUI::AtkEventListener
// ctor "E8 ?? ?? ?? ?? 33 D2 48 8D 9F"
// base class for all AddonXXX classes (visible UI objects)
[GenerateInterop(isInherited: true)]
[Inherits<AtkEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x238)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8B D9 48 89 01 33 ED 48 8B 89 ?? ?? ?? ?? 8B F2", 3, 74)]
public unsafe partial struct AtkUnitBase : ICreatable {
    [FieldOffset(0x8), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
    [FieldOffset(0x28)] public AtkUldManager UldManager;
    [FieldOffset(0xB8)] public AtkWidgetAlignment WidgetAlignment; // copied from (AtkUldWidgetInfo*)UldManager.Objects
    [FieldOffset(0xC8)] public AtkResNode* RootNode;
    [FieldOffset(0xD0)] public AtkCollisionNode* WindowCollisionNode;
    [FieldOffset(0xD8)] public AtkCollisionNode* WindowHeaderCollisionNode;
    [FieldOffset(0xE0), FixedSizeArray] internal FixedSizeArray2<Pointer<AtkResNode>> _additionalMoveableNodes; // allow UnitBase to be moved. for example, left and right end of ChatLog tabs
    [FieldOffset(0xF0)] public AtkResNode* CursorTarget; // Likely always AtkCollisionNode
    [FieldOffset(0xF8)] public AtkResNode* FocusNode;
    [FieldOffset(0x100)] public AtkResNode* ComponentFocusNode;
    [FieldOffset(0x108), FixedSizeArray] internal FixedSizeArray2<Pointer<AtkResNode>> _additionalFocusableNodes; // allow UnitBase to be focused. for example, yellow bar above ContentsFinder
    [FieldOffset(0x118)] public AtkComponentNode* CurrentDropDownOwnerNode;
    [FieldOffset(0x120)] public AtkComponentNode* WindowNode;
    [FieldOffset(0x128)] public AtkSimpleTween RootNodeTween; // used for show/hide transitions
    [FieldOffset(0x178)] public AtkValue* AtkValues;
    [FieldOffset(0x180)] public StdVector<CStringPointer> CachedAtkValueStrings;
    // Bits 0-7: unknown
    // Bits 8-15: applied values of 0-7
    // [BitField<byte>(nameof(DepthLayer), 16, 4)] // has custom setter
    [BitField<AtkUnitBaseVisibilityState>(nameof(VisibilityState), 20, 4)]
    [BitField<AtkUnitBaseVisibilityState>(nameof(AppliedVisibilityState), 24, 4)]
    [BitField<AtkUnitBaseLoadState>(nameof(LoadState), 28, 4)]
    [FieldOffset(0x198)] public uint Flags198;
    // 4 bytes padding
    [BitField<bool>(nameof(DisableFocusability), 7)]
    [FieldOffset(0x1A0)] public byte Flags1A0;
    [BitField<bool>(nameof(IsReady), 0)]
    [BitField<bool>(nameof(DisableUserClose), 2)]
    [BitField<bool>(nameof(DisableFocusOnShow), 6)]
    [FieldOffset(0x1A1)] public byte Flags1A1;
    [BitField<bool>(nameof(WasLoadUldByNameCalled), 2)]
    [BitField<bool>(nameof(DisableHideTransition), 3)]
    [BitField<bool>(nameof(DisableShowHideSoundEffects), 5)]
    [BitField<bool>(nameof(DisableAddonConfig), 6)]
    [FieldOffset(0x1A2)] public byte Flags1A2;
    [BitField<bool>(nameof(EnableTitleBarContextMenu), 0)]
    // Bit 5: Disable clamping of position to the game window (Note: this will make the unitbase open at (0,0) if no position is set)
    // Bit 6: Disable WindowCollisionNode interactivity (no focus on click, not moving the addon when dragged)
    [FieldOffset(0x1A3)] public byte Flags1A3;
    // Bit 6: Unknown, enables whatever HudAnchoringInfoIndex does
    [FieldOffset(0x1A4)] public byte Flags1A4;
    [BitField<bool>(nameof(EnableTextNodePopulation), 5)]
    [BitField<bool>(nameof(DisableShowOnOpen), 6)]
    [FieldOffset(0x1A5)] public byte Flags1A5;
    // 2 bytes padding
    [FieldOffset(0x1A8)] public int Param; // appears to be a generic field that some addons use for storage
    [FieldOffset(0x1AC)] public uint ShowTransitionDuration;
    [FieldOffset(0x1B0)] public uint HideTransitionDuration;
    [FieldOffset(0x1B4)] public uint Flags1B4; // used by SetFlag, AddonConfig related?
    [FieldOffset(0x1B8)] private byte AddonParamUnknown1; // used in RaptureAtkUnitManager.vf18
    /// <remarks> Used for dialogs, context menus and other windows that cause inputs to be blocked. Checked in <see cref="ShouldIgnoreInputs"/>. </remarks>
    [FieldOffset(0x1B9)] public byte NumBlockingAddons;
    [FieldOffset(0x1BA)] private byte Unk1BA;
    [FieldOffset(0x1BB)] private byte Unk1BB;
    [FieldOffset(0x1BC)] public float ShowTransitionScale;
    [FieldOffset(0x1C0)] public float HideTransitionScale;
    [FieldOffset(0x1C4)] public float Scale;
    [BitField<bool>(nameof(EnableFilter), 2)]
    [BitField<bool>(nameof(DisableUserScaling), 11)]
    [FieldOffset(0x1C8)] public uint Flags1C8;
    /// <summary>
    /// An optional scd resource that is loaded along with the uld resource in <see cref="LoadUldResourceHandle"/>.<br/>
    /// Mainly used by Gold Saucer addons. Handled in AtkModule handler 50.<br/>
    /// The following scds can be loaded:
    /// <code>
    /// 1 = sound/system/SE_GS.scd
    /// 2 = sound/system/SE_TTriad.scd
    /// 3 = sound/system/SE_EMJ.scd
    /// 4 = sound/system/SE_10thMG.scd
    /// </code>
    /// </summary>
    [FieldOffset(0x1CC)] public byte ScdResourceIndex;
    [FieldOffset(0x1CD)] public byte HUDScaleTableIndex;
    [FieldOffset(0x1CE)] public byte VisibilityFlags;
    // 1 byte padding
    [FieldOffset(0x1D0)] public ushort DrawOrderIndex;
    /// <remarks> Index in <see cref="AtkUnitManager.HudAnchoringTable"/>. </remarks>
    [FieldOffset(0x1D2)] public sbyte HudAnchoringInfoIndex; // -1 = undefined
    // 1 byte padding
    [FieldOffset(0x1D4)] public short X;
    [FieldOffset(0x1D6)] public short Y;
    [FieldOffset(0x1D8)] public short ShowTransitionOffsetX;
    [FieldOffset(0x1DA)] public short ShowTransitionOffsetY;
    [FieldOffset(0x1DC)] public short HideTransitionOffsetX;
    [FieldOffset(0x1DE)] public short HideTransitionOffsetY;
    [FieldOffset(0x1E0)] public short ShowSoundEffectId;
    [FieldOffset(0x1E2)] public ushort AtkValuesCount;
    [FieldOffset(0x1E4)] public ushort Id;
    [FieldOffset(0x1E6)] public ushort ParentId;
    [FieldOffset(0x1E8)] public ushort HostId; // for example, in CharacterProfile this holds the ID of the Character addon
    /// <remarks> Used by context menus or other windows that cause interaction with the addon set here to be blocked. </remarks>
    [FieldOffset(0x1EA)] public ushort BlockedParentId;
    [FieldOffset(0x1EC)] public byte CursorNavigationOwnIndex;
    [FieldOffset(0x1ED)] public byte Alpha;
    [FieldOffset(0x1EE)] public byte ShowHideFlags;
    [FieldOffset(0x1EF)] private bool Unk1EF; // used in Draw
    [FieldOffset(0x1F0)] public AtkResNode** CollisionNodeList; // seems to be all collision nodes in tree, may be something else though
    [FieldOffset(0x1F8)] public uint CollisionNodeListCount;
    [FieldOffset(0x1FC), FixedSizeArray] internal FixedSizeArray5<OperationGuide> _operationGuides; // the little button hints in controller mode

    [FieldOffset(0x1B9), Obsolete("Renamed to NumBlockingAddons")] public byte NumOpenPopups;
    [FieldOffset(0x1EA), Obsolete("Renamed to BlockedParentId")] public ushort ContextMenuParentId;
    [FieldOffset(0x1AC), Obsolete("Renamed to ShowTransitionDuration")] public uint OpenTransitionDuration;
    [FieldOffset(0x1B0), Obsolete("Renamed to HideTransitionDuration")] public uint CloseTransitionDuration;
    [FieldOffset(0x1BC), Obsolete("Renamed to ShowTransitionScale")] public float OpenTransitionScale;
    [FieldOffset(0x1C0), Obsolete("Renamed to HideTransitionScale")] public float CloseTransitionScale;
    [FieldOffset(0x1D8), Obsolete("Renamed to ShowTransitionOffsetX")] public short OpenTransitionOffsetX;
    [FieldOffset(0x1DA), Obsolete("Renamed to ShowTransitionOffsetY")] public short OpenTransitionOffsetY;
    [FieldOffset(0x1DC), Obsolete("Renamed to HideTransitionOffsetX")] public short CloseTransitionOffsetX;
    [FieldOffset(0x1DE), Obsolete("Renamed to HideTransitionOffsetY")] public short CloseTransitionOffsetY;
    [FieldOffset(0x1E0), Obsolete("Renamed to ShowSoundEffectId")] public short OpenSoundEffectId;

    /// <summary> Gets a value indicating whether OnSetup was called </summary>
    public partial bool IsReady { get; }

    /// <summary> Disables the "Close" option in the title bar context menu and prevents the window from being closed via input (ESC or similar). </summary>
    public partial bool DisableUserClose { get; set; }

    /// <summary> Disables loading from/saving to AddonConfig </summary>
    public partial bool DisableAddonConfig { get; set; }

    /// <summary> Enables TextNodes to be populated (before OnSetup) </summary>
    public partial bool EnableTextNodePopulation { get; set; }

    /// <summary> Enable Filter (Modal window with backdrop) </summary>
    public partial bool EnableFilter { get; set; }

    /// <summary> Disables the "Scale Window" option in the title bar context menu </summary>
    public partial bool DisableUserScaling { get; set; }

    public uint DepthLayer {
        get => BitOps.GetBits(Flags198, 16, 0b1111u);
        set => SetDepthLayer(value);
    }

    public bool IsVisible {
        get => VisibilityState.HasFlag(AtkUnitBaseVisibilityState.IsVisible);
        set => VisibilityState = value
            ? VisibilityState | AtkUnitBaseVisibilityState.IsVisible
            : VisibilityState & ~AtkUnitBaseVisibilityState.IsVisible;
    }

    public Span<AtkValue> AtkValuesSpan => new(AtkValues, AtkValuesCount);

    [MemberFunction("E8 ?? ?? ?? ?? 66 45 2B E6")]
    public static partial float GetGlobalUIScale();

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 8D 9F")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? 40 F6 C5 01")]
    public partial void Destructor();

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF CB 0F 28 F8")]
    public partial float GetScale();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 55 F3")]
    public partial void SetSize(ushort width, ushort height);

    [MemberFunction("E8 ?? ?? ?? ?? 40 2A C7")]
    public partial float GetScaledWidth(bool getScaledWidth); // False returns unscaled width

    [MemberFunction("E8 ?? ?? ?? ?? 66 2B DE")]
    public partial float GetScaledHeight(bool getScaledHeight); // False returns unscaled height

    [MemberFunction("E8 ?? ?? ?? ?? 44 84 B7")]
    public partial AtkResNode* GetNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 41 C1 EF")]
    public partial AtkTextNode* GetTextNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 55 77")]
    public partial AtkImageNode* GetImageNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 3C 36")]
    public partial AtkComponentButton* GetComponentButtonById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 FF 48 89 43")]
    public partial AtkComponentList* GetComponentListById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 56 31")]
    public partial AtkComponentBase* GetComponentByNodeId(uint nodeId);

    public AtkComponentNode* GetComponentNodeById(uint nodeId) {
        // Added to avoid API breaking
        var component = GetComponentByNodeId(nodeId);
        if (component == null) return null;
        return component->OwnerNode;
    }

    [MemberFunction("E9 ?? ?? ?? ?? 83 C3 F9")]
    public partial bool FireCallbackInt(int callbackValue);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 E8 8B 44 24 20")]
    public partial bool FireCallback(uint valueCount, AtkValue* values, bool close = false);

    /// <remarks> Will call <see cref="AtkModuleInterface.AtkEventInterface.ReceiveEventWithResult(AtkValue*, AtkValue*, uint, ulong)"/> of the registered callback handler. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F B6 F8")]
    public partial AtkValue* FireCallbackWithResult(AtkValue* returnValue, uint valueCount, AtkValue* values);

    [MemberFunction("E8 ?? ?? ?? ?? 32 C0 88 45 67")]
    public partial void UpdateCollisionNodeList(bool clearFocus);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BA E7 14")]
    public partial bool SetFocusNode(AtkResNode* node, bool setCursorFocusNode = false, uint focusParam = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 44 39 BC 24")]
    public partial void SetComponentFocusNode(AtkComponentBase* component);

    /// <param name="arrayType">0 for StringArrayData or 1 for NumberArrayData</param>
    /// <param name="arrayIndex">The index in AtkArrayDataHolder</param>
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 06 41 B9")]
    public partial void SubscribeAtkArrayData(byte arrayType, byte arrayIndex);

    /// <param name="arrayType">0 for StringArrayData or 1 for NumberArrayData</param>
    /// <param name="arrayIndex">The index in AtkArrayDataHolder</param>
    /// <param name="clean">Resets all values to default, also frees managed strings</param>
    [MemberFunction("E8 ?? ?? ?? ?? 45 33 C9 8D 56 01")]
    public partial void UnsubscribeAtkArrayData(byte arrayType, byte arrayIndex, bool clean = false);

    [MemberFunction("E9 ?? ?? ?? ?? 48 8D 15 ?? ?? ?? ?? 41 B9 ?? ?? ?? ??"), GenerateStringOverloads]
    public partial bool LoadUldByName(CStringPointer name, byte a3 = 0, uint a4 = 6);

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 10 0D ?? ?? ?? ?? 45 33 C9 F3 0F 59 0D")]
    public partial void SetOpenTransition(float duration, short offsetX, short offsetY, float scale);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 C0 4C 89 BF")]
    public partial void SetCloseTransition(float duration, short offsetX, short offsetY, float scale);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 03 8B D7 4C 8B 83")]
    public partial bool SetAtkValues(uint valueCount, AtkValue* values);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 94 24 ?? ?? ?? ?? 03 96 ?? ?? ?? ??")]
    public partial bool MoveDelta(short* xDelta, short* yDelta);

    [MemberFunction("48 85 D2 74 1A 48 8B 81 ?? ?? ?? ??")]
    public partial bool ContainsNode(AtkResNode* node);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8D 6B")]
    public partial bool SetOperationGuide(OperationGuide* operationGuide);

    [MemberFunction("E8 ?? ?? ?? ?? 47 38 A4 FE")]
    public partial bool SetOperationGuideEx(uint addonTransientId, OperationGuidePoint relativePoint, int index, OperationGuidePoint point, short offsetX, short offsetY);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B CF BF")]
    public partial bool ClearOperationGuide(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 F0 44 0F B7 83"), GenerateStringOverloads]
    public partial bool LoadAddonConfig(short* outWidth, short* outHeight, CStringPointer name, bool isInitialLoad);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8B CF C6 44 24 ?? ?? 4C 8B C7"), GenerateStringOverloads]
    public partial void SaveAddonConfig(CStringPointer name, bool a2, bool a3);

    [VirtualFunction(3)]
    public partial bool Open(uint depthLayer);

    [VirtualFunction(4)]
    public partial bool Close(bool fireCallback);

    [VirtualFunction(5)]
    public partial void Show(bool disableShowTransition, uint unsetShowHideFlags);

    [VirtualFunction(6)]
    public partial void Hide(bool disableHideTransition, bool callCloseCallback, uint setShowHideFlags);

    [VirtualFunction(7)]
    public partial void SetPosition(short x, short y);

    [VirtualFunction(8)]
    public partial void SetX(short value);

    [VirtualFunction(9)]
    public partial void SetY(short value);

    [VirtualFunction(10)]
    public partial short GetX();

    [VirtualFunction(11)]
    public partial short GetY();

    [VirtualFunction(12)]
    public partial void GetPosition(short* outX, short* outY);

    [VirtualFunction(13)]
    public partial void SetAlpha(byte alpha);

    [VirtualFunction(14)]
    public partial void SetScale(float scale, bool a3);

    [VirtualFunction(15)]
    public partial void GetSize(short* outWidth, short* outHeight, bool scaled);

    [VirtualFunction(16)]
    public partial void Hide2();

    [VirtualFunction(17)]
    public partial sbyte SetScaleToHudLayoutScale();

    [VirtualFunction(18)]
    public partial bool ShouldCollideWithWindow(AtkCollisionNode* collisionNode);

    [VirtualFunction(20)]
    public partial void OnMove();

    /// <remarks> Only called on the current <see cref="AtkCollisionManager.IntersectingAddon"/> for cursor types ChatPointer, Attack and Clickable. </remarks>
    /// <returns> <see langword="true"/> when a custom sound effect was played, <see langword="false"/> when default should be played (Sound Effect 0). </returns>
    [VirtualFunction(22)]
    public partial bool HandleCursorTypeChange();

    [VirtualFunction(23)]
    public partial bool ShouldIgnoreInputs();

    [VirtualFunction(24)]
    public partial AtkResNode* GetRootNode();

    [VirtualFunction(27)]
    public partial void GetWindowBounds(Bounds* outBounds); // tries to get it from WindowCollisionNode first, then from RootNode

    [VirtualFunction(30)]
    public partial void GetRootBounds(Bounds* outBounds);

    [VirtualFunction(31)]
    public partial bool SetDepthLayer(uint depthLayerIndex);

    [VirtualFunction(32)]
    public partial bool ShouldAllowCursorFocus();

    [VirtualFunction(35)]
    public partial AtkUnitBase* GetUnitBaseForFocus(); // this basically always returns the addon itself, except for in ChatLogPanel where it returns ChatLog

    [VirtualFunction(37)]
    public partial void Focus();

    [VirtualFunction(41)]
    public partial void Initialize();

    /// <remarks>
    /// The name "Finalizer" is used instead of "Finalize" to avoid conflicts
    /// with the <see cref="object.Finalize"/> method.
    /// </remarks>
    [VirtualFunction(42)]
    public partial void Finalizer();

    [VirtualFunction(43)]
    public partial void Update(float delta);

    [VirtualFunction(44)]
    public partial void Draw();

    [VirtualFunction(46)]
    public partial bool LoadUldResourceHandle();

    [VirtualFunction(47)]
    public partial bool CheckWindowCollisionAtCoords(short x, short y);

    [VirtualFunction(49)]
    public partial void OnSetup(uint valueCount, AtkValue* values);

    [VirtualFunction(51)]
    public partial bool OnRefresh(uint valueCount, AtkValue* values);

    [VirtualFunction(52)]
    public partial void OnRequestedUpdate(NumberArrayData** numberArrayData, StringArrayData** stringArrayData);

    [VirtualFunction(54)]
    public partial void FireCloseCallback();

    /// <remarks> Called after <see cref="OnSetup(uint, AtkValue*)"/> when entry in AddonConfig existed. </remarks>
    [VirtualFunction(56)]
    public partial void SetSizeFromConfig(float width, float height);

    [VirtualFunction(57)]
    public partial bool HandleCustomInput(AtkEventData.AtkInputData* inputData);

    [VirtualFunction(59)]
    public partial void OnFocusChange(bool isFocused);

    [VirtualFunction(60)]
    public partial void OnScreenSizeChange(int width, int height);

    [VirtualFunction(61)]
    public partial void OnConfigLoaded(bool isInitialLoad);

    [VirtualFunction(62)]
    public partial void OnMouseOver();

    [VirtualFunction(63)]
    public partial void OnMouseOut();

    /// <summary>
    /// Check if all necessary resources are loaded and nodes/components are set up.
    /// </summary>
    /// <remarks>
    /// Use <see cref="IsReady" /> to check if OnSetup has been called (preferred).
    /// </remarks>
    [VirtualFunction(66)]
    public partial bool IsFullyLoaded();

    [VirtualFunction(67)]
    public partial void PlaySoundEffect(int soundEffectId);

    [VirtualFunction(69)]
    public partial bool HandleDPadInput(int inputId, bool a3);

    [VirtualFunction(71)]
    public partial bool HandleBackButtonInput(int inputId, bool a3);
}

[Flags]
public enum AtkUnitBaseVisibilityState : byte {
    None = 0,
    Unk1 = 1 << 0,
    IsVisible = 1 << 1,
    /// <remarks> Seen on Retainer Menu </remarks>
    IsHiddenDueToModal = 1 << 2,
    Unk4 = 1 << 3,
}

public enum AtkUnitBaseLoadState : byte {
    /// <remarks>
    /// <see cref="AtkUnitBase.LoadUldResourceHandle"/> will be called, which loads the uld file, and optionally scds.
    /// </remarks>
    LoadingUldResource = 0,

    /// <remarks>
    /// AtkUldManager.LoadResourceAndTextures will be called, which creates nodes and loads textures.<br/>
    /// Refer to <see cref="AtkUldManager.LoadedState"/>.
    /// </remarks>
    LoadingResources = 1,

    /// <remarks>
    /// <see cref="AtkUnitBase.IsFullyLoaded"/> returned <see langword="true"/>.
    /// </remarks>
    FullyLoaded = 2,
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public partial struct OperationGuide {
    [FieldOffset(0x00)] public byte Index; // 0xFF = Disabled
    [BitField<OperationGuidePoint>(nameof(RelativePoint), 0, 4)]
    [BitField<OperationGuidePoint>(nameof(Point), 4, 4)]
    [FieldOffset(0x01)] public byte PositionFlags;
    [FieldOffset(0x02)] public short OffsetX;
    [FieldOffset(0x04)] public short OffsetY;

    [FieldOffset(0x08)] public uint AddonTransientId;

    /// <summary> The point of the node to anchor to. </summary>
    public partial OperationGuidePoint RelativePoint { get; set; }

    /// <summary> The point of this OperationGuide. </summary>
    public partial OperationGuidePoint Point { get; set; }
}

public enum OperationGuidePoint : byte {
    TopLeft,
    Top,
    TopRight,
    Left,
    Center,
    Right,
    BottomLeft,
    Bottom,
    BottomRight,
}
