using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.GoldSaucer;

// Client::Game::GoldSaucer::RaceChocoboDirector
//   Client::Game::Event::GoldSaucerDirector
//     Client::Game::Event::Director
//       Client::Game::Event::LuaEventHandler
//         Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<GoldSaucerDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x20C0)]
public unsafe partial struct RaceChocoboDirector {
    [FieldOffset(0x620)] public bool IsTutorial;
    [FieldOffset(0x622)] public bool RacersLoaded;
    [FieldOffset(0x624)] public RaceState State;
    /// <remarks> Seconds, counts up from the value the server sent with the last <see cref="State"/> change. </remarks>
    [FieldOffset(0x628)] public float StateTimer;
    [FieldOffset(0x62C)] public uint ChocoboRaceId;
    [FieldOffset(0x630)] private bool Unk630; // something with the stamina gauge state
    [FieldOffset(0x634)] public float Progress; // 0..1
    [FieldOffset(0x638)] public uint ChocoboRaceTutorialId;

    [FieldOffset(0x12EA)] public sbyte RacerCount;
    [FieldOffset(0x12EB)] public sbyte LocalRacerIndex;
    [FieldOffset(0x12F0), FixedSizeArray] internal FixedSizeArray8<Racer> _racers;

    /// <remarks> ChocoboRaceItem row id. 0 when no item is held. </remarks>
    [FieldOffset(0x2070)] public byte HeldItem;
    [FieldOffset(0x2071)] public byte ItemReelSpins;
    /// <remarks> ChocoboRaceItem row ids </remarks>
    [FieldOffset(0x2072), FixedSizeArray] internal FixedSizeArray8<byte> _itemReel;
    [FieldOffset(0x207A)] public sbyte ItemReelIndex; // the reel is the wheel of items that show when you're near a coffer. -1 when hidden
    /// <remarks> ChocoboRaceAbility row ids </remarks>
    [FieldOffset(0x207B), FixedSizeArray] internal FixedSizeArray3<byte> _abilities;
    [FieldOffset(0x207E), FixedSizeArray] internal FixedSizeArray3<bool> _abilityUsed;

    [FieldOffset(0x2081)] public bool IsAccelerating;
    [FieldOffset(0x2082)] public bool IsTurningLeft;
    [FieldOffset(0x2083)] public bool IsTurningRight;
    [FieldOffset(0x2084)] public bool IsDecelerating;

    [FieldOffset(0x20A8)] private byte NewRank; // LogMessage 4762
    [FieldOffset(0x20A9)] private byte LearnedAbility; // LogMessage 4732

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? 48 8D 9F ?? ?? ?? ??")]
    public partial void HandleInput();

    [MemberFunction("45 33 C9 44 8B C2 41 8D 51 11")]
    public partial void UseItem(uint itemId);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 4C 39 35")]
    public partial void UseAbility(uint abilityId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 33 C0 E9 ?? ?? ?? ?? B8 A5 12 00 00")]
    public partial bool CanUseItem(); // shows LogMessage 4773 on failure

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? B8 A6 12 00 00")]
    public partial bool CanUseAbility(uint abilityId); // shows LogMessage 4774 on failure

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1B0)]
    public unsafe partial struct Racer {
        [FieldOffset(0x08)] public RaceChocoboDirector* Director;
        [FieldOffset(0x10)] public int Index;
        [FieldOffset(0x14)] public uint EntityId;
        [FieldOffset(0x18)] public RacingChocoboNameResolver NameResolver;

        [FieldOffset(0xD4)] public float Stamina; // 0..1
        /// <remarks> Bit N is row N of the ChocoboRaceStatus </remarks>
        [FieldOffset(0xD8)] public uint StatusFlags;

        [FieldOffset(0x110)] public sbyte PreviousRank;
        [FieldOffset(0x111)] public sbyte CurrentPlace; // starts at 0
        [FieldOffset(0x112)] public bool HasFinished;
        [FieldOffset(0x114)] public int FinishTime; // 99999 when DNF

        [FieldOffset(0x120)] public Vector3 Position;
        [FieldOffset(0x130)] public Vector3 PreviousPosition;

        [FieldOffset(0x140)] public bool IsAccelerating;
        [FieldOffset(0x141)] public bool IsDecelerating;
        [FieldOffset(0x144)] public RacerTurn Turn;

        [FieldOffset(0x150)] public Vector3 SmoothedPosition;

        /// <summary> Helper for <see cref="StatusFlags"/> </summary>
        public readonly bool HasStatus(int chocoboRaceStatusId) => (StatusFlags & (1u << chocoboRaceStatusId)) != 0;
    }

    public enum RaceState {
        None = 0,
        Lobby = 1,
        Countdown = 2,
        Racing = 3,
        Results = 4,
    }

    public enum RacerTurn {
        None = 0,
        Left = 1,
        Right = 2,
    }
}
