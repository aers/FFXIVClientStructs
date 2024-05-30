using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::CharacterLookAtController
// ctor "48 89 5C 24 ?? 48 8D 05 ?? ?? ?? ?? BA"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x5E0)]
[VirtualTable("48 89 5C 24 ?? 48 8D 05 ?? ?? ?? ?? BA", 8)]
public unsafe partial struct CharacterLookAtController {
    [FieldOffset(0x10)] public BattleChara* OwnerObject;

    /// <remarks>
    /// 0 = Torso<br/>
    /// 1 = Head<br/>
    /// 2 = Eyes
    /// </remarks>
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray3<CharacterLookAtControlParam> _params;
    [FieldOffset(0x5C4)] public int ParamCount;
}
