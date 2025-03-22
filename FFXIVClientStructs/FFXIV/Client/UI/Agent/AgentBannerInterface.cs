using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentBannerInterface
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop(isInherited: true)]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentBannerInterface {
    [FieldOffset(0x28)] public Storage* Data;

    // Client::UI::Agent::AgentBannerInterface::Storage
    // Destroyed in Client::UI::Agent::AgentBannerInterface::dtor
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x3E30)]
    public partial struct Storage {
        public const int CharacterDataSize = 0x7C0;

        // vtable: "48 8D 05 ?? ?? ?? ?? C6 41 08 00 48 89 01 48 8B D9 C6 41 10 00"
        [StructLayout(LayoutKind.Explicit, Size = CharacterDataSize)]
        public struct CharacterData {
            [FieldOffset(0x018)] public Utf8String Name1;
            [FieldOffset(0x080)] public Utf8String Name2;
            [FieldOffset(0x0E8)] public Utf8String UnkString1;
            [FieldOffset(0x150)] public Utf8String UnkString2;
            [FieldOffset(0x1C0)] public Utf8String Job;
            [FieldOffset(0x238)] public uint WorldId;
            [FieldOffset(0x240)] public Utf8String UnkString3;

            [FieldOffset(0x2B0)] public CharaViewPortrait CharaView;

            [FieldOffset(0x740)] public Utf8String Title;
            [FieldOffset(0x7B0)] public void* SomePointer;
        }

        [FieldOffset(0x0000)] public AgentInterface* Agent; // AgentBannerParty, maybe other Banner agents
        [FieldOffset(0x0008)] public UIModule* UIModule;
        //[FieldOffset(0x0010)] public uint Unk1; // Maybe count or bitfield, but probably not
        //[FieldOffset(0x0014)] public uint Unk2;

        public const int NumCharacters = 8;

        [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray8<CharacterData> _characters;

        [FieldOffset(0x3B20), Obsolete("Do not use maps to numbers inside of Characters array", true)] public long Unk3;
        [FieldOffset(0x3B28), Obsolete("Do not use maps to numbers inside of Characters array", true)] public long Unk4;
    }
}
