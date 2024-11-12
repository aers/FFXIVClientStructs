namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::ClientObjectManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct ClientObjectManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? C7 43 60 FF FF FF FF", 3)]
    public static partial ClientObjectManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 41 89 44 FC ??")]
    public partial uint CreateBattleCharacter(uint index = 0xFFFFFFFF, byte param = 0);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 54 41 55 41 56 41 57 48 83 EC 20 0F B7 EA")]
    public partial GameObject* GetObjectByIndex(ushort id);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5E 68")]
    public partial uint GetIndexByObject(GameObject* character);

    [MemberFunction("E8 ?? ?? ?? ?? C6 43 49 00")]
    public partial void DeleteObjectByIndex(ushort id, byte param);

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 48 8B CB 83 F8 FF")]
    public partial uint CalculateNextAvailableIndex();
}
