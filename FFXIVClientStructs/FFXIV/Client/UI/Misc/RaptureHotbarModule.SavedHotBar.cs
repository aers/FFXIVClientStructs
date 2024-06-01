using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

public partial struct RaptureHotbarModule {
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public partial struct SavedHotBarGroup {
        public const int Size = SavedHotBar.Size * 18;

        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray18<SavedHotBar> _hotBars;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public unsafe partial struct SavedHotBar {
        public const int Size = SavedHotBarSlot.Size * 16;

        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray16<SavedHotBarSlot> _slots;
        /// <summary>
        /// Helper method to return a pointer to a specific HotBarSlot, as certain APIs are much happier with a
        /// pointer rather than a fixed reference.
        /// </summary>
        /// <param name="id">A hotbar slot ID between 0 and 15.</param>
        /// <returns>Returns a pointer to a HotBarSlot, or null if an invalid ID was passed.</returns>
        public SavedHotBarSlot* GetSavedHotBarSlot(uint id) {
            if (id > 15) return null;

            return (SavedHotBarSlot*)Unsafe.AsPointer(ref Slots[(int)id]);
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct SavedHotBarSlot {
        public const int Size = 0x05;

        [FieldOffset(0x00)] public HotbarSlotType CommandType;
        [FieldOffset(0x01)] public uint CommandId;
    }
}
