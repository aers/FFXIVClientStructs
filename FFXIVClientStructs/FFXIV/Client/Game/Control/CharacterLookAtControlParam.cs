namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::CharacterLookAtControlParam
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1E0)]
[VirtualTable("4C 8D 25 ?? ?? ?? ?? 41 8D 6E 06 4C 8D 2D ?? ?? ?? ??", 3)]
public partial struct CharacterLookAtControlParam {
    [FieldOffset(0x10)] public CharacterLookAtTargetParam TargetParam;
}
