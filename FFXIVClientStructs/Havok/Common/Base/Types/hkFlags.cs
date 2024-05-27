namespace FFXIVClientStructs.Havok.Common.Base.Types;

[StructLayout(LayoutKind.Sequential)]
public struct hkFlags<T, U> where T : unmanaged, Enum where U : unmanaged {
    public U Storage;
}
