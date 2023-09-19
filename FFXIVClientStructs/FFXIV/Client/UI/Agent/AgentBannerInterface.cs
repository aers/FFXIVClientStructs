using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentBannerParty
//   Client::UI::Agent::AgentBannerInterface
//     Client::UI::Agent::AgentInterface
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentBannerInterface {
    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public Storage* Data;

    // Client::UI::Agent::AgentBannerInterface::Storage
    // Destroyed in Client::UI::Agent::AgentBannerInterface::dtor
    [StructLayout(LayoutKind.Explicit, Size = 0x3B30)]
    public partial struct Storage {
        public const int CharacterDataSize = 0x760;

        // vtable: 48 8D 05 ?? ?? ?? ?? 48 89 01 48 8B F9 7E 
        // dtor: E8 ?? ?? ?? ?? 48 83 EF ?? 75 ?? BA ?? ?? ?? ?? 48 8B CE E8 ?? ?? ?? ?? 48 89 7D
        [StructLayout(LayoutKind.Explicit, Size = CharacterDataSize)]
        public struct CharacterData {
            [FieldOffset(0x000)] public void** vtbl;

            [FieldOffset(0x018)] public Utf8String Name1;
            [FieldOffset(0x080)] public Utf8String Name2;
            [FieldOffset(0x0E8)] public Utf8String UnkString1;
            [FieldOffset(0x150)] public Utf8String UnkString2;
            [FieldOffset(0x1C0)] public Utf8String Job;
            [FieldOffset(0x238)] public uint WorldId;
            [FieldOffset(0x240)] public Utf8String UnkString3;

            [FieldOffset(0x2B0)] public void* CharaView;
            [FieldOffset(0x5D0)] public AtkTexture AtkTexture;

            [FieldOffset(0x6E0)] public Utf8String Title;
            [FieldOffset(0x750)] public void* SomePointer;

        }

        [FieldOffset(0x0000)] public void* Agent; // AgentBannerParty, maybe other Banner agents
        [FieldOffset(0x0008)] public UIModule* UiModule;
        [FieldOffset(0x0010)] public uint Unk1; // Maybe count or bitfield, but probably not
        [FieldOffset(0x0014)] public uint Unk2;

        public const int NumCharacters = 8;

        [FixedSizeArray<CharacterData>(NumCharacters)]
        [FieldOffset(0x20)] public fixed byte CharacterArray[CharacterDataSize * NumCharacters];

        [FieldOffset(0x3B20)] public long Unk3;
        [FieldOffset(0x3B28)] public long Unk4;
    }
}
