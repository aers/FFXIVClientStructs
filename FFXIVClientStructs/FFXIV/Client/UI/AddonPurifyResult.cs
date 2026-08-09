using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonPurifyResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("PurifyResult")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonPurifyResult {
    [FieldOffset(0x238)] public AtkComponentButton* AutomaticButton; // Node 19
    [FieldOffset(0x240)] public short ScaledWidth;
    [FieldOffset(0x242)] public short ScaledHeight;

    public PurifyResultAtkValues* TypedAtkValues => (PurifyResultAtkValues*)AtkValues;

    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 14)]
    public struct PurifyResultAtkValues {
        /// <remarks><see cref="AtkValueType.UInt"/>. Non-zero when the results is shown</remarks>
        [FieldOffset(AtkValue.StructSize * 13)] public AtkValue ResultsMode;
    }
}
