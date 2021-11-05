using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc {
    [StructLayout(LayoutKind.Explicit, Size = 0x27278)]
    public struct RaptureHotbarModule {
        [FieldOffset(0x90)] public HotBars HotBar;
    }

    [StructLayout(LayoutKind.Sequential, Size = HotBar.Size * 18)]
    public unsafe struct HotBars {
        private fixed byte data[HotBar.Size * 18];

        public HotBar* this[int i] {
            get {
                if (i < 0 || i > 17) return null;
                fixed (byte* p = data) {
                    return (HotBar*)(p + sizeof(HotBar) * i);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = Size)]
    public unsafe struct HotBar {
        public const int Size = HotBarSlot.Size * 16;

        public HotBarSlots Slot;
    }

    [StructLayout(LayoutKind.Sequential, Size = HotBarSlot.Size * 16)]
    public unsafe struct HotBarSlots {
        private fixed byte data[HotBarSlot.Size * 16];

        public HotBarSlot* this[int i] {
            get {
                if (i < 0 || i > 15) return null;
                fixed (byte* p = data) {
                    return (HotBarSlot*)(p + sizeof(HotBarSlot) * i);
                }
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public unsafe struct HotBarSlot {
        public const int Size = 0xE0;
        [FieldOffset(0x00)] public Utf8String PopUpHelp;

        [FieldOffset(0xB8)] public uint CommandId;
        [FieldOffset(0xBC)] public uint IconA;
        [FieldOffset(0xC0)] public uint IconB;

        [FieldOffset(0xC7)] public HotbarSlotType CommandType;
        [FieldOffset(0xC8)] public HotbarSlotType IconTypeA;
        [FieldOffset(0xC9)] public HotbarSlotType IconTypeB;

        [FieldOffset(0xCC)] public int Icon;
        [FieldOffset(0xDF)] public byte IsEmpty; // ?
    }

    public enum HotbarSlotType : byte {
        Empty = 0x00,
        Action = 0x01,
        Item = 0x02,

        EventItem = 0x04,

        Emote = 0x06,
        Macro = 0x07,
        Marker = 0x08,
        CraftAction = 0x09,
        GeneralAction = 0x0A,
        CompanionOrder = 0x0B,
        MainCommand = 0x0C,
        Minion = 0x0D,

        GearSet = 0x0F,
        PetOrder = 0x10,
        Mount = 0x11,
        FieldMarker = 0x12,

        Recipe = 0x14,

        ExtraCommand = 0x18,
        PvPQuickChat = 0x19,
        PvPCombo = 0x1A,
        SquadronOrder = 0x1B,

        PerformanceInstrument = 0x1D,
        Collection = 0x1E,
        FashionAccessory = 0x1F,
        LostFindsItem = 0x20,
    }
}
