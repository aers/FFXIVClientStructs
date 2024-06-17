using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkCounterNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget
// common CreateAtkNode function "E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 13"
// type 5
[GenerateInterop]
[Inherits<AtkResNode>]
[StructLayout(LayoutKind.Explicit, Size = 0x130)]
[VirtualTable("E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 13", [1, 270])]
public unsafe partial struct AtkCounterNode : ICreatable {
    [FieldOffset(0xB0)] public AtkUldPartsList* PartsList;
    [FieldOffset(0xB8)] public uint PartId;
    [FieldOffset(0xBC)] public byte NumberWidth;
    [FieldOffset(0xBD)] public byte CommaWidth;
    [FieldOffset(0xBE)] public byte SpaceWidth;
    [FieldOffset(0xC0)] public ushort TextAlign;
    [FieldOffset(0xC4)] public float CounterWidth;
    [FieldOffset(0xC8)] public Utf8String NodeText;

    // 7.0 inlines this ctor
    public void Ctor() {
        AtkResNode.Ctor();
        VirtualTable = StaticVirtualTablePointer;
        NodeText.Ctor();
    }

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 0E 8D 04 9B")]
    public partial void SetNumber(int number);

    [MemberFunction("E8 ?? ?? ?? ?? 41 FF C4 49 83 C5 10"), GenerateStringOverloads]
    public partial void SetText(byte* text);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 66 83 F8 08")]
    public partial void UpdateWidth();
}
