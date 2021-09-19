using System.Numerics;
using System.Runtime.InteropServices;
using FFXIVClientStructs.STD;

namespace FFXIVClientStructs.FFXIV.Client.Graphics
{
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe struct Matrix44
    {
        [FieldOffset(0x00)] public fixed float Matrix[16];

        [NoExport] [FieldOffset(0x00)] public float Matrix_1_1;
        [NoExport] [FieldOffset(0x04)] public float Matrix_1_2;
        [NoExport] [FieldOffset(0x08)] public float Matrix_1_3;
        [NoExport] [FieldOffset(0x0C)] public float Matrix_1_4;
        [NoExport] [FieldOffset(0x10)] public float Matrix_2_1;
        [NoExport] [FieldOffset(0x14)] public float Matrix_2_2;
        [NoExport] [FieldOffset(0x18)] public float Matrix_2_3;
        [NoExport] [FieldOffset(0x1C)] public float Matrix_2_4;
        [NoExport] [FieldOffset(0x20)] public float Matrix_3_1;
        [NoExport] [FieldOffset(0x24)] public float Matrix_3_2;
        [NoExport] [FieldOffset(0x28)] public float Matrix_3_3;
        [NoExport] [FieldOffset(0x2C)] public float Matrix_3_4;
        [NoExport] [FieldOffset(0x30)] public float Matrix_4_1;
        [NoExport] [FieldOffset(0x34)] public float Matrix_4_2;
        [NoExport] [FieldOffset(0x38)] public float Matrix_4_3;
        [NoExport] [FieldOffset(0x3C)] public float Matrix_4_4;

        public static implicit operator Matrix4x4(Matrix44 matrix) {
            return new Matrix4x4(
                matrix.Matrix_1_1, matrix.Matrix_1_2, matrix.Matrix_1_3, matrix.Matrix_1_4,
                matrix.Matrix_2_1, matrix.Matrix_2_2, matrix.Matrix_2_3, matrix.Matrix_2_4,
                matrix.Matrix_3_1, matrix.Matrix_3_2, matrix.Matrix_3_3, matrix.Matrix_3_4,
                matrix.Matrix_4_1, matrix.Matrix_4_2, matrix.Matrix_4_3, matrix.Matrix_4_4);
        }
    }
}
