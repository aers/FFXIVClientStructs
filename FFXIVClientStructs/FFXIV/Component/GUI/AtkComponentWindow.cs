namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentWindow
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 2
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct AtkComponentWindow {
    [FieldOffset(0xC0)] public AtkUnitBase* UnitBase;
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
    [FieldOffset(0xF0)] public AtkCollisionNode* TitlebarCollisionNode;
    [FieldOffset(0xF8)] public uint TitleTextId;
    [FieldOffset(0xFC)] public uint SubtitleTextId;
    [FieldOffset(0x100)] public float SubtitleOffsetX;
    [FieldOffset(0x104)] public byte ShowFlags;
}
