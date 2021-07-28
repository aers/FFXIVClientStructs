using System.Runtime.InteropServices;
using FFXIVClientStructs.Common;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object
{
    [StructLayout(LayoutKind.Explicit, Size = 0x27E0)]
    public unsafe partial struct GameObjectManager
    {
        [FieldOffset(0x05)] public byte Active;
        [FieldOffset(0x10)] public GameObject** ObjectList; // size 424 * 8
        [FieldOffset(0xD50)] public GameObject** ObjectListFiltered;
        [FieldOffset(0x1A90)] public GameObject** ObjectList3;
        [FieldOffset(0x27D0)] public int ObjectListFilteredCount;
        [FieldOffset(0x27D4)] public int ObjectList3Count;

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 75 12 48 FF C7", IsStatic = true)]
        public static partial GameObject* GetGameObjectByIndex(int index);
    }
}