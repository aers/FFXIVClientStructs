using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentBase
//   Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 0
// base class for UI components that are more complicated than a single node
[GenerateInterop(isInherited: true)]
[Inherits<AtkEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct AtkComponentBase : ICreatable {
    [FieldOffset(0x08)] public AtkUldManager UldManager;
    [FieldOffset(0x98)] public uint ComponentFlags; // & 1 = UldLoaded, & 2 = Interactable/Enabled?
    [FieldOffset(0xA0)] public AtkResNode* AtkResNode;
    [FieldOffset(0xA8)] public AtkComponentNode* OwnerNode;
    [FieldOffset(0xB0)] public int SoundEffectId;
    [FieldOffset(0xB4)] public AtkCursorNavigationInfo CursorNavigationInfo;

    [MemberFunction("48 8D 05 ?? ?? ?? ?? C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 01 33 C0 48 89 41 08")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 0E 75 2B")]
    public partial ComponentType GetComponentType();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 53 F8")]
    public partial AtkResNode* GetNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 54 B5 D7")]
    public partial AtkComponentBase* GetComponentById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 53 47")]
    public partial AtkResNode* GetImageNodeById(uint id); // TODO: return AtkImageNode*

    [MemberFunction("E8 ?? ?? ?? ?? 49 63 D7")]
    public partial AtkResNode* GetTextNodeById(uint id); // TODO: return AtkTextNode*

    [MemberFunction("E8 ?? ?? ?? ?? 8B 53 F8"), Obsolete("This function has not type check at all. Use GetNodeById instead.")]
    public partial AtkResNode* GetScrollBarNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 57 01 48 89 43 10")]
    public partial AtkUldAsset* GetUldAssetByImageNodeId(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 41 3A C6 74 22"), Obsolete("This is a AtkResNode function and won't work on components. Use AtkResNode.IsAnimated.", true)]
    public partial bool IsAnimated();

    [MemberFunction("48 85 D2 74 19 48 8B 81")]
    public partial bool IsOwnerNodeAncestorOf(AtkResNode* node);

    [MemberFunction("E8 ?? ?? ?? ?? 66 44 39 A3 ?? ?? ?? ?? 74 07")]
    public partial void CopyCursorNavigationInfoFrom(AtkComponentBase* component);

    [MemberFunction("E8 ?? ?? ?? ?? B3 05")]
    public partial void SetCursorNavigationInfo(AtkCursorNavigationInfo* cursorNavigationInfo, AtkCursorNavigationStopFlag stopFlags = AtkCursorNavigationStopFlag.None);

    [MemberFunction("E8 ?? ?? ?? ?? 4A 8B 0C 26")]
    public partial void ClearCursorNavigationInfo(bool clearStopFlags);

    [MemberFunction("E8 ?? ?? ?? ?? 41 B0 F0")]
    public partial void SetCursorNavigationIndex(AtkCursorNavigationDirection direction, byte index);

    [MemberFunction("48 8B 81 ?? ?? ?? ?? 44 8B 80 ?? ?? ?? ?? 41 8B C0")]
    public partial AtkCursorNavigationStopFlag GetCursorNavigationStopFlags();

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 57 59")]
    public partial void SetAtkResNodeById(uint id);

    [VirtualFunction(3)]
    public partial void Initialize();

    [VirtualFunction(4)]
    public partial void Deinitialize();

    [VirtualFunction(5)]
    public partial void Update(float delta);

    [VirtualFunction(5), Obsolete("Renamed to Update")]
    public partial void OnUldUpdate(float delta);

    [VirtualFunction(7)]
    public partial void Draw();

    [VirtualFunction(8)]
    public partial void Setup();

    [VirtualFunction(10)]
    public partial void SetEnabledState(bool enabled);

    [VirtualFunction(14)]
    public partial AtkResNode* GetAtkResNode();

    [VirtualFunction(15)]
    public partial AtkResNode* GetFocusNode();

    [VirtualFunction(17)]
    public partial void InitializeFromComponentData(void* data); // AtkUldComponentDataBase* ?

    public AtkResNode* GetResNodeById(uint id) {
        var node = GetNodeById(id);
        return node != null && node->GetNodeType() == NodeType.Res ? node : null;
    }

    // GetImageNodeById already exists as MemberFunction
    // GetTextNodeById already exists as MemberFunction

    public AtkNineGridNode* GetNineGridNodeById(uint id) {
        var node = GetNodeById(id);
        return node != null ? node->GetAsAtkNineGridNode() : null;
    }

    public AtkCounterNode* GetCounterNodeById(uint id) {
        var node = GetNodeById(id);
        return node != null ? node->GetAsAtkCounterNode() : null;
    }

    public AtkCollisionNode* GetCollisionNodeById(uint id) {
        var node = GetNodeById(id);
        return node != null ? node->GetAsAtkCollisionNode() : null;
    }

    public AtkClippingMaskNode* GetClippingMaskNodeById(uint id) {
        var node = GetNodeById(id);
        return node != null ? node->GetAsAtkClippingMaskNode() : null;
    }
}

// basically the same as AtkUldComponentDataBase
[StructLayout(LayoutKind.Explicit, Size = 0x09)]
public struct AtkCursorNavigationInfo {
    [FieldOffset(0x00)] public byte Index;
    [FieldOffset(0x01)] public byte UpIndex;
    [FieldOffset(0x02)] public byte DownIndex;
    [FieldOffset(0x03)] public byte LeftIndex;
    [FieldOffset(0x04)] public byte RightIndex;
    [FieldOffset(0x05)] public byte CursorType; // 0 = east, 1 = south-east (seen in Emj addon)
    [FieldOffset(0x06)] public byte OffsetX;
    [FieldOffset(0x07)] public byte OffsetY;
    [FieldOffset(0x08)] public byte Unk08;
}

public enum AtkCursorNavigationDirection {
    Left = 0,
    Right = 1,
    Up = 2,
    Down = 3
}

/// <summary> Stop flags for rapid cursor advancement. </summary>
[Flags]
public enum AtkCursorNavigationStopFlag {
    None = 0,
    Left = 1 << 0,
    Right = 1 << 1,
    Up = 1 << 2,
    Down = 1 << 3
}
