using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentBannerParty
//   Client::UI::Agent::AgentBannerInterface
//     Client::UI::Agent::AgentInterface
//       Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.BannerParty)]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentBannerParty
{
    public static AgentBannerParty* Instance() => (AgentBannerParty*)Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.BannerParty);


    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0x28)] public Storage* Data;

    // Client::UI::Agent::AgentBannerInterface::Storage
    // ctor E8 ?? ?? ?? ?? 48 8B F0 48 89 73 ?? C6 06
    // destructed in Client::UI::Agent::AgentBannerInterface::dtor
    [StructLayout(LayoutKind.Explicit, Size = 0x3BB0)]
    public struct Storage
    {
        // vtable: 48 8D 05 ?? ?? ?? ?? 48 89 01 48 8B F9 7E 
        // dtor: E8 ?? ?? ?? ?? 48 83 EF ?? 75 ?? BA ?? ?? ?? ?? 48 8B CE E8 ?? ?? ?? ?? 48 89 7D
        [StructLayout(LayoutKind.Explicit, Size = 0x770)]
        public struct Character
        {
            [FieldOffset(0x000)] public void** VTable;

            [FieldOffset(0x2B0)] public void** SomeVTable;
            [FieldOffset(0x2B8)] public int    Unk1;

            [FieldOffset(0x018)] public Utf8String Name1;
            [FieldOffset(0x080)] public Utf8String Name2;
            [FieldOffset(0x0E8)] public Utf8String UnkString1;
            [FieldOffset(0x150)] public Utf8String UnkString2;
            [FieldOffset(0x1C0)] public Utf8String Job;
            [FieldOffset(0x240)] public Utf8String UnkString3;
            [FieldOffset(0x6F8)] public Utf8String Title;

            [FieldOffset(0x2B0)] public CharaView CharaView;

            [FieldOffset(0x5D0)] public AtkTexture AtkTexture;

            [FieldOffset(0x768)] public void* SomePointer;

        }

        [FieldOffset(0x0000)] public void* Agent; // AgentBannerParty, maybe other Banner agents
        [FieldOffset(0x0008)] public UIModule* UiModule;
        [FieldOffset(0x0010)] public uint PortraitBitmask; // Maybe
        [FieldOffset(0x0014)] public uint Unk2;

        [FieldOffset(0x0020)] public Character Character1;
        [FieldOffset(0x0790)] public Character Character2;
        [FieldOffset(0x0F00)] public Character Character3;
        [FieldOffset(0x1670)] public Character Character4;
        [FieldOffset(0x1DE0)] public Character Character5;
        [FieldOffset(0x2550)] public Character Character6;
        [FieldOffset(0x2CC0)] public Character Character7;
        [FieldOffset(0x3430)] public Character Character8;

        [FieldOffset(0x3BA0)] public long  Unk3;
        [FieldOffset(0x3BA8)] public long  Unk4;
    }
}