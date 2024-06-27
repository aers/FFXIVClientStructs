using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentTextNineGrid
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function
// type 19
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe partial struct AtkComponentTextNineGrid : ICreatable {
    [FieldOffset(0xC0)] public AtkTextNode* AtkTextNode;
    [FieldOffset(0xC8)] public AtkResNode* ParentNode;
    [FieldOffset(0xD0)] public float OwnerX;
    [FieldOffset(0xD4)] public int Flags;

    [MemberFunction("33 D2 C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 51 08 48 89 01 48 8B C1 48 89 51 10 48 89 51 18 48 89 51 20 48 89 51 28 48 89 51 30 48 89 51 38 48 89 51 40 89 51 48 48 89 51 50 48 89 51 58 48 89 51 60 48 89 51 68 89 51 70 48 89 51 78 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 66 89 91 ?? ?? ?? ?? 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 88 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? C3")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 48 FF C7 48 83 C3 0C"), GenerateStringOverloads]
    public partial void SetText(byte* str);
}
