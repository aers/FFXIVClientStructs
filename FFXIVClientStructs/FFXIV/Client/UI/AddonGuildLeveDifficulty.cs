using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGuildLeveDifficulty
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GuildLeveDifficulty")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonGuildLeveDifficulty {
    [FieldOffset(0x238)] public AtkComponentSlider* DifficultySlider;
    [FieldOffset(0x240)] public AtkTextNode* DifficultyText;

    public GuildLeveDifficultyAtkValues* TypedAtkValues => (GuildLeveDifficultyAtkValues*)AtkValues;

    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 6)]
    public struct GuildLeveDifficultyAtkValues {
        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 0)] public AtkValue Title;

        /// <remarks><see cref="AtkValueType.Int"/></remarks>
        [FieldOffset(AtkValue.StructSize * 1)] public AtkValue InitialValue;

        /// <remarks><see cref="AtkValueType.UInt"/></remarks>
        [FieldOffset(AtkValue.StructSize * 2)] public AtkValue MinDifficulty;

        /// <remarks><see cref="AtkValueType.UInt"/></remarks>
        [FieldOffset(AtkValue.StructSize * 3)] public AtkValue MaxDifficulty;

        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 4)] public AtkValue DifficultyLabel;

        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 5)] public AtkValue BodyText;
    }
}
