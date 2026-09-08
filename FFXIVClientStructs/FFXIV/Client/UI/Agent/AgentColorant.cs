using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentColorant
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Colorant)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x4A0)]
public unsafe partial struct AgentColorant {
    [FieldOffset(0x30)] public ColorantOpenType OpenType;

    [FieldOffset(0x158)] public ColorantCharaView CharaView;
    [FieldOffset(0x490)] public Texture* CharaViewTexture;

    // Client::UI::Agent::AgentColorant::ColorantCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x338)]
    public partial struct ColorantCharaView {
        [FieldOffset(0x318)] private uint Unk318; // a3 passed to vf13, 1 = colorant on retainer?
        [FieldOffset(0x31C)] public uint DyeCount; // from agent->field_68
        [FieldOffset(0x320)] public uint EntityId; // of local player
        [FieldOffset(0x324)] public bool DoUpdate;
        [FieldOffset(0x325)] public bool HideOtherEquipment;
        [FieldOffset(0x326)] public bool GearPreview;
        [FieldOffset(0x328)] public bool HeadgearHidden;
        [FieldOffset(0x329)] public bool WeaponHidden;
        [FieldOffset(0x32A)] public bool VisorClosed;
        [FieldOffset(0x32B)] public bool VieraEarsHidden;
        [FieldOffset(0x32C)] public bool IsViera;
        [FieldOffset(0x32D)] public bool DrawWeapon;
        [FieldOffset(0x32E)] private byte Unk32E;
        [FieldOffset(0x32F)] public byte SelectedStain0;
        [FieldOffset(0x330)] public byte SelectedStain1;

        [FieldOffset(0x328), Obsolete("Renamed to HeadgearHidden")] public bool HideVisor;
        [FieldOffset(0x329), Obsolete("Renamed to WeaponHidden")] public bool HideWeapon;
        [FieldOffset(0x32A), Obsolete("Renamed to VisorClosed")] public bool CloseVisor;
        [FieldOffset(0x32F), Obsolete("Renamed to SelectedStain0")] public byte SelectedStain;
    }
}

public enum ColorantOpenType {
    None = 0,
    Unk1 = 1,
    Unk2 = 2,
    HousingGoodsStain = 3,
    AirShipParts = 4,
    TryOn = 5,
    TryOnRetainer = 6,
    MiragePrismPrismBox = 7,
    SubmersibleParts = 8,
    MiragePrismMiragePlate = 9,
    GcArmyMenberProfile = 10,
    MiragePrismENpcSatisfaction = 11,
    HousingCatalogPreview = 12,
    MJIHousingGoodsStain = 13,
    Unk14 = 14, // also HousingCatalogPreview?!
}
