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
[VirtualTable("48 89 51 28 48 8D 05 ?? ?? ?? ?? 48 89 01", 7, 74)]
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
    [FieldOffset(0x128)] public AtkSimpleTween RootNodeTween; // used for open/close transitions
    [FieldOffset(0x178)] public AtkValue* AtkValues;
    [FieldOffset(0x180)] public StdVector<CStringPointer> CachedAtkValueStrings;
    /// <summary>
    /// <code>
    /// DepthLayer:<br/>
    ///   Getter: (Flags180 >> 16) &amp; 0xF<br/>
    ///   Mask: 0b0000_0000_0000_1111_0000_0000_0000_0000<br/>
    /// <br/>
    /// Visibility(?) Flags:<br/>
    ///   Getter: (Flags180 >> 20) &amp; 0xF<br/>
    ///   Mask: 0b0000_0000_1111_0000_0000_0000_0000_0000<br/>
    ///   Values:
    ///     0b0010 = Is visible<br/>
    ///     0b0100 = Is hidden due to modal (like Retainer Menu)<br/>
    /// <br/>
    /// Applied Visibility(?) Flags:<br/>
    ///   Getter: (Flags180 >> 24) &amp; 0xF<br/>
    ///   Mask: 0b0000_1111_0000_0000_0000_0000_0000_0000<br/>
    ///   Values: same as above<br/>
    /// <br/>
    /// UldLoadState:<br/>
    ///   Getter: (Flags180 >> 28) &amp; 0xF<br/>
    ///   Mask: 0b1111_0000_0000_0000_0000_0000_0000_0000<br/>
    ///   Values:
    ///     0 = Not loaded<br/>
    ///     1 = UldResource loaded<br/>
    ///     2 = UldManager finished loading the uld
    /// </code>
    /// </summary>
    [FieldOffset(0x198)] public uint Flags198;
    // 4 bytes padding
    /// <summary>
    /// <code>
    /// 0b1000_0000 [0x80] = Disable auto-focus (not adding it to Focused Units list)
    /// </code>
    /// </summary>
    [FieldOffset(0x1A0)] public byte Flags1A0;
    /// <summary>
    /// <code>
    /// 0b0000_0001 [0x1] = OnSetup was called (= IsReady)<br/>
    /// 0b0000_0100 [0x4] = Disable "Close" option in title bar context menu and prevents window from being closed via input (ESC or similar)
    /// </code>
    /// </summary>
    [FieldOffset(0x1A1)] public byte Flags1A1;
    /// <summary>
    /// <code>
    /// 0b0000_0100 [0x4] = LoadUldByName was called<br/>
    /// 0b0000_1000 [0x8] = Disable close transition<br/>
    /// 0b0010_0000 [0x20] = Suppress open/close sounds<br/>
    /// 0b0100_0000 [0x40] = Don't load/save AddonConfig
    /// </code>
    /// </summary>
    [FieldOffset(0x1A2)] public byte Flags1A2;
    /// <summary>
    /// <code>
    /// 0b0000_0001 [0x1] = Enable title bar context menu<br/>
    /// 0b0010_0000 [0x20] = Disable clamping of position to the game window (Note: this will make the unitbase open at (0,0) if no position is set)
    /// 0b0100_0000 [0x40] = Make WindowCollisionNode non-interactable (no focus on click, not moving addon when dragged)
    /// </code>
    /// </summary>
    [FieldOffset(0x1A3)] public byte Flags1A3;
    /// <summary>
    /// <code>
    /// 0b0100_0000 [0x40] = Unknown, enables whatever <see cref="Unk1D2"/> does
    /// </code>
    /// </summary>
    [FieldOffset(0x1A4)] public byte Flags1A4;
    /// <summary>
    /// <code>
    /// 0b0010_0000 [0x20] = Populate TextNode texts (before OnSetup)<br/>
    /// 0b0100_0000 [0x40] = Don't show on open
    /// </code>
    /// </summary>
    [FieldOffset(0x1A5)] public byte Flags1A5;
    // 2 bytes padding
    [FieldOffset(0x1A8)] public int Param; // appears to be a generic field that some addons use for storage
    [FieldOffset(0x1AC)] public uint OpenTransitionDuration;
    [FieldOffset(0x1B0)] public uint CloseTransitionDuration;
    [FieldOffset(0x1B4)] public uint Flags1B4; // used by SetFlag
    [FieldOffset(0x1B8)] public byte AddonParamUnknown1; // used in RaptureAtkUnitManager.vf18
    [FieldOffset(0x1B9)] public byte NumOpenPopups; // used for dialogs and context menus to block inputs via ShouldIgnoreInputs
    [FieldOffset(0x1BA)] public byte Unk1BA;
    [FieldOffset(0x1BB)] public byte Unk1BB;
    [FieldOffset(0x1BC)] public float OpenTransitionScale;
    [FieldOffset(0x1C0)] public float CloseTransitionScale;
    [FieldOffset(0x1C4)] public float Scale;
    /// <summary>
    /// <code>
    /// 0x800 = Disable "Scale Window" option in the title bar context menu
    /// </code>
    /// </summary>
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
    [FieldOffset(0x1D2)] public byte Unk1D2; // index in array of AtkUnitManager+0x9388 (48 * 0x30)
    // 1 byte padding
    [FieldOffset(0x1D4)] public short X;
    [FieldOffset(0x1D6)] public short Y;
    [FieldOffset(0x1D8)] public short OpenTransitionOffsetX;
    [FieldOffset(0x1DA)] public short OpenTransitionOffsetY;
    [FieldOffset(0x1DC)] public short CloseTransitionOffsetX;
    [FieldOffset(0x1DE)] public short CloseTransitionOffsetY;
    [FieldOffset(0x1E0)] public short OpenSoundEffectId;
    [FieldOffset(0x1E2)] public ushort AtkValuesCount;
    [FieldOffset(0x1E4)] public ushort Id;
    [FieldOffset(0x1E6)] public ushort ParentId;
    [FieldOffset(0x1E8)] public ushort HostId; // for example, in CharacterProfile this holds the ID of the Character addon
    [FieldOffset(0x1EA)] public ushort ContextMenuParentId;
    [FieldOffset(0x1EC)] public byte CursorNavigationOwnIndex;
    [FieldOffset(0x1ED)] public byte Alpha;
    [FieldOffset(0x1EE)] public byte ShowHideFlags;
    [FieldOffset(0x1EF)] public bool Unk1EF; // used in Draw
    [FieldOffset(0x1F0)] public AtkResNode** CollisionNodeList; // seems to be all collision nodes in tree, may be something else though
    [FieldOffset(0x1F8)] public uint CollisionNodeListCount;
    [FieldOffset(0x1FC), FixedSizeArray] internal FixedSizeArray5<OperationGuide> _operationGuides; // the little button hints in controller mode

    public uint DepthLayer {
        get => (Flags198 >> 16) & 0xF;
        set => SetDepthLayer(value);
    }

    public bool IsVisible {
        get => (Flags198 & 0x200000) != 0;
        set => Flags198 = value ? Flags198 |= 0x200000 : Flags198 &= 0xFFDFFFFF;
    }

    /// <summary>
    /// Check if OnSetup was called.
    /// </summary>
    public bool IsReady => (Flags1A1 & 0x01) != 0;

    public Span<AtkValue> AtkValuesSpan => new Span<AtkValue>(AtkValues, AtkValuesCount);

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

    [MemberFunction("E8 ?? ?? ?? ?? 66 45 2B E6")]
    public partial float GetGlobalUIScale(); // TODO: should be static

    [MemberFunction("E8 ?? ?? ?? ?? 8D 4B FC")]
    public partial AtkResNode* GetNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 56 1E")]
    public partial AtkTextNode* GetTextNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 55 77")]
    public partial AtkImageNode* GetImageNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 3C 36")]
    public partial AtkComponentButton* GetComponentButtonById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 3C 36"), Obsolete("Renamed to GetComponentButtonById")]
    public partial AtkComponentButton* GetButtonNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 49 89 46 48")]
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
    public partial byte FireCallbackInt(int callbackValue); // TODO: return bool

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 E8 8B 44 24 20")]
    public partial void FireCallback(uint valueCount, AtkValue* values, bool close = false); // TODO: return bool

    [MemberFunction("E8 ?? ?? ?? ?? 32 C0 88 45 67")]
    public partial void UpdateCollisionNodeList(bool clearFocus);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BA E7 14")]
    public partial bool SetFocusNode(AtkResNode* node, bool setCursorFocusNode = false, uint a4 = 0); // a4 = InputId?

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

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 57 47 48 8B CE")]
    public partial void SetCloseTransition(float duration, short offsetX, short offsetY, float scale);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 03 8B D7 4C 8B 83")]
    public partial bool SetAtkValues(uint valueCount, AtkValue* values);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 94 24 ?? ?? ?? ?? 03 96 ?? ?? ?? ??")]
    public partial bool MoveDelta(short* xDelta, short* yDelta);

    [MemberFunction("48 85 D2 74 1A 48 8B 81 ?? ?? ?? ??")]
    public partial bool ContainsNode(AtkResNode* node);

    [VirtualFunction(3)]
    public partial bool Open(uint depthLayer);

    [VirtualFunction(4)]
    public partial bool Close(bool fireCallback);

    [VirtualFunction(5)]
    public partial void Show(bool silenceOpenSoundEffect, uint unsetShowHideFlags);

    [VirtualFunction(6)]
    public partial void Hide(bool unkBool, bool callHideCallback, uint setShowHideFlags);

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

    [VirtualFunction(57)]
    public partial bool HandleCustomInput(AtkEventData.AtkInputData* inputData);

    [VirtualFunction(60)]
    public partial void OnScreenSizeChange(int width, int height);

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

[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public struct OperationGuide {
    [FieldOffset(0x00)] public byte Index; // 0xFF = Disabled
    [FieldOffset(0x01)] public byte PositionFlags;
    [FieldOffset(0x02)] public short OffsetX;
    [FieldOffset(0x04)] public short OffsetY;

    [FieldOffset(0x08)] public uint AddonTransientId;

    /// <summary> The point of the node to anchor to. </summary>
    /// <remarks> <see cref="PositionFlags"/> mask: 0b0000_1111 </remarks>
    public OperationGuidePoint RelativePoint {
        get => (OperationGuidePoint)(PositionFlags & 0x0F);
        set => PositionFlags = (byte)((PositionFlags & 0xF0) | ((byte)value & 0x0F));
    }

    /// <summary> The point of this OperationGuide. </summary>
    /// <remarks> <see cref="PositionFlags"/> mask: 0b1111_0000 </remarks>
    public OperationGuidePoint Point {
        get => (OperationGuidePoint)((PositionFlags & 0xF0) >> 4);
        set => PositionFlags = (byte)((PositionFlags & 0x0F) | (((byte)value & 0x0F) << 4));
    }
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
