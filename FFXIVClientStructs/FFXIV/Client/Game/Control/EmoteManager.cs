using static FFXIVClientStructs.FFXIV.Client.Game.Control.EmoteController;
using static FFXIVClientStructs.FFXIV.Common.Configuration.ConfigBase;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::EmoteManager
//   Common::Configuration::ConfigBase::ChangeEventInterface
[GenerateInterop]
[Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct EmoteManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 40 84 ED 74 18", 3)]
    public static partial EmoteManager* Instance();

    [FieldOffset(0x30)] public float IdlePoseCountdown;

    [FieldOffset(0x3C)] public PoseType IdlePoseType; // 0xFF when not counting down

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 85 F6 74 05")]
    public partial bool CanExecuteEmote(ushort emoteId);

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 ED 74 18")]
    public partial bool ExecuteEmote(ushort emoteId, PlayEmoteOption* playEmoteOption = null);
}
