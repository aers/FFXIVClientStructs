using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Clip;

// Client::System::Scheduler::Clip::InstanceContentTextClip
[GenerateInterop]
[Inherits<BaseClip>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 33 D2 C7 41 ?? ?? ?? ?? ?? 48 89 51 ?? 88 51 ?? 48 89 51 ?? 48 89 51 ?? 48 89 51 ?? 48 89 51 ?? 48 89 51 ?? 48 89 51 ?? 48 89 51 ?? 48 89 51 ?? 48 89 51 ?? 48 89 51 ?? 89 51 ?? 48 89 51 ?? 89 51 ?? 89 91 ?? ?? ?? ?? C7 41 ?? ?? ?? ?? ?? C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 01 48 8B C1 66 C7 81 ?? ?? ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 88 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? C3", 3, 63)]
public unsafe partial struct InstanceContentTextClip {
    [FieldOffset(0x48), CExporterIgnore] public InstanceContentTextClipData* Data;

    /// <remarks> InstanceContentTextData </remarks>
    [FieldOffset(0x98)] public CStringPointer Text;

    /// <remarks> BNpcName </remarks>
    [FieldOffset(0xA0)] public CStringPointer Speaker;

    [FieldOffset(0xA8)] public uint ResolvedRowId;
    [FieldOffset(0xAC)] public uint ResolvedBNpcNameRowId;
    [FieldOffset(0xB0)] public bool Finished;

    /// <summary>The TalkSubtitle addon ID, or zero when the addon is not open.</summary>
    [FieldOffset(0xB4)] public uint AddonId;

    [FieldOffset(0xB8)] public float ElapsedTime;
    [FieldOffset(0xBC)] public float SubtitleScaleX;
    [FieldOffset(0xC0)] public float SubtitleScaleY;
    [FieldOffset(0xC4)] public float SubtitlePositionX;
    [FieldOffset(0xC8)] public float SubtitlePositionY;

    [VirtualFunction(7)] public partial bool IsFinished();
    [VirtualFunction(16)] public partial bool ResolveText();
    [VirtualFunction(31)] public partial void Publish();

    [MemberFunction("E8 ?? ?? ?? ?? 33 ED 84 C0 0F 84 ?? ?? ?? ?? 48 89 9C 24 ?? ?? ?? ?? 48 8D 44 24 ?? BB")]
    public partial bool UpdateTalkSubtitleLayout(float* scaleX, float* scaleY, float* positionY, float* positionX);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B D9 48 63 EA")]
    public partial void OpenOrUpdateTalkSubtitle(int eventKind, AtkValue* values, uint valueCount);

    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public struct InstanceContentTextClipData {
        [FieldOffset(0x0C)] public InstanceContentTextDisplayMode DisplayMode;
        [FieldOffset(0x10)] public uint RowId;
        [FieldOffset(0x14)] public uint BNpcNameRowId;

        /// <summary>The display duration in seconds.</summary>
        [FieldOffset(0x18)] public float Duration;
    }

    public enum InstanceContentTextDisplayMode : uint {
        /// <summary>Displays the text through UIModule.ShowBattleTalkImage.</summary>
        BattleTalkImage,

        /// <summary>Displays the text in the TalkSubtitle addon.</summary>
        TalkSubtitle,
    }
}
