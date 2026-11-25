namespace FFXIVClientStructs.Interop.NvAPI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0)]
public unsafe partial struct NvAPI {
    [MemberFunction("E8 ?? ?? ?? ?? 89 44 24 ?? 83 7C 24 ?? ?? 75")]
    public static partial int GetOrLoadModule(void** outHModule); // returns NvAPI_Status
}
