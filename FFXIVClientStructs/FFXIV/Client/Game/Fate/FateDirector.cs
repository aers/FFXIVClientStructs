using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Fate {
    [StructLayout(LayoutKind.Explicit, Size = 0x4f8)]
    public unsafe partial struct FateDirector {
        [FieldOffset(0x210)] public LuaState* LuaState;
        
        [FieldOffset(0x350)] public Utf8String FateName;
        [FieldOffset(0x3B8)] public Utf8String FateDescription;
        
        [FieldOffset(0x4B8)] public byte FateLevel;
        [FieldOffset(0x4C0)] public uint FateNpcObjectId;
        [FieldOffset(0x4CC)] public ushort FateId;

        [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 03 48 8B CB FF 90 ?? ?? ?? ?? 48 8D 0D", isPointer: true)]
        public static partial FateDirector* Instance();
    }
}