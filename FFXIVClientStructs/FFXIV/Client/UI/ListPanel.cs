using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// ctor "E8 ?? ?? ?? ?? 80 8F ?? ?? ?? ?? ?? 33 F6"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ListPanel : ICreatable {
    [FieldOffset(0x8)] public StdVector<ListPanelEntry> Entries;

    // Width is the width of the container- used when aligning the entries
    [FieldOffset(0x20)] public ushort Width;

    // Height is set by Layout to the total height after placing the entries
    [FieldOffset(0x22)] public ushort Height;

    [VirtualFunction(0)]
    public partial ListPanel* Dtor(byte freeFlags);

    [MemberFunction("E8 ?? ?? ?? ?? 80 8F ?? ?? ?? ?? ?? 33 F6")]
    public partial void Ctor();

    [MemberFunction("48 8B 41 08 48 89 41 10 33 C0")]
    public partial void Clear();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7D BF")]
    public partial void AddNode(AtkResNode* node, ushort topSpacing, uint mode, ushort height);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 66 39 47 20")]
    public partial void AddEntry(ListPanelEntry* entry);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 86 ?? ?? ?? ?? 48 2B 86 ?? ?? ?? ?? 48 C1 F8 04")]
    public partial void UpdateLayout();

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct ListPanelEntry {
        [FieldOffset(0x0)] public AtkResNode* Node;
        // 0- always puts X = 0.0
        // 1- centered in maxWidth
        // 2- right align
        // 3+ keeps the same X-value as the previous node- this may be UB
        [FieldOffset(0x8)] public Alignment Alignment;
        [FieldOffset(0xC)] public ushort TopSpacing;
        // if 0, uses Node.Height
        [FieldOffset(0xE)] public ushort Height;
    }

    public enum Alignment {
        Left = 0,
        Center = 1,
        Right = 2
    }
}
