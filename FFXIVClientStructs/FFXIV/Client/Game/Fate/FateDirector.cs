using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.Fate {
    [StructLayout(LayoutKind.Explicit, Size = 0x4f8)]
    public unsafe partial struct FateDirector {
        [FieldOffset(0x00)] public Director Director;
        
        [FieldOffset(0x4B8)] public byte FateLevel;
        [FieldOffset(0x4C0)] public uint FateNpcObjectId;
        [FieldOffset(0x4CC)] public ushort FateId;

        [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 03 48 8B CB FF 90 ?? ?? ?? ?? 48 8D 0D", isPointer: true)]
        public static partial FateDirector* Instance();
    }
}