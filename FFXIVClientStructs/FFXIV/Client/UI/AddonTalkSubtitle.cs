using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonTalkSubtitle
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("TalkSubtitle")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
public unsafe partial struct AddonTalkSubtitle {
    [FieldOffset(0x238)] public Utf8String SubtitleText;
    [FieldOffset(0x2A0)] public uint SubtitleMaxWidth;
    [FieldOffset(0x2A4)] public float SubtitleScale;
    [FieldOffset(0x2A8)] private bool Unk2A8;    //  If set, vf40 gets called when setting subtitle.
    [FieldOffset(0x2A9)] private bool Unk2A9;    //  Checked and set in vf45 to call vf25.
}
