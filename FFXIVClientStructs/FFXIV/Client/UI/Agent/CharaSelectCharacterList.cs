using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 40 * 0x10)]
public unsafe partial struct CharaSelectCharacterList {
    [StaticAddress("4C 8D 3D ?? ?? ?? ?? 48 8B DA", 3)]
    public static partial CharaSelectCharacterList* Instance();

    [StaticAddress("48 89 2D ?? ?? ?? ?? 48 8B 6C 24", 3, true)]
    public static partial Character* GetCurrentCharacter();

    [MemberFunction("E8 ?? ?? ?? ?? 66 44 89 B6")]
    public static partial void CleanupCharacters();

    [FieldOffset(0), FixedSizeArray] internal FixedSizeArray40<CharaSelectCharacterMapping> _characterMapping;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct CharaSelectCharacterMapping {
    [FieldOffset(0)] public ulong ContentId;
    [FieldOffset(8)] public short ClientObjectIndex; // index in ClientObjectManager
}
