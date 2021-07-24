using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control
{
    // Client::Game::Control::TargetSystem

    [StructLayout(LayoutKind.Explicit, Size = 0x3D08)]
    public unsafe struct TargetSystem
    {
        [FieldOffset(0x80)] public GameObject* Target;
        [FieldOffset(0x88)] public GameObject* SoftTarget;
        [FieldOffset(0xD0)] public GameObject* MouseOverTarget;
        [FieldOffset(0xF8)] public GameObject* FocusTarget;
        [FieldOffset(0x110)] public GameObject* PreviousTarget;
        [FieldOffset(0x140)] public uint TargetObjectId;
    }
}
