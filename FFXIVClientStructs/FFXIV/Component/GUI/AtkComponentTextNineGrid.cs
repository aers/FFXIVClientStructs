using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentTextNineGrid
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 19
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe partial struct AtkComponentTextNineGrid : ICreatable {
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
    [FieldOffset(0xC0)] public AtkTextNode* AtkTextNode;
    [FieldOffset(0xC8)] public AtkResNode* OwnerNode;
    [FieldOffset(0xD0)] public float OwnerX;
    [FieldOffset(0xD4)] public int Flags;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F")]
    public partial void Ctor();

    [GenerateCStrOverloads]
    [MemberFunction("E8 ?? ?? ?? ?? 48 FF C7 48 83 C3 0C")]
    public partial void SetText(byte* str);
}
