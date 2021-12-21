using System;
using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc {

    [StructLayout(LayoutKind.Explicit, Size = 0xB148)]
    public unsafe struct RaptureGearsetModule {

        public static RaptureGearsetModule* Instance() => Framework.Instance()->GetUiModule()->GetRaptureGearsetModule();

        [FieldOffset(0x0000)] public void* vtbl;
        [FieldOffset(0x0030)] public fixed byte ModuleName[16];
        [FieldOffset(0x0048)] public Gearsets Gearset;

        [StructLayout(LayoutKind.Sequential, Size = 0xAF2C)]
        public struct Gearsets {
            private fixed byte data[0xAF2C];
            public GearsetEntry* this[int i] {
                get {
                    if (i is < 0 or > 100) return null;
                    fixed (byte* p = data) {
                        return (GearsetEntry*)(p + sizeof(GearsetEntry) * i);
                    }
                }
            }
        }

        [Flags]
        public enum GearsetFlag : byte {
            Exists = 0x01,
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x1C)]
        public struct GearsetItem {
            public uint ItemID;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x1BC)]
        public struct GearsetEntry {
            [FieldOffset(0x000)] public byte ID;
            [FieldOffset(0x001)] public fixed byte Name[0x2F];
            [FieldOffset(0x31)] public byte ClassJob;
            [FieldOffset(0x32)] public byte GlamourSetLink;
            [FieldOffset(0x33)] public GearsetFlag Flags;

            [FieldOffset(0x34)] public fixed byte ItemsData[0x188];
            [FieldOffset(0x34)] public GearsetItem MainHand;
            [FieldOffset(0x50)] public GearsetItem OffHand;
            [FieldOffset(0x6C)] public GearsetItem Head;
            [FieldOffset(0x88)] public GearsetItem Body;
            [FieldOffset(0xA4)] public GearsetItem Hands;
            [FieldOffset(0xC0)] public GearsetItem Belt;
            [FieldOffset(0xDC)] public GearsetItem Legs;
            [FieldOffset(0xF8)] public GearsetItem Feet;
            [FieldOffset(0x114)] public GearsetItem Ears;
            [FieldOffset(0x130)] public GearsetItem Neck;
            [FieldOffset(0x14C)] public GearsetItem Wrists;
            [FieldOffset(0x168)] public GearsetItem RingRight;
            [FieldOffset(0x184)] public GearsetItem RightLeft;
            [FieldOffset(0x1A0)] public GearsetItem SoulStone;
        }
    }
}
