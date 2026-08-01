using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.MassivePcContent;

// Client::Game::MassivePcContent::MassivePcContentDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<Director>]
[StructLayout(LayoutKind.Explicit, Size = 0x918)]
public unsafe partial struct MassivePcContentDirector {
    [FieldOffset(0x600), FixedSizeArray] internal FixedSizeArray2<StdVector<MassivePcContentTodo>> _massivePcContentTodos;

    /// <summary>Processes updates specific for this director. This handles the categories between 0 and 0x80000000.</summary>
    [VirtualFunction(325)]
    public partial void ProcessDirectorSpecificDirectorUpdate(uint category, uint* parameters);

    /// <summary>Processes updates shared between all content (e.g. setting the background music). This handles categories above 0x80000000.</summary>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 81 C2 ?? ?? ?? ?? 41 8B F8")]
    public partial void ProcessCommonDirectorUpdate(uint category, uint arg1, uint arg2, uint arg3, uint arg4);
}
