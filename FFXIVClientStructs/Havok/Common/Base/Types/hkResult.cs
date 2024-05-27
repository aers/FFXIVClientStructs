namespace FFXIVClientStructs.Havok.Common.Base.Types;

[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public struct hkResult {
    public enum hkResultEnum {
        Success = 0,
        Failure = 1,
    }

    [FieldOffset(0x00)] public hkResultEnum Result;
}
