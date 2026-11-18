using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.Havok.Animation.Ik.Ccd;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Animation;

/// <summary>
/// Moves chains of bones in a Skeleton so that the end of the chains reach a target position.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct ChainIkModule {
    [FieldOffset(0x00)] public hkaCcdIkSolver Solver;
    [FieldOffset(0x18)] public Skeleton* Skeleton;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray4<IkChain> _chains;

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct IkChain {
        [FieldOffset(0x00)] public short StartBone;
        [FieldOffset(0x02)] public short EndBone;

        [FieldOffset(0x10)] public Vector4 TargetPosition;
        [FieldOffset(0x20)] internal float Unk20;
        [FieldOffset(0x24)] internal float Unk24;
        [FieldOffset(0x28)] public byte Flags;
    }
}
