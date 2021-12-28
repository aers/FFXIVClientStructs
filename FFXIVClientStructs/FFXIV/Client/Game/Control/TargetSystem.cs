using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control
{
    // Client::Game::Control::TargetSystem

    [StructLayout(LayoutKind.Explicit, Size = 0x3D08)]
    public unsafe partial struct TargetSystem
    {
        [FieldOffset(0x80)] public GameObject* Target;
        [FieldOffset(0x88)] public GameObject* SoftTarget;
        [FieldOffset(0x98)] public GameObject* GPoseTarget;        
        [FieldOffset(0xD0)] public GameObject* MouseOverTarget;
        [FieldOffset(0xF8)] public GameObject* FocusTarget;
        [FieldOffset(0x110)] public GameObject* PreviousTarget;
        [FieldOffset(0x140)] public uint TargetObjectId;

        [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 3B C6 0F 95 C0")]
        public static partial TargetSystem* Instance();

        [MemberFunction("E8 ?? ?? ?? ?? 48 3B D8 74 51")]
        public partial uint GetCurrentTargetID();

        [MemberFunction("E8 ?? ?? ?? ?? 48 3B C6 0F 94 C0")]
        public partial GameObject* GetCurrentTarget();

        [MemberFunction("48 85 D2 74 2C 4C 63 89")]
        public partial bool IsObjectInViewRange(GameObject* obj);
    }
}
