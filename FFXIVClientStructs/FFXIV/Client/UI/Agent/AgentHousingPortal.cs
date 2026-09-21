using FFXIVClientStructs.FFXIV.Client.Game.Network;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHousingPortal
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.HousingPortal)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct AgentHousingPortal {

    [FieldOffset(0x30)] public uint ConfirmAddonId;
    [FieldOffset(0x34)] public ushort PortalMenuAddonId;
    [FieldOffset(0x36)] public ushort WardSelectAddonId;
    
    [FieldOffset(0x38)] public ushort TerritoryType;
    
    [FieldOffset(0x3C)] public int SelectedWardIndex;
    
    [FieldOffset(0x40)] public uint PlotCount;
    [FieldOffset(0x44), FixedSizeArray] internal FixedSizeArray60<byte> _plotOccupied;
    
    /// <summary>
    /// 0 - Personal Estate <br/>
    /// 1 - Free Company Estate <br/>
    /// 2 - Apartment Room <br/>
    /// </summary>
    [FieldOffset(0x80)] public int TeleportEstateType;
    
    [FieldOffset(0x84), FixedSizeArray] internal FixedSizeArray6<uint> _menuActions;
    [FieldOffset(0x9C), FixedSizeArray] public uint MenuItemCount;
    
    [MemberFunction("40 55 53 41 54 41 55 41 57 48 8D AC 24 ?? ?? ?? ?? B8")]
    public partial void ReadPacket(HousingPortalPacket* packet);
    
    [MemberFunction("E8 ?? ?? ?? ?? EB ?? BA ?? ?? ?? ?? EB ?? BA ?? ?? ?? ?? EB ?? 48 8B CE")]
    public partial void SelectWard(uint wardIndex);
    
    /// <summary>
    /// <see cref="TeleportEstateType"/>
    /// </summary>
    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC ?? 8B B1 ?? ?? ?? ?? 48 8B F9 83 FE")]
    public partial void TeleportToOwnEstateWard();
    
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 56 41 57 48 83 EC ?? 48 8B F9 48 8B F2")]
    public partial void ProcessPortalMenuSelect(AtkValue* values);
    
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 56 41 57 48 83 EC ?? 48 8B F1 48 8B DA")]
    public partial void ProcessAction(AtkValue* values);
    
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B D9 33 FF 89 79 ?? 48 8B CA E8 ?? ?? ?? ?? 83 F8 ?? 0F 84")]
    public partial void ProcessMenuConfirm(AtkValue* values);
    
    [MemberFunction("40 53 48 83 EC ?? 48 8B D9 C7 41 ?? ?? ?? ?? ?? 48 8B CA E8 ?? ?? ?? ?? 85 C0 75 ?? 44 8B 43")]
    public partial void ConfirmTeleport(AtkValue* values);
    
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 74 24 ?? B1 ?? EB")]
    public partial void OpenPortalMenu(ushort territoryType, AtkModuleInterface.AtkEventInterface* eventInterface, uint menuAction);
    
    /// <param name="text">Text in SelectYesno</param>
    /// <param name="a3">Doesn't seem to be used</param>
    /// <param name="a4">Doesn't seem to be used</param>
    [MemberFunction("E8 ?? ?? ?? ?? B3 ?? E9 ?? ?? ?? ?? 83 FD")]
    public partial void ShowTeleportConfirm(CStringPointer text, uint callbackEventKind, ushort parentAddonId);
}
