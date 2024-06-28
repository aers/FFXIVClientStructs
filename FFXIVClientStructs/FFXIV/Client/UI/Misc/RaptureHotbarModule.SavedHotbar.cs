using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

public partial struct RaptureHotbarModule {
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public partial struct SavedHotbarGroup {
        public const int Size = SavedHotbar.Size * 18;

        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray18<SavedHotbar> _hotBars;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public unsafe partial struct SavedHotbar {
        public const int Size = SavedHotbarSlot.Size * 16;

        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray16<SavedHotbarSlot> _slots;
        /// <summary>
        /// Helper method to return a pointer to a specific HotbarSlot, as certain APIs are much happier with a
        /// pointer rather than a fixed reference.
        /// </summary>
        /// <param name="id">A hotbar slot ID between 0 and 15.</param>
        /// <returns>Returns a pointer to a <see cref="SavedHotbarSlot"/>, or null if an invalid ID was passed.</returns>
        public SavedHotbarSlot* GetSavedHotbarSlot(uint id) {
            if (id > 15) return null;

            return (SavedHotbarSlot*)Unsafe.AsPointer(ref Slots[(int)id]);
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct SavedHotbarSlot {
        public const int Size = 0x05;

        [FieldOffset(0x00)] public HotbarSlotType CommandType;
        [FieldOffset(0x01)] public uint CommandId;
    }
}
