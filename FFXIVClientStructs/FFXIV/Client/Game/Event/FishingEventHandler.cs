using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::FishingEventHandler
//   Client::Game::Event::EventHandler
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop]
[Inherits<EventHandler>, Inherits<AtkModuleInterface.AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public unsafe partial struct FishingEventHandler {
    [FieldOffset(0x228)] public FishingState FishingState;
    [FieldOffset(0x22C)] public float Sawtooth; // 4 Hz inverse sawtooth between one and zero.  Latches upon cast.  No clue what it is for.
    [FieldOffset(0x230)] public bool AtFishingHole; // Only updates when on FSH.
    [FieldOffset(0x231)] public bool CanMoochPreviousCatch; // Returns to false when opportunity is gone (i.e., Spareful Hand is used).
    [FieldOffset(0x232)] public bool CanMooch2PreviousCatch; // Returns to false when opportunity is gone (i.e., 15s elapsed).  Ignores skill cooldown.
    [FieldOffset(0x233)] public bool CanReleasePreviousCatch;
    [FieldOffset(0x234)] public bool ChangingPosition; // True while in the process of sitting down or standing up.
    [FieldOffset(0x235)] public bool CanIdenticalCastPreviousCatch;
    [FieldOffset(0x236)] public bool CanSurfaceSlapPreviousCatch;
    [FieldOffset(0x237)] public bool Unk_237; // Never seen false.  vf57 actively sets it to true, whatever that does.
    [FieldOffset(0x238)] public FishingBaitFlags CurrentCastBaitFlags;
    [FieldOffset(0x23C)] public sbyte SelectedSwimBaitIndex; // -1 when none selected.
    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray3<uint> _swimBaitItemIDs;
    [FieldOffset(0x250)] public long MoochOpportunityExpirationTimestamp_mSec; // Unix timestamp in milliseconds for when the current Mooch/Spareful Hand opportunity will cease being available.
    [FieldOffset(0x258)] public long CatchActionExpirationTimestamp_mSec; // Unix timestamp in milliseconds for when actions like Surface Slap will cease being available.

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

public enum FishingState : byte {
    None = 0,
    CastingOut = 1,
    PullingPoleIn = 2,      //	When fish slips, there is no bite, briefly after reeling in a fish, and when using Rest.
    Quitting = 3,
    PoleReady = 4,          //	The standby "gathering" condition.
    Bite = 5,
    Hooking = 6,            //	Includes the subsequent reeling in.
    ReleasingCatch = 7,
    ConfirmingCollectable = 8,
    AmbitiousLure = 9,      //	When using the skill.
    ModestLure = 10,        //	When using the skill.
    Unk_11 = 11,
    LineInWater = 12,		//	Or air, sand, etc.; just when you are actually fishing.
}
