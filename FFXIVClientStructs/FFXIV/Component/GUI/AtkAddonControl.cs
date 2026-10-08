using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkAddonControl
//   Component::GUI::AtkEventTarget
//   Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkEventTarget>, Inherits<AtkEventListener>(8)]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct AtkAddonControl : ICreatable<AtkAddonControl> {
    [FieldOffset(0x10)] public StdList<Pointer<ChildAddonInfo>> ChildAddons;
    [FieldOffset(0x20)] public AtkEventManager EventManager;
    [FieldOffset(0x28)] public AtkUnitBase* ParentAddon;
    [FieldOffset(0x30)] public AtkStage* AtkStage;
    [FieldOffset(0x38)] public AtkCollisionNode* WindowHeaderCollisionNode;
    /// <summary> Index of the child selected by <see cref="SelectTab"/> in <see cref="ChildAddons"/>, or -1 before a selection. </summary>
    [FieldOffset(0x40)] public int SelectedChildIndex;
    /// <summary> Child whose drag handle was pressed, or whose attachment event is being dispatched. </summary>
    [FieldOffset(0x48)] public ChildAddonInfo* DraggingChildAddon;
    /// <summary> Child waiting for its hide transition to complete before attachment. </summary>
    [FieldOffset(0x50)] public ChildAddonInfo* AttachingChildAddon;
    
    [Obsolete("Use AttachingChildAddon")]
    [FieldOffset(0x50)] public ChildAddonInfo* TempChildAddonInfoPtr;
    
    [FieldOffset(0x58)] public short DragStartX;
    [FieldOffset(0x5A)] public short DragStartY;
    
    [FieldOffset(0x5C)] public bool IsParentAddonLinked;
    /// <summary> Whether all registered children have completed setup during the current update. </summary>
    [FieldOffset(0x5D)] public bool IsChildSetupComplete;
    /// <summary> Prevents focus changes when an initially attached child completes setup. </summary>
    [FieldOffset(0x5E)] public bool DisableFocusOnChildSetup;

    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 33 C0 48 89 8B")]
    public partial AtkAddonControl* Ctor();

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8D 05 ?? ?? ?? ?? 48 8B F9 48 89 01 48 8D 05 ?? ?? ?? ?? 48 89 41 ?? 48 8B 59")]
    public partial void Destructor();

    /// <summary> Removes all registered children and clears controller events. </summary>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B 59 ?? 48 8B F9 48 8B 03 48 3B C3 74 ?? 0F 1F 80 ?? ?? ?? ?? 4C 8B 40")]
    public partial void Clear();

    /// <summary> Links the controller to its parent and captures the parent's window header collision node. </summary>
    /// <returns> Whether a non-null parent was supplied. </returns>
    [MemberFunction("48 89 51 ?? 48 85 D2 74 ?? 83 8A")]
    public partial bool Initialize(AtkUnitBase* parentAddon);

    [MemberFunction("40 53 55 57 41 57 48 81 EC ?? ?? ?? ?? 48 8B 79")]
    public partial void Update(float deltaTime);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 57 48 83 EC ?? 48 8B 79 ?? 48 8B E9 48 8B 1F 48 3B DF 0F 84")]
    public partial void Draw();

    /// <summary> Removes a child registration and closes its addon. </summary>
    [MemberFunction("48 83 EC ?? 4C 8B 41 ?? 49 8B 00 49 3B C0 74 ?? 4C 8B 50 ?? 49 39 52")]
    public partial void RemoveChildAddon(AtkUnitBase* addon);

    /// <summary> Removes all child registrations during parent finalization. </summary>
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B 59 ?? 0F B6 F2 48 8B F9 48 8B 03 48 3B C3 74 ?? 0F 1F 40")]
    public partial void Finalizer(bool a2 = false);

    /// <summary> Registers an already allocated addon as a child of this controller. </summary>
    /// <param name="addonId">Id of an addon in the loaded units list.</param>
    /// <param name="active">Whether the child's group is initially active.</param>
    /// <param name="allowDetach">Whether dragging the child can detach it.</param>
    /// <param name="tabIndex">Index used by <see cref="SelectTab"/>.</param>
    /// <param name="groupId">Group activated together with this child.</param>
    /// <param name="a7">Unused.</param>
    /// <param name="attached">Whether the child starts attached.</param>
    /// <param name="hideWindowAndFocus">Whether setup hides the child's window node and requests focus.</param>
    /// <param name="additionalFlags">Initial flags for <see cref="ChildAddonInfo.Flags2"/>; bit 2 comes from <paramref name="hideWindowAndFocus"/>.</param>
    /// <returns>The existing or newly allocated registration, or null if the parent or child cannot be resolved.</returns>
    /// <remarks>Child setup completes during <see cref="Update"/>. Attached children use this controller for update and draw.</remarks>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 56 41 54 41 55 41 56 41 57 48 81 EC")]
    public partial ChildAddonInfo* RegisterChildAddon(ushort addonId, bool active, bool allowDetach, int tabIndex, int groupId, int a7, bool attached, bool hideWindowAndFocus, byte additionalFlags);

    /// <summary> Registers the controller's ButtonPress listener on a child's drag handle. </summary>
    [MemberFunction("48 83 EC ?? 4D 8B D0 4D 85 C0")]
    public partial AtkEvent* BindDragHandle(ChildAddonInfo* child, AtkResNode* node);

    /// <summary> Selects a child by tab index, activates its group, and focuses that group's children. </summary>
    /// <returns>0xFFFFFFFF if no child matches. Otherwise, the high word contains the tab index and the low word contains the child id if its group was already active, or zero.</returns>
    [MemberFunction("40 55 57 41 54 48 83 EC ?? 48 8B 79")]
    public partial uint SelectTab(int tabIndex);

    [MemberFunction("48 89 5C 24 ?? 57 41 56 41 57 48 83 EC ?? 48 8B 79")]
    public partial void ShowAllChildren(uint unsetShowHideFlags);

    /// <summary> Hides registered children using the supplied callback and visibility flags. </summary>
    /// <param name="callHideCallback">Whether to invoke each child's hide callback.</param>
    /// <param name="disableTransition">Whether active children also skip the hide transition.</param>
    /// <param name="setShowHideFlags">Visibility flags passed to each child.</param>
    [MemberFunction("E9 ?? ?? ?? ?? CC CC CC CC CC CC CC CC CC CC CC CC CC 40 57 48 83 EC ?? 33 C0")]
    public partial void HideAllChildren(bool callHideCallback, bool disableTransition, uint setShowHideFlags);

    /// <summary> Calls <see cref="AtkUnitBase.Close"/> on each registered child. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 C7 83")]
    public partial void CloseAllChildren(bool fireCallback);

    /// <summary> Calls <see cref="AtkUnitBase.Hide2"/> on each registered child. </summary>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B 79 ?? 48 8B 1F 48 3B DF 74")]
    public partial void Hide2AllChildren();

    [MemberFunction("48 89 5C 24 ?? 48 89 7C 24 ?? 41 54 41 56 41 57 48 83 EC ?? 48 8B 79")]
    public partial void ActivateGroup(int groupId, bool deactivateOtherGroups = true, bool focus = true);

    [MemberFunction("48 8B 49 ?? 48 8B 01 48 3B C1 74 ?? 48 8B 50 ?? F6 42")]
    public partial ChildAddonInfo* GetActiveChildAddonInfo();

    [MemberFunction("48 8B 49 ?? 48 8B 01 48 3B C1 74 ?? 0F 1F 40 ?? 4C 8B 40 ?? 49 39 50")]
    public partial ChildAddonInfo* GetChildAddonInfoByAtkUnitBase(AtkUnitBase* addon);

    /// <summary> Finds the first registration in the specified group. </summary>
    [MemberFunction("48 8B 49 ?? 48 8B 01 48 3B C1 74 ?? 0F 1F 40 ?? 4C 8B 40 ?? 41 39 50")]
    public partial ChildAddonInfo* GetChildAddonInfoByGroupId(int groupId);

    /// <summary> Restores focus to active children in the selected group. </summary>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B 79 ?? 33 D2")]
    public partial void FocusSelectedGroup();

    [MemberFunction("45 8B D0 48 85 D2 74 ?? 48 8B 4A")]
    public partial bool ChildRefresh(ChildAddonInfo* child, uint atkValueCount, AtkValue* atkValues);

    [MemberFunction("4D 8B D0 48 85 D2 74")]
    public partial void ChildRequestedUpdate(ChildAddonInfo* child, NumberArrayData** numberArrayData, StringArrayData** stringArrayData);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8D ?? ?? ?? ?? 48 8B 89 ?? ?? ?? ?? E8 ?? ?? ?? ?? 66 2B B5")]
    public partial void ChildSetSize(ushort width, ushort height, bool includeDetached = false);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 C0 4C 89 64 24 ?? 4C 8B CE 48 8D 8E")]
    public partial AtkEvent* RegisterEvent(AtkEventType eventType, uint eventParam, AtkEventListener* listener, AtkResNode* nodeParam);

    [MemberFunction("48 83 EC ?? 48 83 C1 ?? C6 44 24 ?? ?? E8 ?? ?? ?? ?? 48 83 C4 ?? C3 CC CC CC CC CC CC CC CC CC 48 8B 41 ?? 48 85 C0 74 ?? 0F B7 D2 0F 1F 40 ?? 0F B6 48 ?? 3B CA 74 ?? 48 8B 40 ?? 48 85 C0 75 ?? 32 C0 C3 B0 ?? C3 CC CC CC CC CC CC CC CC CC 48 83 EC")]
    public partial bool UnregisterEvent(AtkEventType eventType, uint eventParam, AtkEventListener* listener);

    [MemberFunction("48 8B 41 ?? 48 85 C0 74 ?? 0F B7 D2 0F 1F 40 ?? 0F B6 48 ?? 3B CA 74 ?? 48 8B 40 ?? 48 85 C0 75 ?? 32 C0 C3 B0 ?? C3 CC CC CC CC CC CC CC CC CC 48 83 EC")]
    public partial bool IsEventRegistered(AtkEventType eventType);

    /// <returns>Whether the event was handled.</returns>
    [MemberFunction("48 83 EC ?? 48 8B 41 ?? 4C 8D 49 ?? 48 85 C0 74 ?? 44 0F B7 02 0F B6 48 ?? 41 3B C8 74 ?? 48 8B 40 ?? 48 85 C0 75 ?? 33 C0 48 83 C4 ?? C3 45 33 C0 49 8B C9 E8 ?? ?? ?? ?? 84 C0 74 ?? B8 ?? ?? ?? ?? 48 83 C4 ?? C3 CC CC CC CC CC CC CC CC CC 48 85 D2")]
    public partial bool DispatchEvent(AtkEventDispatcher.Event* evt);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 87 ?? ?? ?? ?? 48 8B 8C C7")]
    public partial void DetachChildAddon(ChildAddonInfo* child);

    [MemberFunction("48 85 D2 74 ?? 48 8B 42 ?? 48 85 C0 74 ?? 80 4A")]
    public partial void AttachChildAddon(ChildAddonInfo* child);

    /// <summary> Changes attachment flags and the visibility of the attachment-hidden node. </summary>
    /// <remarks>Unlike <see cref="AttachChildAddon"/> and <see cref="DetachChildAddon"/>, this does not show the child.</remarks>
    [MemberFunction("48 85 D2 0F 84 ?? ?? ?? ?? 48 8B 4A ?? 48 85 C9")]
    public partial void SetChildAttachedState(ChildAddonInfo* child, bool attached);

    /// <summary> Unregisters the global MouseUp and MouseMove listeners used during drag detection. </summary>
    /// <remarks>Does not clear <see cref="DraggingChildAddon"/> or <see cref="AttachingChildAddon"/>.</remarks>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 33 C0 4C 8D 49")]
    public partial bool CancelDragListeners();
    
    [MemberFunction("40 56 41 57 48 81 EC ?? ?? ?? ?? F6 42")]
    public partial void CompleteChildSetup(ChildAddonInfo* child);

    /// <summary> Registration and attachment state of a child addon. </summary>
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct ChildAddonInfo {
        [FieldOffset(0x00)] private CStringPointer Unk0; // for example chat tab title
        [FieldOffset(0x08)] public AtkUnitBase* AtkUnitBase;
        /// <summary> Node whose ButtonPress event starts drag detection. </summary>
        [FieldOffset(0x10)] public AtkResNode* DragHandle;
        /// <summary> Node hidden while the child is attached and shown when it detaches. </summary>
        [FieldOffset(0x18)] public AtkResNode* AttachmentHiddenNode;
        [FieldOffset(0x20)] public AtkCollisionNode* CollisionNode;
        [FieldOffset(0x28)] public ushort AddonId;
        /// <summary> Identifies children that activate together. </summary>
        [FieldOffset(0x2C)] public int GroupId;
        [FieldOffset(0x30)] public int TabIndex;
        [FieldOffset(0x34)] public float Scale;
        
        [FieldOffset(0x3C)] public short PositionX;
        [FieldOffset(0x3E)] public short PositionY;
        
        [BitField<bool>(nameof(IsSetupComplete), 0)]
        [BitField<bool>(nameof(IsGroupActive), 1)]
        [BitField<bool>(nameof(AllowDetach), 2)]
        [BitField<bool>(nameof(IsAttached), 3)]
        [BitField<bool>(nameof(WasDragging), 4)]
        [BitField<bool>(nameof(IsAttachmentPending), 5)]
        [BitField<bool>(nameof(InitiallyAttached), 6)]
        [FieldOffset(0x40)] public byte Flags1;
        
        [BitField<bool>(nameof(IsActive), 1)]
        [BitField<bool>(nameof(HideWindowAndFocusOnSetup), 2)]
        [FieldOffset(0x41)] public byte Flags2;
    }
}
