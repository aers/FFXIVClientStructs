using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::FishingEventHandler
//   Client::Game::Event::EventHandler
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop]
[Inherits<EventHandler>, Inherits<AtkModuleInterface.AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public unsafe partial struct FishingEventHandler {
    [FieldOffset(0x230)] public bool CanFish;

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
