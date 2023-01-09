using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::PronounModule
// ctor E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8B D7 E8 ?? ?? ?? ?? 48 8B 44 24
[StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
public unsafe partial struct PronounModule
{
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? EB 0C")]
    [GenerateCStrOverloads]
    public partial GameObject* ResolvePlaceholder(byte* placeholder, byte unknown0, byte unknown1);
}