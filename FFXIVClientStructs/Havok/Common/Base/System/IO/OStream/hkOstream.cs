using FFXIVClientStructs.Havok.Common.Base.Object;
using FFXIVClientStructs.Havok.Common.Base.System.IO.Writer;
using FFXIVClientStructs.Havok.Common.Base.Types;

namespace FFXIVClientStructs.Havok.Common.Base.System.IO.OStream;

[GenerateInterop]
[Inherits<hkReferencedObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct hkOstream {
    [FieldOffset(0x10)] public hkRefPtr<hkStreamWriter> StreamWriter;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 C7 41 ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 01 48 8B F9 48 C7 41 ?? ?? ?? ?? ?? 4C 8B C2 48 8B 0D ?? ?? ?? ?? 48 8D 54 24 ?? 41 B9 ?? ?? ?? ?? 48 8B 01 FF 50 28"), GenerateStringOverloads]
    public partial void Ctor(CStringPointer filename);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 44 24 ?? 4C 8B 7C 24 ??")]
    public partial void Dtor();
}
