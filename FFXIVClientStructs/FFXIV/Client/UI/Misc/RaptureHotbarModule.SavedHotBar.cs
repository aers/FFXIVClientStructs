using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// ToDo: Wrap in RaptureHotbarModule partial struct for namespacing (API 10)

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct SavedHotBarGroup {
    public const int Size = SavedHotBar.Size * 18;

    [FixedSizeArray<SavedHotBar>(18)]
    [FieldOffset(0x00)] public fixed byte HotBars[SavedHotBar.Size * 18];
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct SavedHotBar {
    public const int Size = SavedHotBarSlot.Size * 16;

    [FixedSizeArray<SavedHotBarSlot>(16)]
    [FieldOffset(0x00)] public fixed byte Slots[SavedHotBarSlot.Size * 16];

    /// <summary>
    /// Helper method to return a pointer to a specific HotBarSlot, as certain APIs are much happier with a
    /// pointer rather than a fixed reference.
    /// </summary>
    /// <param name="id">A hotbar slot ID between 0 and 15.</param>
    /// <returns>Returns a pointer to a HotBarSlot, or null if an invalid ID was passed.</returns>
    public SavedHotBarSlot* GetSavedHotBarSlot(uint id) {
        if (id > 15) return null;

        return (SavedHotBarSlot*)Unsafe.AsPointer(ref this.Slots[id]);
    }
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public struct SavedHotBarSlot {
    public const int Size = 0x05;

    [FieldOffset(0x00)] public HotbarSlotType CommandType;
    [FieldOffset(0x01)] public uint CommandId;
}
