using System;
using System.Collections.Generic;
using System.Text;
using FFXIVClientStructs.Havok.Common.Base.Math.Vector;
using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Animation.Ik.LookAt;

[Inherits<hkReferencedObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct hkaLookAtIkSolver {

    [StructLayout(LayoutKind.Explicit, Size = 0x34)]
    public struct Setup {
        /// <summary>
        /// Forward vector relative to the bone
        /// </summary>
        [FieldOffset(0x00)] public hkVector4f m_fwdLS;
        /// <summary>
        /// Eye position relative to the bone
        /// </summary>
        [FieldOffset(0x10)] public hkVector4f m_eyePositionLS;
        /// <summary>
        /// The limiting cone axis relative to the model
        /// </summary>
        [FieldOffset(0x20)] public hkVector4f m_limitAxisMS;
        /// <summary>
        /// The limit angle in radians
        /// </summary>
        [FieldOffset(0x30)] public float m_limitAngle;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct RangeLimits {
        [FieldOffset(0x00)] public float m_limitAngleUp;
        [FieldOffset(0x04)] public float m_limitAngleDown;
        [FieldOffset(0x08)] public float m_limitAngleLeft;
        [FieldOffset(0x0C)] public float m_limitAngleRight;
        [FieldOffset(0x10)] public hkVector4f m_upAxisMS;
    }
}
