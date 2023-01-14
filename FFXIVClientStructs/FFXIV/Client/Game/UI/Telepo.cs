namespace FFXIVClientStructs.FFXIV.Client.Game.UI;
// Client::Game::UI::Telepo

// size = 0x58
// ctor E8 ?? ?? ?? ?? 89 B3 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 8D 05
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct Telepo
{
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x10)] public StdVector<TeleportInfo> TeleportList;
    [FieldOffset(0x28)] public SelectUseTicketInvoker UseTicketInvoker;

    [StaticAddress("48 8D 0D ?? ?? ?? ?? 48 8B 12", 3)]
    public static partial Telepo* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4B 10 84 C0 48 8B 01 74 2C")]
    public partial bool Teleport(uint aetheryteID, byte subIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 46 68 4C 8D 45 50")]
    public partial void* UpdateAetheryteList();
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct TeleportInfo
{
    [FieldOffset(0x00)] public uint AetheryteId;
    [FieldOffset(0x04)] public uint GilCost;
    [FieldOffset(0x08)] public ushort TerritoryId;

    [FieldOffset(0x18)] public byte Ward;
    [FieldOffset(0x19)] public byte Plot;
    [FieldOffset(0x1A)] public byte SubIndex;
    [FieldOffset(0x1B)] public byte IsFavourite;

    public bool IsSharedHouse => Ward > 0 && Plot > 0;
    public bool IsAppartment => SubIndex == 128 && !IsSharedHouse;
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct SelectUseTicketInvoker
{
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x10)] public Telepo* Telepo;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 80 79 ?? 00 41 0F B6 F8 8B F2")]
    public partial bool TeleportWithTickets(uint aetheryteID, byte subIndex);
}