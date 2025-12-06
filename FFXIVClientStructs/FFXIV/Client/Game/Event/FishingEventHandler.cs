using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::FishingEventHandler
//   Client::Game::Event::EventHandler
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop]
[Inherits<EventHandler>, Inherits<AtkModuleInterface.AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public unsafe partial struct FishingEventHandler {
    [FieldOffset(0x220)] private byte Unk_220;
    [FieldOffset(0x228)] public FishingState State;

    /// <remarks>
    /// 4 Hz inverse sawtooth between one and zero.  Latches upon cast.  No clue what it is for.
    /// </remarks>
    [FieldOffset(0x22C)] private float Unk_22C;

    /// <summary>
    /// Whether you are at a fishing hole.
    /// </summary>
    /// <remarks>
    /// Only indicates that you are at a hole, not whether you can actually fish there.  Only updates when on FSH.
    /// </remarks>
    [FieldOffset(0x230)] public bool CanFish;

    /// <remarks>
    /// Returns to false when opportunity is gone (i.e., Spareful Hand is used).
    /// </remarks>
    [FieldOffset(0x231)] public bool CanMoochPreviousCatch;

    /// <remarks>
    /// Returns to false when opportunity is gone (i.e., 15s elapsed).  Ignores skill cooldown.
    /// </remarks>
    [FieldOffset(0x232)] public bool CanMooch2PreviousCatch;

    [FieldOffset(0x233)] public bool CanReleasePreviousCatch;

    /// <remarks>
    /// True while in the process of sitting down or standing up.
    /// </remarks>
    [FieldOffset(0x234)] public bool ChangingPosition;

    [FieldOffset(0x235)] public bool CanIdenticalCastPreviousCatch;
    [FieldOffset(0x236)] public bool CanSurfaceSlapPreviousCatch;
    [FieldOffset(0x237)] private bool Unk_237; // Never seen false.  vf57 actively sets it to true, whatever that does.
    [FieldOffset(0x238)] public FishingBaitFlags CurrentCastBaitFlags;

    /// <summary>
    /// The index into <see cref="SwimBaitItemIds"/> of the currently-selected swimbait.
    /// </summary>
    /// <remarks>
    /// This is -1 when no swimbait has been selected.
    /// </remarks>
    [FieldOffset(0x23C)] public sbyte CurrentSelectedSwimBait;

    /// <summary>
    /// The item IDs of currently-stored swimbait.
    /// </summary>
    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray3<uint> _swimBaitItemIds;

    [FieldOffset(0x24C)] private uint Unk_24C; // Sometimes matches 0x224, but that offset may just be uninitialized padding.

    /// <summary>
    /// Unix time (in milliseconds) for when the current Mooch/Spareful Hand opportunity will cease being available (if ever).
    /// </summary>
    [FieldOffset(0x250)] public long MoochOpportunityExpirationTime;

    /// <summary>
    /// Unix time (in milliseconds) for when actions like Surface Slap will cease being available.
    /// </summary>
    [FieldOffset(0x258)] public long CatchActionExpirationTime;

    // An instance of something that looks like it has a 6-function vtable right before this event handler's vtable.  Probably 0x30 bytes long.
    //[FieldOffset( 0x260 )] private void* vTablePtr;
    //[FieldOffset( 0x268 )] private byte Unk_268;
    //[FieldOffset( 0x270 )] public FishingEventHandler* FishingEventHandlerInstance;
    //[FieldOffset( 0x278 )] private ulong Unk_278;
    //[FieldOffset( 0x280 )] private uint Unk_280;
    //[FieldOffset( 0x284 )] private ulong Unk_284; // Unaligned, but it disassembles as a qword in the constructor, so idk.

    /// <summary>
    /// Changes the currently equipped bait.
    /// </summary>
    /// <param name="baitId">ItemId of bait to change to.</param>
    public AtkValue* ChangeBait(int baitId) {
        var returnValue = new AtkValue();
        var baitValue = stackalloc AtkValue[2];
        baitValue[0].SetInt(baitId);
        baitValue[1].SetBool(false);
        return ReceiveEvent(&returnValue, baitValue, 2, 2);
    }
}

[Flags]
public enum FishingBaitFlags : int {
    Normal = 0,
    AmbitiousLure = 0x1,
    ModestLure = 0x2,
    Mooch = 0x10,
    Swimbait = 0x20,
}

public enum FishingState : int {
    None = 0,
    CastingOut = 1,
    /// <remarks>
    /// Used when fish slips, when there is no bite, briefly after reeling in a fish, and when using Rest.
    /// </remarks>
    PullingPoleIn = 2,
    Quitting = 3,
    /// <summary>
    /// The standby "gathering" condition.
    /// </summary>
    PoleReady = 4,
    Bite = 5,
    /// <remarks>
    /// Includes the subsequent reeling in.
    /// </remarks>
    Hooking = 6,
    ReleasingCatch = 7,
    ConfirmingCollectable = 8,
    /// <remarks>
    /// Only during the action's animation.
    /// </remarks>
    AmbitiousLure = 9,
    /// <remarks>
    /// Only during the action's animation.
    /// </remarks>
    ModestLure = 10,
    Unk_11 = 11,
    /// <remarks>
    /// Or air, sand, etc.; just when you are actually fishing.
    /// </remarks>
    LineInWater = 12,
}
