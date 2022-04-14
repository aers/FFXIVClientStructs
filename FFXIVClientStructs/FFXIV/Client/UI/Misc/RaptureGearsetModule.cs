using System;
using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[StructLayout(LayoutKind.Explicit, Size = 0xB348)]
public unsafe struct RaptureGearsetModule
{
    public static RaptureGearsetModule* Instance()
    {
        return Framework.Instance()->GetUiModule()->GetRaptureGearsetModule();
    }

    [FieldOffset(0x0000)] public void* vtbl;
    [FieldOffset(0x0030)] public fixed byte ModuleName[16];
    [FieldOffset(0x0048)] public Gearsets Gearset;

    [StructLayout(LayoutKind.Sequential, Size = 0xAF2C)]
    public struct Gearsets
    {
        private fixed byte data[0x1C0 * 100];

        public GearsetEntry* this[int i]
        {
            get
            {
                if (i is < 0 or > 100) return null;
                fixed (byte* p = data)
                {
                    return (GearsetEntry*) (p + sizeof(GearsetEntry) * i);
                }
            }
        }
    }

    [Flags]
    public enum GearsetFlag : byte
    {
        None = 0x00,
        Exists = 0x01,
        Unknown02 = 0x02,
        Unknown04 = 0x04,
        HeadgearVisible = 0x08,
        WeaponsVisible = 0x10,
        VisorEnabled = 0x20,
        Unknown40 = 0x40,
        Unknown80 = 0x80
    }

    [StructLayout(LayoutKind.Sequential, Size = 0x1C)]
    public struct GearsetItem
    {
        public uint ItemID;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
    public struct GearsetEntry
    {
        [FieldOffset(0x000)] public byte ID;
        [FieldOffset(0x001)] public fixed byte Name[0x2F];
        [FieldOffset(0x31)] public byte ClassJob;
        [FieldOffset(0x32)] public byte GlamourSetLink;
        [FieldOffset(0x37)] public GearsetFlag Flags;
        
        private const int ItemDataOffset = 0x38;
        private const int ItemDataSize = 0x1C;
        [FieldOffset(ItemDataOffset)] public fixed byte ItemsData[0x188];
        [FieldOffset(ItemDataOffset + ItemDataSize * 00)] public GearsetItem MainHand;
        [FieldOffset(ItemDataOffset + ItemDataSize * 01)] public GearsetItem OffHand;
        [FieldOffset(ItemDataOffset + ItemDataSize * 02)] public GearsetItem Head;
        [FieldOffset(ItemDataOffset + ItemDataSize * 03)] public GearsetItem Body;
        [FieldOffset(ItemDataOffset + ItemDataSize * 04)] public GearsetItem Hands;
        [FieldOffset(ItemDataOffset + ItemDataSize * 05)] public GearsetItem Belt;
        [FieldOffset(ItemDataOffset + ItemDataSize * 06)] public GearsetItem Legs;
        [FieldOffset(ItemDataOffset + ItemDataSize * 07)] public GearsetItem Feet;
        [FieldOffset(ItemDataOffset + ItemDataSize * 08)] public GearsetItem Ears;
        [FieldOffset(ItemDataOffset + ItemDataSize * 09)] public GearsetItem Neck;
        [FieldOffset(ItemDataOffset + ItemDataSize * 10)] public GearsetItem Wrists;
        [FieldOffset(ItemDataOffset + ItemDataSize * 11)] public GearsetItem RingRight;
        [FieldOffset(ItemDataOffset + ItemDataSize * 12)] public GearsetItem RightLeft;
        [FieldOffset(ItemDataOffset + ItemDataSize * 13)] public GearsetItem SoulStone;
    }
}