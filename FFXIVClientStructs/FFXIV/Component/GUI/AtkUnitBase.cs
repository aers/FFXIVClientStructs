using System;
using System.Runtime.InteropServices;
using FFXIVClientStructs.Common;
using FFXIVClientStructs.FFXIV.Component.GUI.ULD;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // Component::GUI::AtkUnitBase
    //   Component::GUI::AtkEventListener

    // base class for all AddonXXX classes (visible UI objects)

    // size = 0x220
    // ctor E8 ? ? ? ? 83 8B ? ? ? ? ? 33 C0 

    [StructLayout(LayoutKind.Explicit, Size = 0x220)]
    public unsafe partial struct AtkUnitBase
    {
        [FieldOffset(0x0)] public AtkEventListener AtkEventListener;
        [FieldOffset(0x8)] public fixed byte Name[0x20];
        [FieldOffset(0x28)] public AtkUldManager UldManager;
        [FieldOffset(0xC8)] public AtkResNode* RootNode;
        [FieldOffset(0x108)] public AtkComponentNode* WindowNode;
        [FieldOffset(0x1AC)] public float Scale;
        [FieldOffset(0x182)] public byte Flags;
        [FieldOffset(0x1BC)] public short X;
        [FieldOffset(0x1BE)] public short Y;
        [FieldOffset(0x1CC)] public short ID;
        [FieldOffset(0x1CE)] public short ParentID;
        [FieldOffset(0x1D5)] public byte Alpha;

        [FieldOffset(0x1D8)]
        public AtkCollisionNode**
            CollisionNodeList; // seems to be all collision nodes in tree, may be something else though

        [FieldOffset(0x1E0)] public uint CollisionNodeListCount;

        public bool IsVisible
        {
            get => (Flags & 0x20) == 0x20;
            set => Flags = value ? Flags |= 0x20 : Flags &= 0xDF;
        }

        [MemberFunction("E8 ?? ?? ?? ?? 0F BF CB 0F 28 F8")]
        public partial float GetScale();

        [MemberFunction("E8 ?? ?? ?? ?? 0F BF 45 00")]
        public partial float GetGlobalUIScale();
    }
}