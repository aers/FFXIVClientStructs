using static FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Telepo
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop]
[Inherits<AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct Telepo {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 48 8B 12", 3)]
    public static partial Telepo* Instance();

    [FieldOffset(0x10)] public StdVector<TeleportInfo> TeleportList;
    [FieldOffset(0x28)] public SelectUseTicketInvoker UseTicketInvoker;
    [FieldOffset(0x51)] public bool ActiveTeleportRequest;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4B 10 84 C0 48 8B 01 74 2C")]
    public partial bool Teleport(uint aetheryteId, byte subIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 49 89 47 ?? BA")]
    public partial StdVector<TeleportInfo>* UpdateAetheryteList();

    [MemberFunction("E8 ?? ?? ?? ?? 89 44 24 ?? 49 8D 4D")]
    public partial uint GetTeleportCost([CExporterExcel("Aetheryte")] void* aetheryteRow, short multiplier, bool favored, bool residentArea);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe partial struct SelectUseTicketInvoker {
        [FieldOffset(0x10)] public Telepo* Telepo;

        [FieldOffset(0x1C)] public uint AddonId;

        [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 80 79 ?? 00 41 0F B6 F8 8B F2")]
        public partial bool TeleportWithTickets(uint aetheryteId, byte subIndex);
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct TeleportInfo {
    [FieldOffset(0x00)] public uint AetheryteId;
    [FieldOffset(0x04)] public uint GilCost;
    [FieldOffset(0x08)] public ushort TerritoryId;

    [FieldOffset(0x0C)] public EstateType EstateType;
    [FieldOffset(0x10)] public HouseId HouseId;
    [FieldOffset(0x18)] public byte Ward;
    [FieldOffset(0x19)] public byte Plot;
    [FieldOffset(0x1A)] public byte SubIndex;
    [FieldOffset(0x1B)] public bool IsFavourite;
    [FieldOffset(0x1C)] public bool IsFreeAetheryte;

    public bool IsSharedHouse => Ward > 0 && Plot > 0;
    public bool IsApartment => SubIndex == 128 && !IsSharedHouse;
}
