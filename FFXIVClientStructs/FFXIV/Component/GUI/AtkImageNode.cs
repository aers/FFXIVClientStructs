using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkImageNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget
// common CreateAtkNode function "E8 ?? ?? ?? ?? 49 8B 55 ?? 0F B7 CD"
// type 2
[GenerateInterop]
[Inherits<AtkResNode>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
[VirtualTable("E8 ?? ?? ?? ?? 49 8B 55 ?? 0F B7 CD", [1, 87])]
public unsafe partial struct AtkImageNode : ICreatable {
    [FieldOffset(0xC0)] public AtkUldPartsList* PartsList;
    [FieldOffset(0xC8)] public ushort PartId;
    [FieldOffset(0xCA)] public byte WrapMode;
    [FieldOffset(0xCB)] public ImageNodeFlags Flags;

    // 7.0 inlines this ctor
    public void Ctor() {
        AtkResNode.Ctor();
        VirtualTable = StaticVirtualTablePointer;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8D ?? ?? ?? ?? 48 8B 71 08"), GenerateStringOverloads]
    public partial void LoadTexture(CStringPointer texturePath, int scale = 1);

    [MemberFunction("E8 ?? ?? ?? ?? 83 E7 0F")]
    public partial void LoadIconTexture(uint iconId, int language);

    [MemberFunction("E8 ?? ?? ?? ?? 85 FF 78 1E")]
    public partial void UnloadTexture();
}

[Flags]
public enum ImageNodeFlags : byte {
    FlipH = 0x01,
    FlipV = 0x02,

    // unk byte https://github.com/NotAdam/Lumina/blob/714a1d8b9c4e182b411e7c68330d49a5dfccb9bc/src/Lumina/Data/Parsing/Uld/NodeData.cs#L51
    // sets two flags 0x20, 0x40
    AutoFit = 0x80 // set if the texture pointer is null
}
