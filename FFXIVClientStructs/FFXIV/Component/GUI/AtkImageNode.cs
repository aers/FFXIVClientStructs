using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkImageNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget
// common CreateAtkNode function "E8 ?? ?? ?? ?? 48 8B 4C 24 ?? 48 8B 51 08"
// type 2
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct AtkImageNode : ICreatable {
    [FieldOffset(0x0)] public AtkResNode AtkResNode;
    [FieldOffset(0xB0)] public AtkUldPartsList* PartsList;
    [FieldOffset(0xB8)] public ushort PartId;
    [FieldOffset(0xBA)] public byte WrapMode;
    [FieldOffset(0xBB)] public byte Flags; // actually a bitfield

    [MemberFunction("E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B C8 48 83 C4 20 5B E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B C8 48 83 C4 20 5B E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B C8 48 83 C4 20 5B E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ??")]
    public partial void Ctor();

    [GenerateCStrOverloads]
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8D ?? ?? ?? ?? 48 8B 71 08")]
    public partial void LoadTexture(byte* texturePath, uint version = 1);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 43 76")]
    public partial void LoadIconTexture(int iconId, int version);

    [MemberFunction("E8 ?? ?? ?? ?? 85 FF 78 1E")]
    public partial void UnloadTexture();
}

public enum ImageNodeFlags {
    FlipH = 0x01,
    FlipV = 0x02,

    // unk byte https://github.com/NotAdam/Lumina/blob/714a1d8b9c4e182b411e7c68330d49a5dfccb9bc/src/Lumina/Data/Parsing/Uld/NodeData.cs#L51
    // sets two flags 0x20, 0x40
    AutoFit = 0x80 // set if the texture pointer is null
}
