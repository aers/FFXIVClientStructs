using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::PathLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//     Client::System::Common::NonCopyable
[GenerateInterop(isInherited: true)]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct PathLayoutInstance {
    [FieldOffset(0x30)] public Transform Transform;
    [FieldOffset(0x60)] public ControlPointData* Data;
    [FieldOffset(0x68)] private bool Unk68;

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    [VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 07 4C 8B EE", 3, 88)]
    public partial struct ControlPointData {
        [FieldOffset(0x16)] private ushort Unk16;
        [FieldOffset(0x18)] public ControlPoint* ControlPoints;
        [FieldOffset(0x20)] public short Count;
        [FieldOffset(0x22)] private bool Unk22;
        [FieldOffset(0x30)] public Transform Transform;
        [FieldOffset(0x6C)] private float Unk6C;

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public partial struct ControlPoint {
            [FieldOffset(0x00)] public Vector3 Position;
            [FieldOffset(0x0C)] public ushort Id;
            [FieldOffset(0x0E)] public bool Select;
        }
    }
}
