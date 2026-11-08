using System;
using System.Collections.Generic;
using System.Text;
using FFXIVClientStructs.Havok.Common.Base.Math.Vector;
using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Animation.Ik.Ccd;

[Inherits<hkReferencedObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public partial struct hkaCcdIkSolver {
    [FieldOffset(0x10)] public int m_iterations;
    [FieldOffset(0x14)] public float m_gain;

    [StructLayout(LayoutKind.Explicit, Size = 0x14)]
    public struct IkConstraint {
        [FieldOffset(0x00)] public short m_startBone;
        [FieldOffset(0x02)] public short m_endBone;
        [FieldOffset(0x04)] public hkVector4f m_targetMS;
    }
}
