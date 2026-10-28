using FFXIVClientStructs.FFXIV.Client.Game.Emj;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentEmj
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Emj)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct AgentEmj {
    [FieldOffset(0x28)] public EmjGame* Game;
    [FieldOffset(0x30)] public uint MatchType;

    [GenerateInterop(isInherited: true)]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x330)]
    public partial struct EmjCharaView {
        [FieldOffset(0x318)] public uint EntityId;
        [FieldOffset(0x328)] private float Unk328;
    }

    // Client::UI::Agent::AgentEmj::EmjGame
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xFB8)]
    public unsafe partial struct EmjGame {
        [FieldOffset(0x8)] internal FixedSizeArray5<int> _unk8; // Not sure exactly what this is which is why it doesn't have FixedSizeArray in the attributes list.
        [FieldOffset(0x1C)] internal FixedSizeArray4<byte> _unk1C; // Not sure exactly what this is which is why it doesn't have FixedSizeArray in the attributes list.
        [FieldOffset(0x20)] public EmjGameMemoryManager MemoryManager;
        [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray4<CharaViewContainer> _charaViewContainers;

        [FieldOffset(0xD50)] private Utf8String UnkD50;
        [FieldOffset(0xDB8), FixedSizeArray] internal FixedSizeArray4<Utf8String> _playerNames;

        [FieldOffset(0xF68)] public AgentEmj* Agent;
        [FieldOffset(0xF70)] public UIModuleInterface* UIModule;
        [FieldOffset(0xF80)] public EmjEngine* Engine;

        [FieldOffset(0xFA9)] public byte EmjVoiceNpc;
        [FieldOffset(0xFAB)] public byte EmjCostumeId;

        [GenerateInterop]
        [Inherits<EmjCharaView>]
        [StructLayout(LayoutKind.Explicit, Size = 0x338)]
        public partial struct CharaViewContainer {
            [FieldOffset(0x330)] public LoadState ContainerState;
            [FieldOffset(0x334)] public byte SeatOffset;

            public enum LoadState {
                None = 0,
                Loading = 1,
                Ready = 2,
                HandedOff = 3
            }
        }
    }

    [GenerateInterop(true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public unsafe partial struct EmjGameMemoryManagerInterface {
        [VirtualFunction(0)]
        public partial EmjGameMemoryManagerInterface* Dtor(byte freeFlags);

        /// <summary>
        /// Allocates memory of the specified size in the UI space <see cref="IMemorySpace.GetUISpace"/> .
        /// </summary>
        /// <param name="size">The size of memory to allocate</param>
        /// <returns>Pointer to the allocated memory</returns>
        [VirtualFunction(1)]
        public partial void* Malloc(nuint size);

        [VirtualFunction(2)]
        public partial void Free(void* ptr);
    }

    [GenerateInterop]
    [Inherits<EmjGameMemoryManagerInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public partial struct EmjGameMemoryManager;
}
