using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Component.GUI;
using ValueType = FFXIVClientStructs.FFXIV.Component.GUI.ValueType;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[GenerateInterop]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x28C)]
public unsafe partial struct FishingEventHandler {
	[FieldOffset(0x230)] private int _canFish;	
	public bool CanFish => _canFish != 0;
	
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 49 8B F8 48 8B DA 48 8B F1 41 83 F9 02")]
    public partial AtkValue* ChangeBait(AtkValue* returnValue, AtkValue* value, int arg0);

    /// <summary>
    /// Changes the currently equipped bait.
    /// </summary>
    /// <param name="baitId">ItemId of bait to change to.</param>
    public AtkValue* ChangeBait(int baitId) {
        var returnValue = new AtkValue();
        var baitValue = stackalloc AtkValue[2];
        baitValue[0].SetInt(baitId);
        baitValue[1].SetBool(false);
        return ChangeBait(&returnValue, baitValue, 2);
    }
};
