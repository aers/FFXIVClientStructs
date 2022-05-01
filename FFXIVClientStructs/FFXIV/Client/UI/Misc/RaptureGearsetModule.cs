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

    [StructLayout(LayoutKind.Sequential, Size = Size)]
    public struct GearsetItem
    {
        public const int Size = 0x1C;
        public uint ItemID;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
    public struct GearsetEntry
    {
		[StructLayout(LayoutKind.Explicit, Size = GearsetItem.Size * 14)]
		public struct GearsetItemsStruct
		{
			[FieldOffset(GearsetItem.Size * 00)] public GearsetItem MainHand;
			[FieldOffset(GearsetItem.Size * 01)] public GearsetItem OffHand;
			[FieldOffset(GearsetItem.Size * 02)] public GearsetItem Head;
			[FieldOffset(GearsetItem.Size * 03)] public GearsetItem Body;
			[FieldOffset(GearsetItem.Size * 04)] public GearsetItem Hands;
			[FieldOffset(GearsetItem.Size * 05)] public GearsetItem Belt;
			[FieldOffset(GearsetItem.Size * 06)] public GearsetItem Legs;
			[FieldOffset(GearsetItem.Size * 07)] public GearsetItem Feet;
			[FieldOffset(GearsetItem.Size * 08)] public GearsetItem Ears;
			[FieldOffset(GearsetItem.Size * 09)] public GearsetItem Neck;
			[FieldOffset(GearsetItem.Size * 10)] public GearsetItem Wrists;
			[FieldOffset(GearsetItem.Size * 11)] public GearsetItem RingRight;
			[FieldOffset(GearsetItem.Size * 12)] public GearsetItem RightLeft;
			[FieldOffset(GearsetItem.Size * 13)] public GearsetItem SoulStone;		
		}
        [FieldOffset(0x000)] public byte ID;
        [FieldOffset(0x001)] public fixed byte Name[0x2F];
        [FieldOffset(0x31)] public byte ClassJob;
        [FieldOffset(0x32)] public byte GlamourSetLink;
        [FieldOffset(0x34)] public short ItemLevel;
        [FieldOffset(0x37)] public GearsetFlag Flags;
        
        private const int ItemDataOffset = 0x38;
        [FieldOffset(ItemDataOffset)] public fixed byte ItemsData[GearsetItem.Size * 14];
        [FieldOffset(ItemDataOffset)] public GearsetItemsStruct ItemsStruct;
    }
}