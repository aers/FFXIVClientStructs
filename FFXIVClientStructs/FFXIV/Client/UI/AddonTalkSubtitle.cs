using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonTalkSubtitle
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("TalkSubtitle")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
public partial struct AddonTalkSubtitle {
    [FieldOffset(0x238)] public Utf8String SubtitleText;
    [FieldOffset(0x2A0)] public uint SubtitleMaxWidth;
    [FieldOffset(0x2A4)] public float SubtitleScale;
    /// <remarks> Used in OnSetup to not call Show when setting initial AtkValues. </remarks>
    [FieldOffset(0x2A8)] public bool IsShowSuppressed;
    /// <remarks> Checked and set in vf45 to call vf25. Something related to position (HudAnchoringTable). </remarks>
    [FieldOffset(0x2A9)] private bool UnkIsAnchorPending; // not tested
}
