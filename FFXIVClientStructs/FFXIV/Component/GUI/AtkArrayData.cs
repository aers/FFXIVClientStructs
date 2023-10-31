namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct AtkArrayData {
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x8)] public int Size;
    [FieldOffset(0xC)] public fixed byte SubscribedAddons[16];
    [FieldOffset(0x1C)] public byte Unk1C;
    [FieldOffset(0x1D)] public byte SubscribedAddonsCount;
    /// <remarks>
    /// 0 = No update pending<br/>
    /// 1 = Update subscribed addons (specific flags are checked in AtkUnitManager.UpdateAddonByID)<br/>
    /// 2 = Force update subscribed addons
    /// </remarks>
    [FieldOffset(0x1E)] public byte UpdateState;
    [FieldOffset(0x1F)] public sbyte RefCount; // initialized to -1, used by Agents
}
