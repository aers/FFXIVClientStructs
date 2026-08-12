namespace FFXIVClientStructs.FFXIV.Common.Lua;

[GenerateInterop]
[Inherits<LuaState>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct LuaThread {
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 74 24 ?? 8B D8 83 F8 ?? 74")]
    public partial int ResumeWithBool(bool value);
}
