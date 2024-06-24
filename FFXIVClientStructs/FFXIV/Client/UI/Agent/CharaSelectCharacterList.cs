using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 40 * 0x10)]
public unsafe partial struct CharaSelectCharacterList {
    [StaticAddress("48 8D 05 ?? ?? ?? ?? 48 89 7C 24 ?? 4C 8D 05 ?? ?? ?? ?? 33 FF 8B CF 66 0F 1F 44 00 ??", 3)]
    public static partial CharaSelectCharacterList* Instance();

    [StaticAddress("75 39 48 8B 0D ?? ?? ?? ?? 48 85 C9", 5, true)]
    public static partial Character* GetCurrentCharacter();

    [MemberFunction("E8 ?? ?? ?? ?? 4D 0F BF 8E ?? ?? ?? ??")]
    public static partial void CleanupCharacters();

    [FieldOffset(0), FixedSizeArray] internal FixedSizeArray40<CharaSelectCharacterMapping> _characterMapping;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct CharaSelectCharacterMapping {
    [FieldOffset(0)] public ulong ContentId;
    [FieldOffset(8)] public short ClientObjectIndex; // index in ClientObjectManager
}
