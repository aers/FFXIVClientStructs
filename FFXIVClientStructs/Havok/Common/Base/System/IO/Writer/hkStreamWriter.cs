using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Common.Base.System.IO.Writer;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct hkStreamWriter {
    [FieldOffset(0x0)] public hkReferencedObject hkReferencedObject;
}
