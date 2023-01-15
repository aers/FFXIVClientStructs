namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct ClientObjectManager
{
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? C7 43 60 FF FF FF FF", 3)]
    public static partial ClientObjectManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 FF 74 C3")]
    public partial uint CreateBattleCharacter(uint index = 0xFFFFFFFF, byte param = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 74 4E 48 8B 10")]
    public partial GameObject* GetObjectByIndex(ushort id);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5E ?? 8B E8")]
    public partial uint GetIndexByObject(GameObject* character);

    [MemberFunction("E8 ?? ?? ?? ?? C7 07 ?? ?? ?? ?? 48 8B 05")]
    public partial void DeleteObjectByIndex(ushort id, byte param);

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 83 F8 FF 75 12")]
    public partial uint CalculateNextAvailableIndex();
}
