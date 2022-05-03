using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonActionBarBase {
    [FieldOffset(0x00)] public AtkUnitBase AtkUnitBase;

    [VirtualFunction(76)]
    public partial void PulseActionBarSlot(int slotIndex);
}