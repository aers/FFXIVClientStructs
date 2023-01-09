using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

public enum ImageNodeFlags
{
    FlipH = 0x01,
    FlipV = 0x02,

    // unk byte https://github.com/NotAdam/Lumina/blob/714a1d8b9c4e182b411e7c68330d49a5dfccb9bc/src/Lumina/Data/Parsing/Uld/NodeData.cs#L51
    // sets two flags 0x20, 0x40
    AutoFit = 0x80 // set if the texture pointer is null
}

// Component::GUI::AtkImageNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget

// size = 0xB8
// common CreateAtkNode function E8 ?? ?? ?? ?? 48 8B 4E 08 49 8B D5 
// type 2
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct AtkImageNode : ICreatable
{
    [FieldOffset(0x0)] public AtkResNode AtkResNode;
    [FieldOffset(0xA8)] public AtkUldPartsList* PartsList;
    [FieldOffset(0xB0)] public ushort PartId;
    [FieldOffset(0xB2)] public byte WrapMode;
    [FieldOffset(0xB3)] public byte Flags; // actually a bitfield

    [MemberFunction(
        "E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B C8 48 83 C4 20 5B E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B C8 48 83 C4 20 5B E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ??")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8D ?? ?? ?? ?? 48 8B 71 08")]
    public partial void LoadTexture(byte* texturePath, uint version = 1);

    public void LoadTexture(string texturePath, uint version = 1)
    {
        var bytes = Encoding.ASCII.GetBytes(texturePath);
        var ptr = Marshal.AllocHGlobal(bytes.Length + 1);
        Marshal.Copy(bytes, 0, ptr, bytes.Length);
        Marshal.WriteByte(ptr, bytes.Length, 0);
        LoadTexture((byte*) ptr.ToPointer(), version);
        Marshal.FreeHGlobal(ptr);
    }

    [MemberFunction("E8 ?? ?? ?? ?? 8D 43 76")]
    public partial void LoadIconTexture(int iconId, int version);

    [MemberFunction("E8 ?? ?? ?? ?? 85 FF 78 1E")]
    public partial void UnloadTexture();
}