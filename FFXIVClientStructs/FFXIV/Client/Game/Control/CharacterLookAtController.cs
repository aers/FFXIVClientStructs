using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::CharacterLookAtController
// ctor "48 8D 05 ?? ?? ?? ?? 48 8D 71 20"
[GenerateInterop]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8D 71 20", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0xB90)]
public unsafe partial struct CharacterLookAtController {
    [FieldOffset(0x10)] public BattleChara* OwnerObject;

    /// <remarks>
    /// 0 = Torso<br/>
    /// 1 = Head<br/>
    /// 2 = Eyes
    /// </remarks>
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray6<CharacterLookAtControlParam> _params;
    [FieldOffset(0xB64)] public int ParamCount;
}
