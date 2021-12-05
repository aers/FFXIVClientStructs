using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object
{
    [StructLayout(LayoutKind.Explicit, Size = 0x27E0)]
    public unsafe partial struct GameObjectManager
    {
        [FieldOffset(0x04)] public byte Active;
        [FieldOffset(0x18)] public fixed long ObjectList[424]; // size 424 * 8
        [FieldOffset(0xD58)] public fixed long ObjectListFiltered[424];
        [FieldOffset(0x1A98)] public fixed long ObjectList3[424];
        [FieldOffset(0x27D8)] public int ObjectListFilteredCount;
        [FieldOffset(0x27DC)] public int ObjectList3Count;

        [StaticAddress("48 8D 35 ?? ?? ?? ?? 81 FA")]
        public static partial GameObjectManager* Instance();

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 75 12 48 FF C7", IsStatic = true)]
        public static partial GameObject* GetGameObjectByIndex(int index);
    }
}