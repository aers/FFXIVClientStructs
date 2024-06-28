using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

public partial struct RaptureHotbarModule {
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public unsafe partial struct Hotbar {
        public const int Size = HotbarSlot.Size * 16;

        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray16<HotbarSlot> _slots;

        /// <summary>
        /// Helper method to return a pointer to a specific HotbarSlot, as certain APIs are much happier with a
        /// pointer rather than a fixed reference.
        /// </summary>
        /// <param name="id">A hotbar slot ID between 0 and 15.</param>
        /// <returns>Returns a pointer to a HotbarSlot, or null if an invalid ID was passed.</returns>
        public HotbarSlot* GetHotbarSlot(uint id) {
            if (id > 15) return null;

            return (HotbarSlot*)Unsafe.AsPointer(ref Slots[(int)id]);
        }
    }
}
