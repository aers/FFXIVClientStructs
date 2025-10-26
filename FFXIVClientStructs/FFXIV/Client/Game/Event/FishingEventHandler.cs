using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Component.GUI;
using ValueType = FFXIVClientStructs.FFXIV.Component.GUI.ValueType;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

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
};
