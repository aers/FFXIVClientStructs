using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentWindow
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 2
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct AtkComponentWindow : ICreatable {
    [FieldOffset(0xC0)] public AtkUnitBase* OwnerUnitBase;
    /// <remarks>
    /// [0] = Title<br/>
    /// [1] = Subtitle<br/>
    /// [2] = CloseButton<br/>
    /// [3] = SettingsButton<br/>
    /// [4] = HelpButton<br/>
    /// [5] = Unknown<br/>
    /// [6] = TitleBar<br/>
    /// [7] = Unknown
    /// </remarks>
    [FieldOffset(0xC8), FixedSizeArray] internal FixedSizeArray8<int> _nodeIds;
    [FieldOffset(0xE8)] public AtkCollisionNode* WindowCollisionNode;
    [FieldOffset(0xF0)] public AtkCollisionNode* TitleBarCollisionNode;
    [FieldOffset(0xF8)] public uint TitleTextId;
    [FieldOffset(0xFC)] public uint SubtitleTextId;
    [FieldOffset(0x100)] public float SubtitleOffsetX;
    [FieldOffset(0x104)] public byte ShowFlags;

    // Inlined in 7.0, but still hanging around
    [MemberFunction("33 D2 C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 51 08 48 89 01 0F 57 C0")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 83 FD 4B"), GenerateStringOverloads]
    public partial void SetTitle(CStringPointer title, CStringPointer subtitle);
}
