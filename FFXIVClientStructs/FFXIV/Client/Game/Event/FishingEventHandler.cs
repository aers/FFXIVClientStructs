using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::FishingEventHandler
//   Client::Game::Event::EventHandler
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop]
[Inherits<EventHandler>, Inherits<AtkModuleInterface.AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public unsafe partial struct FishingEventHandler {
    [FieldOffset(0x228)] public FishingState State;
    [FieldOffset(0x230)] public bool CanFish;
    [FieldOffset(0x23C)] public byte CurrentSelectedSwimBait;
    [FieldOffset(0x240)] public uint SwimBaitId1;
    [FieldOffset(0x244)] public uint SwimBaitId2;
    [FieldOffset(0x248)] public uint SwimBaitId3;

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

    public enum FishingState : byte {
        NotFishing = 0,
        PoleOut = 1,
        PullPoleIn = 2,
        Quit = 3,
        PoleReady = 4,
        Bite = 5,
        Reeling = 6,
        Waiting = 8,
        NormalFishing = 9,
        LureFishing = 12,
    }
}
